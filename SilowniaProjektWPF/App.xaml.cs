using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Services.ReservationConflictValidators;
using SilowniaProjektWPF.Services.ReservationCreators;
using SilowniaProjektWPF.Services.ReservationProviders;
using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SilowniaProjektWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=gym.db";
        private readonly Gym _gym;
        private readonly GymStore _gymStore;
        private readonly NavigationStore _navigationStore;
        private readonly GymDbContextFactory _gymDbContextFactory;

        public App()
        {

            _gymDbContextFactory = new GymDbContextFactory(CONNECTION_STRING);
            IReservationProvider reservationProvider = new ReservationProvider(_gymDbContextFactory);
            IReservationCreator reservationCreator = new ReservationCreator(_gymDbContextFactory);
            IReservationConflictValidator reservationConflictValidator = new ReservationConflictValidator(_gymDbContextFactory);

            ReservationBook reservationBook = new ReservationBook(reservationProvider, reservationCreator, reservationConflictValidator);
            _gym = new Gym("Strong Gym", reservationBook);
            _gymStore = new GymStore(_gym);
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (GymDbContext dbContext = _gymDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = CreateReservationViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_gymStore, new NavigationService(_navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return ReservationListingViewModel.LoadViewModel(_gymStore, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
