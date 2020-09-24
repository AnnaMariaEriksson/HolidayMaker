using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HolidayMakerUWP.Views
{
    public sealed partial class ChangeBookingDialog : ContentDialog
    {
        public static Booking tempBooking;
        public ChangeBookingDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if(inputAdress.Text != "" && inputPhoneNumber.Text != "")
            {
                tempBooking.Adress = inputAdress.Text;
                tempBooking.PhoneNumber = inputPhoneNumber.Text;

                Task.Run(() => HotelsService.UpdateBooking(tempBooking));
            }
            else if (inputAdress.Text != "")
            {
                tempBooking.Adress = inputAdress.Text;
                Task.Run(() => HotelsService.UpdateBooking(tempBooking));
            }
            else if (inputPhoneNumber.Text != "")
            {
                tempBooking.PhoneNumber = inputPhoneNumber.Text;
                Task.Run(() => HotelsService.UpdateBooking(tempBooking));
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void TextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
