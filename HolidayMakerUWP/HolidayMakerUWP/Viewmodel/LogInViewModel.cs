using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Viewmodel
{
    public class LogInViewModel
    {        
        public User User { get; set; }
        public LogInViewModel()
        {       
            
        }
        public void GetUser(string email, string password)
        {
            User = Task.Run(() => HotelsService.GetUser(email, password)).Result;
        }
    }
}
