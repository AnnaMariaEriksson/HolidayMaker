using HolidayMakerUWP.DAL;
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
        HotelsService hotelServiceDal;
        public double totalPrice;
        public User user1 { get { return hotelServiceDal.GetUser(); } set { user1 = value; } }

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
        public BookingPageViewModel()
        {
            this.hotelServiceDal = new HotelsService();
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
