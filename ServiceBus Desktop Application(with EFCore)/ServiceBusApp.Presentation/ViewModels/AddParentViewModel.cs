using System;
using System.Windows;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class AddParentViewModel : ViewModelBase
{
    private readonly IParentRepository _parentRepository;
    private readonly INavigationService _navigationService;
    private Parent _parent;
    public Parent Parent { get => _parent; set => Set(ref _parent, value); }


    public AddParentViewModel(
        INavigationService navigationService,
        IParentRepository parentRepository
    )
    {
        _navigationService = Guard.Against.Null(navigationService);
        _parentRepository = Guard.Against.Null(parentRepository);
        _parent = Guard.Against.Null(new Parent());
    }


    public RelayCommand CreateCommand
    {
        get => new(() =>
        {
            try
            {
                if (_parent.FirstName != string.Empty && _parent.LastName != string.Empty && _parent.Username != string.Empty && _parent.Password != string.Empty && _parent.PhoneNumber != string.Empty)
                {
                    _parentRepository.AddParent(_parent);
                    _navigationService.NavigateTo<ParentViewModel>();
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show("Data not inserted", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });
    }
}