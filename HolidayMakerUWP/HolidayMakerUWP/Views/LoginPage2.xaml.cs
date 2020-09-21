using HolidayMakerUWP.Viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class LoginPage2 : Page
    {
        LogInViewModel Vm { get; set; }
        public LoginPage2()
        {
            this.InitializeComponent();
            this.Vm = new LogInViewModel();
        }

        private async void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var email = usernamebox.Text.ToLower();
            var password = passwordbox.Password.ToLower();
            Vm.GetUser(email, password);
            if(LogInViewModel.User == null)
            {
                MessageDialog confirmDialog = new MessageDialog("Your login credentials don't match an account in our system.", "ERROR");
                confirmDialog.Commands.Add(new UICommand("OK"));
                var confirmResult = await confirmDialog.ShowAsync();
                // "No" button pressed: Keep the app open.
                if (confirmResult != null && confirmResult.Label == "OK") { return; }
            }
            else
            {
                this.Frame.Navigate(typeof(FrontPageSearch));
            }
        }
    }
}
