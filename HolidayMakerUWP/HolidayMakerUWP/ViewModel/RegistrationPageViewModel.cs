using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayMakerUWP.Model;

namespace HolidayMakerUWP.Viewmodel
{
    public class RegistrationPageViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public User User { get; set; }

        public RegistrationPageViewModel()
        {
            Users = new ObservableCollection<User>();
        }
    }
}
