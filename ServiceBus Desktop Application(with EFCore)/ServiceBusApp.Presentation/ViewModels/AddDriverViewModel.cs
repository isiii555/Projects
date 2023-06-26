using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class AddDriverViewModel : ViewModelBase
{
    private readonly ICarRepository _carRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly INavigationService _navigationService;
    private Car _car;
    private Driver _driver;
    public Car Car { get => _car;set => Set(ref _car, value); }
    public Driver Driver { get => _driver; set => Set(ref _driver, value); }

    public List<Car> Cars { get; set; }
    public AddDriverViewModel(
        INavigationService navigationService,
        ICarRepository carRepository,
        IDriverRepository driverRepository
    )
    {
        _navigationService = Guard.Against.Null(navigationService);
        _carRepository = Guard.Against.Null(carRepository);
        _driverRepository = Guard.Against.Null(driverRepository);
        _driver = Guard.Against.Null(new Driver());
        Cars = Guard.Against.Null(_carRepository.GetCarQuery(c => c.Driver == null).ToList());
    }

    public RelayCommand CreateCommand
    {
        get => new(() =>
        {
            try
            {
                if (_driver.FirstName != string.Empty && _driver.LastName != string.Empty && _driver.PhoneNumber != string.Empty && _driver.Username != string.Empty && _driver.Password != string.Empty && _driver.HasLicense != false && _driver.LastName != string.Empty && _driver.Address != string.Empty)
                {
                    _driver.CarId = _car.Id;
                    _driverRepository.AddDriver(_driver);
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