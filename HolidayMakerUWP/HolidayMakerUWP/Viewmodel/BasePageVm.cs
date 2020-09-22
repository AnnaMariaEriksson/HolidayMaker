using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Viewmodel
{
    public class BasePageVm
    {
        public LogInViewModel Vm;
        public User _tempUser { get; set; }
        public User TempUser
        {
            get
            {
                return _tempUser;
            }
            set
            {
                _tempUser = value;
            }

        }
        public BasePageVm()
        {
        }
}
}
