using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class EditRideViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private int studentCount;
    private Driver selectedDriver;

    public Driver SelectedDriver { get => selectedDriver; set { Set(ref selectedDriver, value); } }
    public Student SelectedStudent { get; set; }
    public List<Driver> Drivers { get; set; }
    public ObservableCollection<Student> Students { get; set; }
    public ObservableCollection<Student> TempStudents { get; set; } = new();
    public Ride Ride { get; set; }

    public int StudentCount
    {
        get => studentCount;
        set => Set(ref studentCount, value);
    }
    public EditRideViewModel(INavigationService navigationService)
    {
        _navigationService = Guard.Against.Null(navigationService);
        Drivers = App._driverRepository != null ? App._driverRepository.GetAll().ToList() : new List<Driver>();
    }

    public RelayCommand AddStudentCommand
    {
        get => new(() =>
        {
            try
            {
                if (StudentCount + 1 < SelectedDriver.Car.SeatCount)
                {
                    TempStudents.Add(SelectedStudent);
                    Students.Remove(SelectedStudent);
                    StudentCount++;
                }
                else
                    MessageBox.Show("There was no empty seat left in the bus", "ServiceBusApplication", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select driver", "BusServiceApplication", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    );
    }

    public RelayCommand RemoveStudentCommand
    {
        get => new(() =>
        {
            App._studentRepository.UpdateStudent(SelectedStudent);
            Students.Add(SelectedStudent);
            TempStudents.Remove(SelectedStudent);
            Ride.Students = TempStudents;
            StudentCount--;
        });
    }

    public RelayCommand SaveRideCommand
    {
        get => new(() =>
        {
            try
            {
                if (SelectedDriver != null && StudentCount >= 0)
                {
                    foreach (var stud in Students)
                        stud.RideId = null;
                    foreach (var stud in TempStudents)
                        stud.RideId = Ride.Id;
                    SelectedDriver.RideId = Ride.Id;
                    App._rideRepository.UpdateRide(Ride);
                    MessageBox.Show("Ride Saved", "ServiceBusApplication", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigationService.NavigateTo<RidesViewModel>();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });
    }
}