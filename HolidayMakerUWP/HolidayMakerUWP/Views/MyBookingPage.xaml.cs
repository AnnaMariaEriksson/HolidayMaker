using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            myBookingPageViewModel.DeleteBooking((Booking)listView.SelectedItem);
            myBookingPageViewModel.NewBookings.Remove((Booking)listView.SelectedItem);
        }

        private async void changeBookingInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeBookingDialog.tempBooking = (Booking)listView.SelectedItem;
            await new ChangeBookingDialog().ShowAsync();
        }
    }
}
