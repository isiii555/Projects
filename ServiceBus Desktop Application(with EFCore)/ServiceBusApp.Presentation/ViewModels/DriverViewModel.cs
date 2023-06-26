using System.Collections.ObjectModel;
using System.Linq;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class DriverViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private ObservableCollection<Driver> drivers;

    public Driver Driver { get; set; }
    public ObservableCollection<Driver> Drivers { get => drivers; set => Set(ref drivers, value); }


    public DriverViewModel(INavigationService navigationService)
    {
        _navigationService = Guard.Against.Null(navigationService);
        Drivers = App._driverRepository != null ? new ObservableCollection<Driver>(App._driverRepository.GetAll()) : new ObservableCollection<Driver>();
    }


    public RelayCommand AddDriverCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<AddDriverViewModel>();
        });
    }

    public RelayCommand EditDriverCommand
    {
        get => new(() =>
        {
            App._container.GetInstance<EditDriverViewModel>().Driver = Driver;
            App._container.GetInstance<EditDriverViewModel>().Cars = App._carRepository.GetAll().ToList();
            _navigationService.NavigateTo<EditDriverViewModel>();
            Drivers = new ObservableCollection<Driver>(App._driverRepository.GetAll());
        });
    }

    public RelayCommand RemoveDriverCommand
    {
        get => new(() =>
        {
            App._driverRepository.RemoveDriver(Driver);
            Drivers = new ObservableCollection<Driver>(App._driverRepository.GetAll());
        });
    }
}