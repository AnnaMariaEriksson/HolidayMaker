using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
        BookingPageViewModel bookingPageViewModel;
        public RoomSelectionVm roomSelectionVm;
        public ObservableCollection<Room> tempRoom = new ObservableCollection<Room>();
        public BookingPage()
        {
            this.InitializeComponent();
            this.bookingPageViewModel = new BookingPageViewModel();
            this.roomSelectionVm = new RoomSelectionVm();
            tempRoom = roomSelectionVm.RoomBasket;

        }

        private void ConfirmBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TeleNummer.Text == "" || Adress.Text == "")           
                bookingPageViewModel.ErrorFillAllFields();
            
            else
                bookingPageViewModel.BookingMessageDialog();               
        }

        private void TeleNummer_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
                args.Cancel = args.NewText.Any(c => !char.IsDigit(c));            
        }

        private void RemoveRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            roomSelectionVm.RoomBasket.Remove((Room)RoomListView.SelectedItem);
        }
    }
}
