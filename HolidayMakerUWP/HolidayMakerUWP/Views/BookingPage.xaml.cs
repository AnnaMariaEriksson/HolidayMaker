using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
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
    public sealed partial class BookingPage : Page
    {
        HotelsService hotelsService;
        BookingPageViewModel bookingPageViewModel;
       
        public BookingPage()
        {
            this.InitializeComponent();
            this.bookingPageViewModel = new BookingPageViewModel();
        }

        private void ConfirmBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (TeleNummer.Text == "" || Adress.Text == "")
            //    bookingPageViewModel.ErrorFillAllFields();

            //else
            //    bookingPageViewModel.BookingMessageDialog();

            //Task.Run.PostBooking(bookingPageViewModel._selectedRooms, DateTime.Now, DateTime.Now));

            Task.Run(() => HotelsService.PostBooking(bookingPageViewModel._selectedRooms, FrontPageSearchViewModel.Search.StartDate, DateTime.Now));
        }

        private void TeleNummer_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void RemoveRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            bookingPageViewModel.SelectedRooms.Remove((Room)RoomListView.SelectedItem);
            bookingPageViewModel.updateTotalPrice();

            if (bookingPageViewModel.totalPrice != 0)
                totalSumman.Text = "Total priset:" + " " + bookingPageViewModel.totalPrice.ToString() + "Kr";

            else
                totalSumman.Text = "";

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            bookingPageViewModel._selectedRooms = (ObservableCollection<Room>)e.Parameter;

            bookingPageViewModel.updateTotalPrice();
            totalSumman.Text = "Total priset:" + " " + bookingPageViewModel.totalPrice.ToString() + "Kr";
        }

        
    }
}
