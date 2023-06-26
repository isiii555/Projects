using System.Collections.ObjectModel;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class CarViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly ICarRepository _carRepository;

    private ObservableCollection<Car> cars;

    public Car Car { get; set; } = new();

    public ObservableCollection<Car> Cars { get => cars; set => Set(ref cars, value); }


    public CarViewModel(
        INavigationService navigationService,
        ICarRepository carRepository
    )
    {
        _navigationService = Guard.Against.Null(navigationService);
        _carRepository = Guard.Against.Null(carRepository);
        Cars = Guard.Against.Null(new ObservableCollection<Car>(_carRepository.GetAll()));
    }


    public RelayCommand AddCarCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<AddCarViewModel>();
        });
    }

    public RelayCommand EditCarCommand
    {
        get => new(() =>
        {
            App._container.GetInstance<EditCarViewModel>().Car = Car;
            _navigationService.NavigateTo<EditCarViewModel>();

            Cars = new ObservableCollection<Car>(App._carRepository.GetAll());
        });
    }

    public RelayCommand RemoveCarCommand
    {
        get => new(() =>
        {
            App._carRepository.RemoveCar(Car);

            Cars = new ObservableCollection<Car>(App._carRepository.GetAll());
        });
    }
}