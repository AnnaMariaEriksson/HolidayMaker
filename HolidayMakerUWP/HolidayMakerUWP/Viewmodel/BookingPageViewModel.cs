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
        public double totalPrice;
        public ObservableCollection<Room> _selectedRooms { get; set; }
        public ObservableCollection<Room> SelectedRooms
        {
            get
            {
                return _selectedRooms;
            }
            set
            {
                _selectedRooms = value;
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

        public void updateTotalPrice()
        {
            totalPrice = 0;
            foreach (Room i in SelectedRooms)
            {
                totalPrice += i.Price; 
            }
        }
    }
}
