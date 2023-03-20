using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Models;
using ServiceBusApp.Views.RidesView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBusApp.ViewModels.RidesViewModel
{
    public class RidesViewModel : ViewModelBase
    {
        private int studentCount;

        private Ride selectedRide;

        public Ride SelectedRide { get => selectedRide; set { Set(ref selectedRide, value); } }
        public Student SelectedStudent { get; set; }

        public ObservableCollection<Ride> Rides { get; set; }

        public ObservableCollection<Student> Students { get; set; }

        public ObservableCollection<Driver> Drivers { get; set; }

        public int StudentCount
        {
            get => studentCount;
            set => Set(ref studentCount, value);
        }

        public RidesViewModel(ObservableCollection<Ride> rides,ObservableCollection<Driver> drivers,ObservableCollection<Student> students) 
        {
            Rides = rides;
            Students = students;
            Drivers = drivers;
        }

        public RelayCommand StartRideCommand {
            get => new RelayCommand(() =>
            {
                RideStartView window = App.Container.GetInstance<RideStartView>();
                window.DataContext = new RideStartViewModel(SelectedRide,window.MyMap,window);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();
            });
        }

        public RelayCommand RemoveRideCommand{
            get => new RelayCommand(() =>
            {
                Rides.Remove(SelectedRide);
            });
        }

        public RelayCommand EditRideCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = App.Container.GetInstance<EditRideView>();
                window.DataContext = new EditRideViewModel(Rides, Drivers,Students,SelectedRide,window);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();
            });
        }
    }
}
