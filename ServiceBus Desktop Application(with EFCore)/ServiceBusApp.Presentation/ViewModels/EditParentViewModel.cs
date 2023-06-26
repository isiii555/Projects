using System;
using System.Windows;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class EditParentViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    private Parent _parent;
    public Parent Parent { get => _parent;set => Set(ref _parent, value); }
    public EditParentViewModel(INavigationService navigationService)
    {
        _navigationService = Guard.Against.Null(navigationService);
    }
    public RelayCommand SaveCommand
    {
        get => new(() =>
        {
            try
            {
                if (Parent?.FirstName != string.Empty && Parent?.LastName != string.Empty && Parent.Username != string.Empty && Parent.PhoneNumber != string.Empty && Parent.Password != string.Empty)
                {
                    App._parentRepository.UpdateParent(Parent);
                    _navigationService.NavigateTo<ParentViewModel>();
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