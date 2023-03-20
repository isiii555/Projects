using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Models;
using ServiceBusApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ServiceBusApp.ViewModels.CarViewModel
{
    public class CarPageViewModel
    {
        public CarPageViewModel(ObservableCollection<Car> cars)
        {
            Cars = cars;
        }

        public ObservableCollection<Car> Cars { get; set; }

        public Car SelectedCar { get; set; } = new();

        public RelayCommand AddCarCommand
        {
            get => new RelayCommand(() =>
        {
            Window window = new AddCarView();
            window.DataContext = new AddCarViewModel(Cars,window);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        });
        }

        public RelayCommand EditCarCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new EditCarView();
                window.DataContext = new EditCarViewModel(SelectedCar,window);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();
            });
        }

        public RelayCommand RemoveCarCommand
        {
            get => new RelayCommand(() =>
            {
                Cars.Remove(SelectedCar);
            });
        }
    }
}
