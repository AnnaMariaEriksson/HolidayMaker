using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Viewmodel
{
    public class MyBookingViewModel
    {
        public Room tempOb = new Room();

        ObservableCollection<Booking> _newBookings { get; set; }
        public ObservableCollection<Booking> NewBookings { get { return _newBookings; } set { _newBookings = value; } }

        ObservableCollection<Booking> _oldBookings { get; set; }
        public ObservableCollection<Booking> OldBookings { get { return _oldBookings; } set { _oldBookings = value; } }

        public void GetUserBookings()
        {
            _newBookings = Task.Run(() => HotelsService.GetNewBookings(LogInViewModel.User.ID)).Result;
            _oldBookings = Task.Run(() => HotelsService.GetOldBookings(LogInViewModel.User.ID)).Result;
           
            //foreach (Booking b in _newBookings)
            //{
            //    tempOb = b.Room;
            //}                        
        }
    }   
}
