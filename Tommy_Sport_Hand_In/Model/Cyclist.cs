using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tommy_Sport_Hand_In.Model
{

    public class Cyclist : INotifyPropertyChanged
    {
        private string name;
        private string gender;
        private String country;
        private double resultTime;
        private int endPosition;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }


        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        public double ResultTime
        {
            get
            {
                return resultTime;
            }
            set
            {
                resultTime = value;
                OnPropertyChanged("ResultTime");
            }
        }

        public int EndPosition
        {
            get
            {
                return endPosition;
            }
            set
            {
                endPosition = value;
                OnPropertyChanged("EndPosition");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
