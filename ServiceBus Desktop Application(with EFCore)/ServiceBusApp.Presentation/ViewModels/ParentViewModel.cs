using System.Collections.ObjectModel;
using System.Linq;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class ParentViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private ObservableCollection<Parent> _parents;

    public Parent Parent { get; set; }
    public ObservableCollection<Parent> Parents { get => _parents; set => Set(ref _parents, value); }


    public ParentViewModel(INavigationService navigationService)
    {
        _navigationService = Guard.Against.Null(navigationService);
        Parents = App._parentRepository != null ? new ObservableCollection<Parent>(App._parentRepository.GetAll()) : new ObservableCollection<Parent>();
    }


    public RelayCommand AddParentCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<AddParentViewModel>();
        });
    }

    public RelayCommand EditParentCommand
    {
        get => new(() =>
        {
            App._container.GetInstance<EditParentViewModel>().Parent = Parent;
            _navigationService.NavigateTo<EditParentViewModel>();
            Parents = new ObservableCollection<Parent>(App._parentRepository.GetAll().ToList());
        });
    }

    public RelayCommand RemoveParentCommand
    {
        get => new(() =>
        {
            App._parentRepository.RemoveParent(Parent);
            Parents = new ObservableCollection<Parent>(App._parentRepository.GetAll());
        });
    }
}