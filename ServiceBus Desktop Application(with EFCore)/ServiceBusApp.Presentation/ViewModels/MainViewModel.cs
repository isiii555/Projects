using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using ServiceBusApp.Presentation.Messages;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    private ViewModelBase currentViewModel;
    public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }

    public MainViewModel(
        INavigationService navigationService,
        IMessenger messenger
    )
    {
        _navigationService = Guard.Against.Null(navigationService);

        messenger.Register<NavigationMessage>(this,
            message =>
            {
                var viewModel = App._container.GetInstance(message.ViewModelType) as ViewModelBase;
                CurrentViewModel = viewModel;
            });
    }

    public RelayCommand ClassPageCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<ClassViewModel>();
        });
    }

    public RelayCommand StudentPageCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<StudentViewModel>();
        });
    }

    public RelayCommand ParentPageCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<ParentViewModel>();
        });
    }

    public RelayCommand RidePageCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<RideViewModel>();
        });
    }

    public RelayCommand CarPageCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<CarViewModel>();
        });
    }

    public RelayCommand DriverPageCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<DriverViewModel>();
        });
    }
    public RelayCommand RidesPageCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<RidesViewModel>();
        });
    }
}