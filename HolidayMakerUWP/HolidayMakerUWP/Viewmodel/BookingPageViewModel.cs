using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace HolidayMakerUWP.Viewmodel
{
    public class BookingPageViewModel
    {
        public ObservableCollection<Room> _rooms { get; set; }
        public ObservableCollection<Room> Rooms
        {
            get
            {
                return _rooms;
            }
            set
            {
                _rooms = value;
            }
        }

        public async void BookingMessageDialog()
        {
            ContentDialog endBookingDialog = new ContentDialog()
            {
                Title = "Booking ",
                Content = "Check connection and try again.",
                CloseButtonText = "Ok"
            };

            await endBookingDialog.ShowAsync();
        }
        public async void ErrorFillAllFields()
        {
            ContentDialog errorDialog = new ContentDialog()
            {
                Title = "Error",
                Content = "Please fill in all fields",
                CloseButtonText = "Ok"
            };
            await errorDialog.ShowAsync();
        }
    }
}
