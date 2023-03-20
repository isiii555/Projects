using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Models;
using ServiceBusApp.ViewModels.CarViewModel;
using ServiceBusApp.ViewModels.DriverViewModel;
using ServiceBusApp.ViewModels.RideViewModel;
using ServiceBusApp.ViewModels.StudentViewModel;
using ServiceBusApp.Views;
using ServiceBusApp.Views.DriverView;
using ServiceBusApp.Views.RidesView;
using ServiceBusApp.Views.RideView;
using ServiceBusApp.Views.StudentView;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ServiceBusApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Car> Cars { get; set; } = new(); 

        public ObservableCollection<Driver> Drivers { get; set; } = new();

        public ObservableCollection<Student> Students { get; set; } = new();

        public ObservableCollection<Ride> Rides { get; set; } = new();

        private Page currentPage;

        public Page CurrentPage
        {
            get => currentPage;
            set => Set(ref currentPage, value);
        }

        public MainViewModel()
        {
            Cars = new() {
                new Car("Optima","Kia","90-ZZ-667",24),
                new Car("Mitsubishi","Pajero","90-SZ-667",30),
                new Car("Elantra","Hyundai","90-ZZ-316",12),
            };
            Drivers = new() {
                new Driver("islam","salamzade","baku",new Car("kia","sorento","90-zz-667",31)),
                new Driver("Namiq","Rasullu","Baku",new Car("Mitsubish","Pajero","90-zz-667",30)),
                new Driver("islam","salamzade","baku",new Car("kia","sorento","90-zz-667",31))
            };
            Students = new()
            {
                new Student("islam","salamzade","emil","191",1,"Qara Qarayev pr, Nizami Rayonu, Azerbaycan"),
                new Student("namiq","rasullu","bahman","191",1,"Ziya Bünyadov Prospekti,31,Bakü"),
                new Student("islam","salamzade","emil","191",1,"27 Afiyəddin Cəlilov küçəsi 13th level, Baku, Baku AZ1000"),
            };
            CurrentPage = new Page() { DataContext = this };
        }

        public RelayCommand CarPageCommand
        { get => new RelayCommand(() => {
            CurrentPage = App.Container.GetInstance<CarView>();
            CurrentPage.DataContext = new CarPageViewModel(Cars);
            });
        }

        public RelayCommand DriverPageCommand
        {
            get => new RelayCommand(() =>
            {
                CurrentPage = App.Container.GetInstance<DriverView>();
                CurrentPage.DataContext = new DriverPageViewModel(Drivers, Cars);
            });
        }

        public RelayCommand StudentPageCommand
        {
            get => new RelayCommand(
                () =>
                {
                    CurrentPage = App.Container.GetInstance<StudentView>();
                    CurrentPage.DataContext = new StudentViewModel.StudentViewModel(Students);
                });
        }

        public RelayCommand RidePageCommand
        {
            get => new RelayCommand(
                () =>
                {
                    CurrentPage = App.Container.GetInstance<CreateRideView>();
                    CurrentPage.DataContext = new RideViewModel.RideViewModel(Drivers,Students,Rides,CurrentPage);
                });
        }

        public RelayCommand RidesPageCommand
        {
            get => new RelayCommand(
                () =>
                {
                    CurrentPage = App.Container.GetInstance<RidesView>();
                    CurrentPage.DataContext = new RidesViewModel.RidesViewModel(Rides,Drivers,Students);
                });
        }
    }
}