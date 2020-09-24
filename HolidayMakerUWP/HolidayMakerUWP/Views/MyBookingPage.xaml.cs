using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HolidayMakerUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyBookingPage : Page
    {
        public MyBookingViewModel myBookingPageViewModel;

        

        public MyBookingPage()
        {
            this.InitializeComponent();
            this.myBookingPageViewModel = new MyBookingViewModel();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            myBookingPageViewModel.GetUserBookings();
        }

        private void cancelBooking_Click(object sender, RoutedEventArgs e)
        {
            
            myBookingPageViewModel.DeleteBooking(MyBookingViewModel.SelectedBooking);
            myBookingPageViewModel.NewBookings.Remove(MyBookingViewModel.SelectedBooking);
        }

        private void bookingHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyBookingViewModel.SelectedBooking = (Booking)bookingHistory.SelectedItem;
            cancelBooking.Visibility = Visibility.Collapsed;
            BookingIdText.Text = MyBookingViewModel.SelectedBooking.BookingID.ToString();
            BookingPhoneNumberText.Text = MyBookingViewModel.SelectedBooking.PhoneNumber;
            BookingAdressText.Text = MyBookingViewModel.SelectedBooking.Adress;
            BookingStartDateText.Text = MyBookingViewModel.SelectedBooking.StartDate.UtcDateTime.ToString("yyyy-MM-dd");
            BookingEndDateText.Text = MyBookingViewModel.SelectedBooking.EndDate.UtcDateTime.ToString("yyyy-MM-dd");
            BookingRoomNameText.Text = MyBookingViewModel.SelectedBooking.BookedRoom.RoomName;
            BookingRoomPriceText.Text = MyBookingViewModel.SelectedBooking.BookedRoom.Price.ToString();
        }

        private void bookingsNew_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyBookingViewModel.SelectedBooking = (Booking)bookingsNew.SelectedItem;
            cancelBooking.Visibility = Visibility.Visible;
            BookingIdText.Text = MyBookingViewModel.SelectedBooking.BookingID.ToString();
            BookingPhoneNumberText.Text = MyBookingViewModel.SelectedBooking.PhoneNumber;
            BookingAdressText.Text = MyBookingViewModel.SelectedBooking.Adress;
            BookingStartDateText.Text = MyBookingViewModel.SelectedBooking.StartDate.UtcDateTime.ToString("yyyy-MM-dd");
            BookingEndDateText.Text = MyBookingViewModel.SelectedBooking.EndDate.UtcDateTime.ToString("yyyy-MM-dd");
            BookingRoomNameText.Text = MyBookingViewModel.SelectedBooking.BookedRoom.RoomName;
            BookingRoomPriceText.Text = MyBookingViewModel.SelectedBooking.BookedRoom.Price.ToString();

        }

        private async void changeBookingInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            //ChangeBookingDialog.tempBooking = (Booking)listView.SelectedItem;
            await new ChangeBookingDialog().ShowAsync();
        }
    }
}
