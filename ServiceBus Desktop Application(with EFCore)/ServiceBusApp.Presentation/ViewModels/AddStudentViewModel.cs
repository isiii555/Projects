using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Ardalis.GuardClauses;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class AddStudentViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IClassRepository _classRepository;
    private readonly IParentRepository _parentRepository;


    private List<Class> classes;
    private List<Parent> parents;

    private Class _class;
    private Parent _parent;
    private Student _student;

    public Class Class { get => _class; set => Set(ref _class, value); }
    public Parent Parent { get => _parent; set => Set(ref _parent, value); }
    public Student Student { get => _student; set => Set(ref _student, value); }
    public List<Class> Classes { get => classes; set => Set(ref classes, value); }
    public List<Parent> Parents { get => parents; set => Set(ref parents, value); }


    public AddStudentViewModel(INavigationService navigationService, 
        IClassRepository classRepository,
        IParentRepository parentRepository
    )
    {
        _navigationService = Guard.Against.Null(navigationService);
        _classRepository = Guard.Against.Null(classRepository);
        _parentRepository = Guard.Against.Null(parentRepository);
        Classes = Guard.Against.Null(_classRepository.GetAll().ToList());
        Parents = Guard.Against.Null((_parentRepository.GetAll().ToList()));
        Student = Guard.Against.Null(new Student());
    }


    public RelayCommand CreateCommand
    {
        get => new(() =>
        {
            try
            {
                if (Student.FirstName != string.Empty && Student.LastName != string.Empty && Student.Address != string.Empty && Class is not null && Parent is not null)
                {
                    Student.ClassId = Class.Id;
                    Student.ParentId = Parent.Id;

                    App._studentRepository.AddStudent(Student);

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