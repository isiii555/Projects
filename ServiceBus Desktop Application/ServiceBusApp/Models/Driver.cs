using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Models
{
    public class Driver : INotifyPropertyChanged
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value;
                PropertyChanging();
            }
		}

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value;
                PropertyChanging();
            }
        }

        private string adress;

        public string Adress
        {
            get { return adress; }
            set
             {
                adress = value;
                PropertyChanging();
            }
        }

        private Car car;

        public Car Car
        {
            get { return car; }
            set { car = value;
                PropertyChanging();
            }
        }

        public Driver()
        {

        }

        public Driver(string name,string surname,string adress,Car car) 
        {
            Name = name;
            Surname = surname;
            Adress = adress;
            Car = car;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void PropertyChanging([CallerMemberName]string? name = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }
    }
}
