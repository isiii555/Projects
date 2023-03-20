using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBusApp.ViewModels.DriverViewModel
{
    public class EditDriverViewModel : ViewModelBase
    {
        private Driver? driver;

        public Car? SelectedCar { get; set; }

        public Driver? Driver { get => driver; set => Set(ref driver, value); }

        public ObservableCollection<Car> Cars { get; set; }

        public Driver? TempDriver { get; set; }

        public Window CurrenWindow { get; set; }

        public EditDriverViewModel(Driver driver, ObservableCollection<Car> cars, Window currenWindow)
        {
            Driver = new();
            Cars = cars;
            TempDriver = driver;
            SelectedCar = driver.Car;
            Driver.Car = driver.Car;
            Driver.Name = driver.Name;
            Driver.Surname = driver.Surname;
            Driver.Adress = driver.Adress;
            CurrenWindow = currenWindow;
        }

        public RelayCommand SaveCommand
        {
            get => new RelayCommand(() =>
        {
            if (Driver?.Adress != string.Empty && Driver?.Name != string.Empty && Driver?.Surname != string.Empty && SelectedCar != null)
            {
                TempDriver.Car = SelectedCar;
                TempDriver.Name = Driver.Name;
                TempDriver.Surname = Driver.Surname;
                TempDriver.Adress = Driver.Adress;
                CurrenWindow.Close();
            }
            else
                MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
        });
        }
    }
}
