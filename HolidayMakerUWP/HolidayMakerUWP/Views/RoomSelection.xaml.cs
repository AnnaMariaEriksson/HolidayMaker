﻿using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
using Newtonsoft.Json;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HolidayMakerUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RoomSelection : Page
    {
        public RoomSelectionVm Vm;
        public RoomSelection()
        {
            this.InitializeComponent();
            this.Vm = new RoomSelectionVm();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Vm._selectedhotel = (Hotel)e.Parameter;
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            //temporärt det ska lägga i MenuFlyout_Opening
            LogInButton.Visibility = Visibility.Collapsed;
            RegisterButton.Visibility = Visibility.Collapsed;
            MyBookingsButton.Visibility = Visibility.Visible;
            LogoutButton.Visibility = Visibility.Visible;
            /////////////////////////////////////////////
        }

        private void MenuFlyout_Opening(object sender, object e)
        {
            //kolla om användaren är inloggad och lägg rätt knappar
        }
    }
}
