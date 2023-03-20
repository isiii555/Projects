using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ServiceBusApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBusApp.ViewModels.StudentViewModel
{
    public class AddStudentViewModel : ViewModelBase
    {
        private Student student = new();

        public ObservableCollection<Student> Students;

        public Window CurrentWindow { get; set; }

        public AddStudentViewModel(ObservableCollection<Student> students,Window window)
        {
            CurrentWindow = window;
            Students = students;
        }

        public Student Student
        {
            get { return student; }
            set { Set(ref student, value); }
        }

        public RelayCommand CreateCommand
        {
            get => new RelayCommand(() =>
            {
                if (Student.Name != string.Empty && Student.ParentName != string.Empty && Student.Adress != string.Empty && Student.Surname != string.Empty && Student.PersonalId > 0 && Student.SchoolNumber != string.Empty)
                {
                    Students.Add(Student);
                    CurrentWindow.Close();
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }
    }
}
