using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Services.ClientProviders;
using SilowniaProjektWPF.Services.EquipmentProviders;
using SilowniaProjektWPF.Services.PassProviders;
using SilowniaProjektWPF.Services.ReservationConflictValidators;
using SilowniaProjektWPF.Services.ReservationCreators;
using SilowniaProjektWPF.Services.ReservationProviders;
using SilowniaProjektWPF.Services.WorkerProviders;
using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;
using System.Windows;

namespace SilowniaProjektWPF
{
    // Publish
    // dotnet publish -c Release --self-contained=true -p:PublishSingleFile=true


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
                services.AddSingleton<IWorkerProvider, WorkerProvider>();
                services.AddSingleton<IEquipmentProvider, EquipmentProvider>();
                services.AddSingleton<IClientProvider, ClientProvider>();
                services.AddSingleton<IPassProvider, PassProvider>();

                services.AddSingleton<ReservationBook>();
                services.AddSingleton(s => new Gym("Strong Gym", s.GetRequiredService<ReservationBook>(), s.GetRequiredService<IWorkerProvider>(), 
                    s.GetRequiredService<IEquipmentProvider>(), s.GetRequiredService<IClientProvider>(), s.GetRequiredService<IPassProvider>()));

                services.AddTransient<StartAppViewModel>();
                services.AddSingleton<Func<StartAppViewModel>>(s => () => s.GetRequiredService<StartAppViewModel>());
                services.AddSingleton<NavigationService<StartAppViewModel>>();

                services.AddTransient<MainMenuViewModel>();
                services.AddSingleton<Func<MainMenuViewModel>>(s => () => s.GetRequiredService<MainMenuViewModel>());
                services.AddSingleton<NavigationService<MainMenuViewModel>>();

                services.AddTransient(s => CreateWorkerListingViewModel(s));
                services.AddSingleton<Func<WorkerListingViewModel>>(s => () => s.GetRequiredService<WorkerListingViewModel>());
                services.AddSingleton<NavigationService<WorkerListingViewModel>>();

                services.AddTransient<MakeWorkerViewModel>();
                services.AddSingleton<Func<MakeWorkerViewModel>>(s => () => s.GetRequiredService<MakeWorkerViewModel>());
                services.AddSingleton<NavigationService<MakeWorkerViewModel>>();

                services.AddTransient(s => CreateClientListingViewModel(s));
                services.AddSingleton<Func<ClientListingViewModel>>(s => () => s.GetRequiredService<ClientListingViewModel>());
                services.AddSingleton<NavigationService<ClientListingViewModel>>();

                services.AddTransient<MakeClientViewModel>();
                services.AddSingleton<Func<MakeClientViewModel>>(s => () => s.GetRequiredService<MakeClientViewModel>());
                services.AddSingleton<NavigationService<MakeClientViewModel>>();

                services.AddTransient(s => CreateEquipListingViewModel(s));
                services.AddSingleton<Func<EquipListingViewModel>>(s => () => s.GetRequiredService<EquipListingViewModel>());
                services.AddSingleton<NavigationService<EquipListingViewModel>>();

                services.AddTransient<MakeEquipmentViewModel>();
                services.AddSingleton<Func<MakeEquipmentViewModel>>(s => () => s.GetRequiredService<MakeEquipmentViewModel>());
                services.AddSingleton<NavigationService<MakeEquipmentViewModel>>();

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

        private ClientListingViewModel CreateClientListingViewModel(IServiceProvider s)
        {
            return ClientListingViewModel.LoadViewModel(
                s.GetRequiredService<GymStore>(),
                s.GetRequiredService<NavigationService<MakeClientViewModel>>(),
                s.GetRequiredService<NavigationService<MainMenuViewModel>>()
                );
        }

        private EquipListingViewModel CreateEquipListingViewModel(IServiceProvider s)
        {
            return EquipListingViewModel.LoadViewModel(
                s.GetRequiredService<GymStore>(),
                s.GetRequiredService<NavigationService<MakeEquipmentViewModel>>(),
                s.GetRequiredService<NavigationService<MainMenuViewModel>>()
                );
        }

        private WorkerListingViewModel CreateWorkerListingViewModel(IServiceProvider s)
        {
            return WorkerListingViewModel.LoadViewModel(
                s.GetRequiredService<GymStore>(),
                s.GetRequiredService<NavigationService<MakeWorkerViewModel>>(),
                s.GetRequiredService<NavigationService<MainMenuViewModel>>()
                );
        }

        private ReservationListingViewModel CreateReservationListingViewModel(IServiceProvider s)
        {
            return ReservationListingViewModel.LoadViewModel(
                s.GetRequiredService<GymStore>(),
                s.GetRequiredService<NavigationService<MakeReservationViewModel>>(),
                s.GetRequiredService<NavigationService<MainMenuViewModel>>()
                );
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            using (GymDbContext dbContext = _host.Services.GetRequiredService<GymDbContextFactory>().CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            _host.Services.GetRequiredService<NavigationService<StartAppViewModel>>().Navigate();

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
