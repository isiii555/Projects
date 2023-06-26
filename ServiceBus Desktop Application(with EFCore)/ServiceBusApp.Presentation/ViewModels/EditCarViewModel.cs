using System.Windows;
using System;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class EditCarViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private Car _car;
    public Car Car { get => _car;set => Set(ref _car,value); }
    public EditCarViewModel(INavigationService navigationService)
    {
        _navigationService = Guard.Against.Null(navigationService);
    }


    public RelayCommand SaveCommand
    {
        get => new(() =>
        {
            try
            {
                if (Car?.Name != string.Empty && Car?.CarNumber != string.Empty && Car?.SeatCount != 0)
                {
                    App._carRepository.UpdateCar(Car);

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