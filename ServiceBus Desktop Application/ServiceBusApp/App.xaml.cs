using ServiceBusApp.ViewModels;
using ServiceBusApp.ViewModels.CarViewModel;
using ServiceBusApp.Views;
using ServiceBusApp.Views.DriverView;
using ServiceBusApp.Views.RidesView;
using ServiceBusApp.Views.RideView;
using ServiceBusApp.Views.StudentView;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBusApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container? Container { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            var window = Container.GetInstance<MainView>();
            window.DataContext = new MainViewModel();
            window.VerticalAlignment = VerticalAlignment.Center;
            window.HorizontalAlignment = HorizontalAlignment.Center;
            window.ShowDialog();
            Current.Shutdown();
        }

        private void Register()
        {
            Container = new();

            Container.RegisterSingleton<MainView>();
            Container.RegisterSingleton<DriverView>();
            Container.Register<EditDriverView>();
            Container.Register<AddDriverView>();
            Container.Register<EditCarView>();
            Container.RegisterSingleton<CarView>();
            Container.Register<AddCarView>();
            Container.Register<AddStudentView>();
            Container.RegisterSingleton<StudentView>();
            Container.Register<EditStudentView>();
            Container.RegisterSingleton<CreateRideView>();
            Container.RegisterSingleton<RidesView>();
            Container.Register<EditRideView>();
            Container.Register<RideStartView>();

            Container.Verify();
        }
    }
}
