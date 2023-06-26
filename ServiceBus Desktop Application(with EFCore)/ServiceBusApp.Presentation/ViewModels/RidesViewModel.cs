using System.Collections.ObjectModel;
using System.Linq;
using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class RidesViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IRideRepository _rideRepository;

    private Ride _selectedRide;
    private ObservableCollection<Ride> _rides;

    public Ride SelectedRide { get => _selectedRide; set { Set(ref _selectedRide, value); } }
    public ObservableCollection<Ride> Rides { get => _rides; set => Set(ref _rides, value); }

    public RidesViewModel(
        INavigationService navigationService,
        IRideRepository rideRepository
    )
    {
        _navigationService = Guard.Against.Null(navigationService);
        _rideRepository = Guard.Against.Null(rideRepository);
        CheckRides();
        Rides = Guard.Against.Null(new ObservableCollection<Ride>(_rideRepository.GetAll()));
    }

    public void CheckRides()
    {
        Rides = Guard.Against.Null(new ObservableCollection<Ride>(_rideRepository.GetAll()));
        foreach (var ride in Rides)
        {
            if (ride.Students.Count() == 0)
                _rideRepository.RemoveRide(ride);
        }
    }

    public RelayCommand RemoveRideCommand
    {
        get => new(() =>
        {
            App._rideRepository.RemoveRide(_selectedRide);

            Rides.Remove(_selectedRide);
        });
    }

    public RelayCommand EditRideCommand
    {
        get => new(() =>
        {
            var viewModel = App._container.GetInstance<EditRideViewModel>();
            viewModel.Ride = _selectedRide;
            viewModel.Students = new ObservableCollection<Student>(App._studentRepository.GetStudentQuery(s => s.RideId == null));
            viewModel.TempStudents = new ObservableCollection<Student>(SelectedRide.Students);
            viewModel.StudentCount = viewModel.TempStudents.Count;
            viewModel.Drivers.Clear();
            viewModel.Drivers.Add(App._driverRepository.GetDriverById(SelectedRide.Driver.Id));
            _navigationService.NavigateTo<EditRideViewModel>();
        });
    }

}