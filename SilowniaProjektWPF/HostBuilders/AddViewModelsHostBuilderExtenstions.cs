using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;

namespace SilowniaProjektWPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtenstions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
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


                services.AddSingleton<MainViewModel>();
            });

            return hostBuilder;
        }

        private static ClientListingViewModel CreateClientListingViewModel(IServiceProvider s)
        {
            return ClientListingViewModel.LoadViewModel(
                s.GetRequiredService<GymStore>(),
                s.GetRequiredService<NavigationService<MakeClientViewModel>>(),
                s.GetRequiredService<NavigationService<MainMenuViewModel>>()
                );
        }

        private static EquipListingViewModel CreateEquipListingViewModel(IServiceProvider s)
        {
            return EquipListingViewModel.LoadViewModel(
                s.GetRequiredService<GymStore>(),
                s.GetRequiredService<NavigationService<MakeEquipmentViewModel>>(),
                s.GetRequiredService<NavigationService<MainMenuViewModel>>()
                );
        }

        private static WorkerListingViewModel CreateWorkerListingViewModel(IServiceProvider s)
        {
            return WorkerListingViewModel.LoadViewModel(
                s.GetRequiredService<GymStore>(),
                s.GetRequiredService<NavigationService<MakeWorkerViewModel>>(),
                s.GetRequiredService<NavigationService<MainMenuViewModel>>()
                );
        }

        private static ReservationListingViewModel CreateReservationListingViewModel(IServiceProvider s)
        {
            return ReservationListingViewModel.LoadViewModel(
                s.GetRequiredService<GymStore>(),
                s.GetRequiredService<NavigationService<MakeReservationViewModel>>(),
                s.GetRequiredService<NavigationService<MainMenuViewModel>>()
                );
        }

    }
}
