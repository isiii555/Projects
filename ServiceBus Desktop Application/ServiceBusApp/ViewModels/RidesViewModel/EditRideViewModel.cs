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

namespace ServiceBusApp.ViewModels.RidesViewModel
{
    public class EditRideViewModel : ViewModelBase
    {
        private ObservableCollection<Student> students = new();
        public Ride Ride { get; set; } = new();
        public Ride TempRide { get; set; }
        public Student SelectedStudent { get; set; }

        public ObservableCollection<Ride> Rides { get; set; }

        public ObservableCollection<Student> Students 
        {   get => students; 
            set { Set(ref students, value); } 
        }

        public ObservableCollection<Student> TempStudents { get; set; }

        public ObservableCollection<Driver> Drivers { get; set; }

        public Window CurrentWindow { get; set; }

        public EditRideViewModel(ObservableCollection<Ride> rides, ObservableCollection<Driver> drivers, ObservableCollection<Student> students, Ride ride,Window window)
        {
            Rides = rides;
            TempStudents = students;
            Drivers = drivers;
            TempRide = ride;
            Ride.Driver = TempRide.Driver;
            Ride.Students = TempRide.Students;
            Ride.CreationTime = TempRide.CreationTime;
            CurrentWindow = window;
            CheckFunction();

        }

        void CheckFunction()
        {
            bool cond = true;
            for (int i = 0; i < TempStudents.Count; i++)
            {
                for (int j = 0; j < Ride.Students.Count; j++)
                {
                    if (TempStudents[i] == Ride.Students[j])
                    {
                        cond = false;
                    }
                }
                if (cond)
                {
                    Students.Add(TempStudents[i]);
                }
                cond = true;
            }
        }

        public RelayCommand SaveRideCommand
        {
            get => new RelayCommand(() =>
        {
            if (Ride.Students.Count > 0 && Ride.Driver != null)
            {
                TempRide.Driver = Ride.Driver;
                TempRide.Students = Ride.Students;
                TempRide.CreationTime = DateTime.Now;
                CurrentWindow.Close();
            }
            else
                MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
        });
        }

        public RelayCommand AddStudentCommand
        {
            get => new RelayCommand(() =>
            {
                if (Ride.Students.Count + 1 < Ride.Driver.Car.SeatCount)
                {
                    Ride.Students.Add(SelectedStudent);
                    Students.Remove(SelectedStudent);
                }
                else
                    MessageBox.Show("There was no empty seat left in the bus", "ServiceBusApplication", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }

        public RelayCommand RemoveStudentCommand
        {
            get => new RelayCommand(() =>
            {
                Students.Add(SelectedStudent);
                Ride.Students.Remove(SelectedStudent);
            });
        }

    }
}
