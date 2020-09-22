using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Viewmodel
{
    public class BasePageVm
    {
        public User _tempUser { get; set; }
        public User TempUser
        {
            get
            {
                return TempUser;
            }
            set
            {
                TempUser = value;
            }

        }
        public BasePageVm()
        {

        }
    }
}
