using HolidayMakerUWP.Viewmodel;
using System;
using System.Collections.Generic;
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
        public BookingPage()
        {
            this.InitializeComponent();
            bookingPageViewModel = new BookingPageViewModel();
        }

        private async void ConfirmBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex obj = new Regex(TeleNummer.Text);
            if (TeleNummer.Text == "" || Adress.Text == "")
            {
                ContentDialog errorDialog = new ContentDialog()
                {
                    Title = "Error",
                    Content = "Please fill in all fields",
                    CloseButtonText = "Ok"
                };
                await errorDialog.ShowAsync();
            }
            else
                bookingPageViewModel.BookingMessageDialog();               
        }
        private void TeleNummer_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
                args.Cancel = args.NewText.Any(c => !char.IsDigit(c));            
        }
    }
}
