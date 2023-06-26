using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class RideViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IDriverRepository _driverRepository;
    private readonly IStudentRepository _studentRepository;

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


    public RideViewModel(
        INavigationService navigationService,
        IDriverRepository driverRepository,
        IStudentRepository studentRepository
    )
    {
        _navigationService = Guard.Against.Null(navigationService);
        Ride = new();
        _driverRepository = Guard.Against.Null(driverRepository);
        _studentRepository = Guard.Against.Null(studentRepository);

        Drivers = _driverRepository.GetDriverQuery(dr => dr.RideId == null).ToList();
        Students = new ObservableCollection<Student>(_studentRepository.GetStudentQuery(st => st.RideId == null));
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
        });
    }

    public RelayCommand RemoveStudentCommand
    {
        get => new(() =>
        {
            SelectedStudent.RideId = null;
            Students.Add(SelectedStudent);
            TempStudents.Remove(SelectedStudent);
            StudentCount--;
        });
    }

    public RelayCommand CreateRideCommand
    {
        get => new(() =>
        {
            try
            {
                if (SelectedDriver != null && StudentCount > 0)
                {
                    App._rideRepository.AddRide(Ride);

                    SelectedDriver.RideId = Ride.Id;

                    for (int i = 0; i < TempStudents.Count; i++)
                        TempStudents[i].RideId = Ride.Id;
                    App._studentRepository.SaveChanges();
                    MessageBox.Show("Ride Created", "ServiceBusApplication", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigationService.NavigateTo<RideViewModel>();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });
    }
}