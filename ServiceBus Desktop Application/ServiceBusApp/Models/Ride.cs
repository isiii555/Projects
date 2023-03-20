using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Models
{
    public class Ride : INotifyPropertyChanged
    {
        public bool ToSchool { get; set; } = true;

        public string SchoolAdress { get; set; } = "Shaki";

        private Driver driver = new();
        private DateTime creationTime;

        public DateTime CreationTime { get => creationTime; set { creationTime = value;
                PropertyChanging();
            } }

        public Driver Driver
        {
            get => driver;
            set
            {
                driver = value;
                PropertyChanging();
            }
        }
        public ObservableCollection<Student> Students { get; set; } = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        void PropertyChanging([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
