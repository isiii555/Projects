using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class EditDriverViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private List<Car> cars;
    public List<Car> Cars { get => cars; set => Set(ref cars, value); }
    private Car _car;
    private Driver _driver;
    public Car Car { get => _car;set => Set(ref _car, value); }
    public Driver Driver { get => _driver; set => Set(ref _driver, value); }
    public EditDriverViewModel(INavigationService navigationService)
    {
        _navigationService = Guard.Against.Null(navigationService);
        Cars = App._carRepository != null ? App._carRepository.GetAll().ToList() : new List<Car>();
        Driver = Guard.Against.Null(new Driver());
    }


    public RelayCommand SaveCommand
    {
        get => new(() =>
        {
            try
            {
                if (Driver.FirstName != string.Empty && Driver.LastName != string.Empty && Driver.PhoneNumber != string.Empty && Driver.Username != string.Empty && Driver.Password != string.Empty && Driver.HasLicense != false && Driver.LastName != string.Empty && Driver.Address != string.Empty && Car is not null)
                {
                    Driver.CarId = Car.Id;
                    App._driverRepository.UpdateDriver(Driver);
                    _navigationService.NavigateTo<DriverViewModel>();
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });
    }
}