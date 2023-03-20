using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Models;
using ServiceBusApp.Views.RideView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ServiceBusApp.ViewModels.RideViewModel
{
    public class RideViewModel : ViewModelBase
    {
        private int studentCount;
        private Driver selectedDriver;

        public Driver SelectedDriver { get => selectedDriver; set { Set(ref selectedDriver,value); } }

        public Student SelectedStudent { get; set; }

        public ObservableCollection<Driver> Drivers { get; set; }

        public ObservableCollection<Student> Students { get; set; } = new();

        public ObservableCollection<Student> TempStudents { get; set; }

        public ObservableCollection<Ride> Rides { get; set; }

        public Ride Ride { get; set; } = new();

        public int StudentCount
        {
            get => studentCount;
            set => Set(ref studentCount, value);
        }

        public Page CurrentPage { get; set; } = new();
        public RideViewModel(ObservableCollection<Driver> drivers, ObservableCollection<Student> students,ObservableCollection<Ride> rides,Page currentPage)
        {
            Drivers = drivers;
            TempStudents = students;
            for (int i = 0; i < TempStudents.Count; i++)
            {
                Students.Add(TempStudents[i]);
            }
            Rides = rides;
            CurrentPage = currentPage;
        }

        public RideViewModel(ObservableCollection<Driver> drivers, ObservableCollection<Student> students, ObservableCollection<Ride> rides)
        {
            Drivers = drivers;
            TempStudents = students;
            for (int i = 0; i < TempStudents.Count; i++)
            {
                Students.Add(TempStudents[i]);
            }
            Rides = rides;
        }

        public RelayCommand AddStudentCommand
        {
            get => new RelayCommand(() =>
        {
            try {
                if (StudentCount + 1 < SelectedDriver.Car.SeatCount)
                {
                    Ride.Students.Add(SelectedStudent);
                    Students.Remove(SelectedStudent);
                    StudentCount++;
                }
                else
                    MessageBox.Show("There was no empty seat left in the bus", "ServiceBusApplication", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please select driver","BusServiceApplication",MessageBoxButton.OK, MessageBoxImage.Error);
            }
                }
        );
        }

        public RelayCommand RemoveStudentCommand
        {
            get => new RelayCommand(() =>
            {
                Students.Add(SelectedStudent);
                Ride.Students.Remove(SelectedStudent);
                StudentCount--;
            });
        }

        public RelayCommand CreateRideCommand
        {
            get => new RelayCommand(() =>
            {
                Ride.Driver = SelectedDriver;
                if (Ride.Driver != null && StudentCount > 0)
                {
                    Ride.CreationTime = DateTime.Now;
                    Rides.Add(Ride);
                    MessageBox.Show("Ride Created", "ServiceBusApplication", MessageBoxButton.OK, MessageBoxImage.Information);
                    CurrentPage = App.Container.GetInstance<CreateRideView>();
                    CurrentPage.DataContext = new RideViewModel(Drivers,TempStudents,Rides);
                }
            });
        }


    }
}
