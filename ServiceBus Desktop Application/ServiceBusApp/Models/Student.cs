using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Models
{
    public class Student : INotifyPropertyChanged
    {
        private string name;

        private string surname;

        private string parentName;

        private string schoolNumber;

        private int personalId;

        private string adress;

        public string Name
        {
            get => name; set
            {
                name = value;
                PropertyChanging();
            }
        }

        public string Surname
        {
            get => surname; set
            {
                surname = value;
                PropertyChanging();
            }
        }

        public string ParentName
        {
            get => parentName;
            set
            {
                parentName = value;
                PropertyChanging();
            }
        }

        public string SchoolNumber
        {
            get => schoolNumber;
            set
            {
                schoolNumber = value;
                PropertyChanging();
            }
        }

        public int PersonalId
        {
            get => personalId;
            set
            {
                personalId = value;
                PropertyChanging();
            }
        }

        public string Adress 
        { 
            get => adress; 
            set 
            { 
                adress = value;
                PropertyChanging();

            } 
        }

        public Student()
        {

        }

        public Student(string name,string surname,string parentName,string schoolNumber,int Id,string adress)
        {
            Name = name;
            Surname = surname;
            ParentName = parentName;
            SchoolNumber = schoolNumber;
            PersonalId = Id;
            Adress = adress;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void PropertyChanging([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
