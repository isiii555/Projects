using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ServiceBusApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBusApp.ViewModels.DriverViewModel
{
    public class AddDriverViewModel : ViewModelBase
    {
        private Driver driver;
        public Driver Driver
        {
            get { return driver; }
            set { Set(ref driver, value); }
        }

        public ObservableCollection<Driver> Drivers { get; set; }

        public ObservableCollection<Car> Cars { get; set; }

        public Car SelectedItem { get; set; }

        public Window CurrentWindow { get; set; }
        public AddDriverViewModel(ObservableCollection<Driver> drivers, ObservableCollection<Car> cars, Window currentWindow)
        {
            Driver = new();
            Drivers = drivers;
            Cars = cars;
            CurrentWindow = currentWindow;
        }

        public RelayCommand CreateCommand
        {
            get => new RelayCommand(() =>
            {
                if (driver.Adress != null && driver.Name != null && driver.Surname != null && SelectedItem != null) {
                    driver.Car = SelectedItem;
                    Drivers.Add(driver);
                    CurrentWindow.Close();
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }

    }
}
