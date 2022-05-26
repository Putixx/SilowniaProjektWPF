using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(new GymDbContextFactory(hostContext.Configuration.GetConnectionString("Default")));
                services.AddSingleton<IReservationProvider, ReservationProvider>();
                services.AddSingleton<IReservationCreator, ReservationCreator>();
                services.AddSingleton<IReservationConflictValidator, ReservationConflictValidator>();

                services.AddSingleton<ReservationBook>();
                services.AddSingleton(s => new Gym("Strong Gym", s.GetRequiredService<ReservationBook>()));

                services.AddTransient(s => CreateReservationListingViewModel(s));
                services.AddSingleton<Func<ReservationListingViewModel>>(s => () => s.GetRequiredService<ReservationListingViewModel>());
                services.AddSingleton<NavigationService<ReservationListingViewModel>>();

                services.AddTransient<MakeReservationViewModel>();
                services.AddSingleton<Func<MakeReservationViewModel>>(s => () => s.GetRequiredService<MakeReservationViewModel>());
                services.AddSingleton<NavigationService<MakeReservationViewModel>>();

                services.AddSingleton<GymStore>();
                services.AddSingleton<NavigationStore>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });
            })
                .Build();
        }

        private ReservationListingViewModel CreateReservationListingViewModel(IServiceProvider s)
        {
            return ReservationListingViewModel.LoadViewModel(
                s.GetRequiredService<GymStore>(),
                s.GetRequiredService<NavigationService<MakeReservationViewModel>>()
                );
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            using (GymDbContext dbContext = _host.Services.GetRequiredService<GymDbContextFactory>().CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            _host.Services.GetRequiredService<NavigationService<ReservationListingViewModel>>().Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
