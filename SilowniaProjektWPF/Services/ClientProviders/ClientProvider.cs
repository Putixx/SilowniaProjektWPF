using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using SilowniaProjektWPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ClientProviders
{
    public class ClientProvider : IClientProvider
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public ClientProvider(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ClientDTO> ClientsDTOs = await context.Clients.ToListAsync();

                return ClientsDTOs.Select(e => ToClient(e));
            }
        }

        private static Client ToClient(ClientDTO c)
        {
            return new Client(c.Name, c.Surname, c.PhoneNumber, c.PassNumber);
        }

        public async Task CreateClient(Client Client)
        {
            Client conflictingClient = await CheckIfExists(Client);
            Client conflictingNumber = await CheckIfSameNumber(Client);

            if (conflictingClient != null)
            {
                throw new ClientConflictException(conflictingClient, Client);
            }

            if (conflictingNumber != null)
            {
                throw new ClientExistingNumberException(conflictingNumber, Client);
            }

            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                ClientDTO ClientDTO = ToClientDTO(Client);

                context.Clients.Add(ClientDTO);
                await context.SaveChangesAsync();
            }
        }

        private ClientDTO ToClientDTO(Client Client)
        {
            return new ClientDTO()
            {
                Name = Client.Name,
                Surname = Client.Surname,
                PhoneNumber = Client.PhoneNumber,
                PassNumber = Client.PassNumber
            };
        }

        private async Task<Client> CheckIfExists(Client Client)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                ClientDTO ClientDTO = await context.Clients.Where(c => c.Name == Client.Name)
                    .Where(c => c.Surname == Client.Surname)
                    .Where(c => c.PhoneNumber == Client.PhoneNumber)
                    .FirstOrDefaultAsync();

                if (ClientDTO == null) return null;

                return ToClient(ClientDTO);
            }
        }

        private async Task<Client> CheckIfSameNumber(Client Client)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                ClientDTO ClientDTO = await context.Clients.Where(w => w.PhoneNumber == Client.PhoneNumber).FirstOrDefaultAsync();

                if (ClientDTO == null) return null;

                return ToClient(ClientDTO);
            }
        }
    }
}
