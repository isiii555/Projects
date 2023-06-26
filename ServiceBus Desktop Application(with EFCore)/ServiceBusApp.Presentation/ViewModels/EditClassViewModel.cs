using System;
using System.Windows;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class EditClassViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    public Class Class { get; set; }


    public EditClassViewModel(INavigationService navigationService)
    {
        _navigationService = Guard.Against.Null(navigationService);
    }


    public RelayCommand SaveCommand
    {
        get => new(() =>
        {
            try
            {
                if (Class.Name != string.Empty)
                {
                    App._classRepository.UpdateClass(Class);
                    _navigationService.NavigateTo<ClassViewModel>();
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show("Data not modified!", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });
    }
}