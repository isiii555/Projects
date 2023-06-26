using System.Collections.ObjectModel;
using System.Linq;
using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.ViewModels;

public class StudentViewModel : ViewModelBase
{
    private readonly IStudentRepository _studentRepository;
    private readonly INavigationService _navigationService;
    private ObservableCollection<Student> _students;
    public Student Student { get; set; }
    public ObservableCollection<Student> Students { get => _students; set => Set(ref _students, value); }


    public StudentViewModel(
        INavigationService navigationService,
        IStudentRepository studentRepository
    )
    {
        _navigationService = Guard.Against.Null(navigationService);
        _studentRepository = Guard.Against.Null(studentRepository);
        _students = Guard.Against.Null(new ObservableCollection<Student>(this._studentRepository.GetAll()));
    }


    public RelayCommand AddStudentCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<AddStudentViewModel>();
        });
    }

    public RelayCommand EditStudentCommand
    {
        get => new(() =>
        {
            var viewModel = App._container.GetInstance<EditStudentViewModel>();
            viewModel.Student = Student;
            viewModel.Parents = App._parentRepository.GetAll().ToList();
            viewModel.Classes = App._classRepository.GetAll().ToList();
            _navigationService.NavigateTo<EditStudentViewModel>();
        });
    }

    public RelayCommand RemoveStudentCommand
    {
        get => new(() =>
        {
            _studentRepository.RemoveStudent(Student);
            _students = new ObservableCollection<Student>(_studentRepository.GetAll());
        });
    }
}