using System;
using System.Windows;
using Ardalis.GuardClauses;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class AddCarViewModel : ViewModelBase
{
    private Car _car;
    private readonly INavigationService _navigationService;
    private readonly ICarRepository _carRepository;
    public Car Car { get => _car; set => Set(ref _car, value); }

    public AddCarViewModel(
        ICarRepository carRepository,
        INavigationService navigationService
    )
    {
        _car = Guard.Against.Null(new Car());
        _navigationService = Guard.Against.Null(navigationService);
        _carRepository = Guard.Against.Null(carRepository);
    }

    public RelayCommand CreateCommand
    {
        get => new(() =>
        {
            try
            {
                if (_car.Name != string.Empty && _car.CarNumber != string.Empty && _car.SeatCount != 0)
                {
                    _carRepository.AddCar(_car);
                    _navigationService.NavigateTo<CarViewModel>();
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