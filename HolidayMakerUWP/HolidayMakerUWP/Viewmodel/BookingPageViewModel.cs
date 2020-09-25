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
        public double totalDate;
        public double isAllInclusive;
        public string startDate = FrontPageSearchViewModel.Search.StartDate.UtcDateTime.ToString("yyyy-MM-dd");
        public string endDate = FrontPageSearchViewModel.Search.EndDate.UtcDateTime.ToString("yyyy-MM-dd");


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
        public async void bookingMessage()
        {
            ContentDialog contentDialog = new ContentDialog()
            {
                Title = "Bokningnen genomfördes",
                Content = "Din bokning gemonfördes och du kommer nu återgå till första sidan.",
                CloseButtonText = "Ok."
            };
            await contentDialog.ShowAsync();
        }

        public void updateTotalPrice()
        {
            totalPrice = 0;
            totalDate = (FrontPageSearchViewModel.Search.EndDate.Date - FrontPageSearchViewModel.Search.StartDate.Date).TotalDays;
            foreach (Room i in SelectedRooms)
            {
                totalPrice += i.Price * totalDate; 
            }
            checkAllInclusive();
            totalPrice += isAllInclusive;
        }
        public void checkAllInclusive()
        {
            isAllInclusive = 0;
            foreach (Room r in _selectedRooms)
            {
                if (r.IsAllInclusive == true)
                {
                    isAllInclusive += 900;
                }
                if (r.IsFullBoard == true) 
                {
                    isAllInclusive += 150;
                }
                if (r.IsHalfBoard == true)
                {
                    isAllInclusive += 200;
                }
                if (r.ExtraBed == true)
                {
                    isAllInclusive += 100;
                }
            }
        }
    }
}
