using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Models
{
    public class Car : INotifyPropertyChanged
    {
        private string model;

        public string Model 
        { 
            get => model;
            set { 
                model = value;
                PropertyChanging();
            }
        }

        private string vendor;

        public string Vendor
        {
            get => vendor;
            set
            {
                vendor = value;
                PropertyChanging();
            }
        }

        private string serialNumber;

        public string SerialNumber
        {
            get => serialNumber;
            set
            {
                serialNumber = value;
                PropertyChanging();
            }
        }

        private int seatCount;

        public int SeatCount
        {
            get => seatCount;
            set
            {
                seatCount = value;
                PropertyChanging();
            }
        }
        public Car()
        {

        }
        public Car(string model, string vendor, string serialNumber,int seatCount)
        {
            Model = model;
            Vendor = vendor;
            SerialNumber = serialNumber;
            SeatCount = seatCount;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void PropertyChanging([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
