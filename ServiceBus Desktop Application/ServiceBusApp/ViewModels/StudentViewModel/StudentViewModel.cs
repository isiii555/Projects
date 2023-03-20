using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Models;
using ServiceBusApp.Views.StudentView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBusApp.ViewModels.StudentViewModel
{
    public class StudentViewModel : ViewModelBase
    {
        public ObservableCollection<Student>? Students { get; set; }

        public Student SelectedStudent { get; set; }

        public StudentViewModel(ObservableCollection<Student>? students)
        {
            Students = students;
        }

        public RelayCommand AddStudentCommand { get => new RelayCommand(() =>
            {
                Window window = App.Container.GetInstance<AddStudentView>();
                window.DataContext = new AddStudentViewModel(Students,window);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.Show();
            });
        }
        public RelayCommand EditStudentCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = App.Container.GetInstance<EditStudentView>();
                window.DataContext = new EditStudentViewModel(SelectedStudent,window);
                window.Show();
            });
        }

        public RelayCommand RemoveStudentCommand
        {
            get => new RelayCommand(() =>
            {
                Students.Remove(SelectedStudent);
            });
        }
    }
}
