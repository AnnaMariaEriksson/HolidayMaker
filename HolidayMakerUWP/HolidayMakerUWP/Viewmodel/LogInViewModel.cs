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
        HotelsService hotelsService;
        public LogInViewModel()
        {
            this.hotelsService = new HotelsService();
            User = Task.Run(() => hotelsService.GetUser()).Result;

        }
        public void GetUser()
        {
            
        }
    }
}
