using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class EditStudentViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    public Class Class { get; set; }
    public Parent Parent { get; set; }
    public Student Student { get; set; }
    public List<Class> Classes { get; set; }
    public List<Parent> Parents { get; set; }

    public EditStudentViewModel(INavigationService navigationService)
    {
        _navigationService = Guard.Against.Null(navigationService);
    }

    public RelayCommand SaveCommand
    {
        get => new(() =>
        {
            try
            {
                if (Student?.FirstName != string.Empty && Student?.LastName != string.Empty && Student?.Address != string.Empty && Class is not null && Parent is not null)
                {
                    Student.ClassId = Class.Id;
                    Student.ParentId = Parent.Id;
                    App._studentRepository.UpdateStudent(Student);
                    _navigationService.NavigateTo<StudentViewModel>();
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