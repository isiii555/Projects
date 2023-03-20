using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBusApp.ViewModels.StudentViewModel
{
    public class EditStudentViewModel : ViewModelBase
    {
        public Student? Student { get; set; }

        public Student? TempStudent { get; set; }

        public Window CurrentWindow { get; set; }

        public EditStudentViewModel(Student? tempStudent,Window window)
        {
            Student = new();
            CurrentWindow = window;
            TempStudent = tempStudent;
            Student.Name = tempStudent.Name;
            Student.Surname = tempStudent.Surname;
            Student.ParentName = tempStudent.ParentName;
            Student.Adress = tempStudent.Adress;
            Student.PersonalId = tempStudent.PersonalId;
            Student.SchoolNumber = tempStudent.SchoolNumber;

        }

        public RelayCommand SaveCommand
        {
            get => new RelayCommand(
            () =>
            {
                if (Student.Name != string.Empty && Student.ParentName != string.Empty && Student.Adress != string.Empty && Student.Surname != string.Empty && Student.PersonalId > 0 && Student.SchoolNumber != string.Empty)
                {
                    TempStudent.Name = Student.Name;
                    TempStudent.Surname = Student.Surname;
                    TempStudent.ParentName = Student.ParentName;
                    TempStudent.Adress = Student.Adress;
                    TempStudent.SchoolNumber = Student.SchoolNumber;
                    TempStudent.PersonalId = Student.PersonalId;
                    CurrentWindow.Close();
                }

                else
                {
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
