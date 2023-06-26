using System.Collections.ObjectModel;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class ClassViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private ObservableCollection<Class> classes;
    private IClassRepository _classRepository;

    public Class Class { get; set; }
    public ObservableCollection<Class> Classes { get => classes; set => Set(ref classes, value); }
    public ClassViewModel(INavigationService navigationService,IClassRepository classRepo)
    {
        _classRepository = Guard.Against.Null(classRepo);
        _navigationService = Guard.Against.Null(navigationService);
        Classes = _classRepository != null ? new ObservableCollection<Class>(_classRepository.GetAll()) : new ObservableCollection<Class>();
    }
    public RelayCommand AddClassCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<AddClassViewModel>();
        });
    }

    public RelayCommand EditClassCommand
    {
        get => new(() =>
        {
            App._container.GetInstance<EditClassViewModel>().Class = Class;
            _navigationService.NavigateTo<EditClassViewModel>();
            Classes = new ObservableCollection<Class>(App._classRepository.GetAll());
        });
    }

    public RelayCommand RemoveClassCommand
    {
        get => new(() =>
        {
            _classRepository.RemoveClass(Class);
            Classes = new ObservableCollection<Class>(_classRepository.GetAll());

        });
    }
}