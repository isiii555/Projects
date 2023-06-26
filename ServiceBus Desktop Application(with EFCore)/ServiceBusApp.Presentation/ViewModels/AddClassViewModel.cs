using System;
using System.Windows;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class AddClassViewModel : ViewModelBase
{
    private Class _class;
    private readonly INavigationService _navigationService;
    private readonly IClassRepository _classRepository;
    public Class Class { get => _class; set => Set(ref _class, value); }

    public AddClassViewModel(
        INavigationService navigationService,
        IClassRepository classRepository
    )
    {
        _class = Guard.Against.Null(new Class());
        _navigationService = Guard.Against.Null(navigationService);
        _classRepository = Guard.Against.Null(classRepository);
    }


    public RelayCommand CreateCommand
    {
        get => new(() =>
        {
            try
            {
                if (_class.Name != string.Empty)
                {
                    _classRepository.AddClass(_class);
                    _navigationService.NavigateTo<ClassViewModel>();
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        });
    }
}