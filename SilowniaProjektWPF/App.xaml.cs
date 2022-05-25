using SilowniaProjektWPF.DAL.Models;
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
        private readonly Gym _gym;

        public App()
        {
            _gym = new Gym("Strong Gym");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_gym)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
