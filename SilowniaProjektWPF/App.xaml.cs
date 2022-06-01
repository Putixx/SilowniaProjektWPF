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
using SilowniaProjektWPF.HostBuilders;
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
                .AddViewModels()
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

                
                services.AddSingleton<GymStore>();
                services.AddSingleton<NavigationStore>();

                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });
            })
                .Build();
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
