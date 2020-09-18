using System;
using System.Collections.Generic;
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
using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HolidayMakerUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPageViewModel RegistrationPageViewModel { get; set; }
        public RegistrationPage()
        {
            this.InitializeComponent();
            RegistrationPageViewModel = new RegistrationPageViewModel();
            //this DataContext = RegistrationPageViewModel.Users;
        }

        private async void AddUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            var users = RegistrationPageViewModel.Users;
            var user = new User
            {
                FirstName = FirstNameField.Text,
                LastName = LastNameField.Text,
                Email = EmailField.Text,
                Password = PasswordField.Text
            };
            users.Add(user);
            user = await HotelsService.AddUsersAsync(user);

            this.Frame.Navigate(typeof(FrontPageSearch));
        }
    }
}
