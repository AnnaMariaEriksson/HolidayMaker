using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Viewmodel
{
    public class LogInViewModel : INotifyPropertyChanged
    {
        public User _user { get; set; }
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                User = value;
                NotifyPropertyChanged("User");
            }
        }
        public LogInViewModel()
        {
        }
        public void GetUser(string email, string password)
        {
            User = Task.Run(() => HotelsService.GetUser(email, password)).Result;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
