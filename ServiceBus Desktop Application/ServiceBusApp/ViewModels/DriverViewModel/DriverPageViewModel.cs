using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Models;
using ServiceBusApp.Views.DriverView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ServiceBusApp.ViewModels.DriverViewModel
{
    public class DriverPageViewModel : ViewModelBase
    {
        public ObservableCollection<Driver> Drivers { get; set; }

        public ObservableCollection<Car> Cars { get; set; }

        public Driver? SelectedDriver { get; set; }

        public DriverPageViewModel(ObservableCollection<Driver> drivers, ObservableCollection<Car> cars)
        {
            Drivers = drivers;
            Cars = cars;
        }

        public RelayCommand AddDriverCommand {
            get => new RelayCommand(
                () => {
                    Window window = new AddDriverView();
                    window.DataContext = new AddDriverViewModel(Drivers, Cars, window);
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.Show();
                });
        }

        public RelayCommand EditDriverCommand
        {
            get => new RelayCommand(
                () => {
                    Window window = new EditDriverView();
                    window.DataContext = new EditDriverViewModel(SelectedDriver, Cars,window);
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.Show();
                });
        }

        public RelayCommand RemoveDriverCommand
        {
            get => new RelayCommand(
                () => {
                    Drivers.Remove(SelectedDriver);
                });
        }
    }
}
