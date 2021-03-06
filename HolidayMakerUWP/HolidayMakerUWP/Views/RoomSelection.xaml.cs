﻿using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class RoomSelection : Page
    {
        public bool BtnClicked = true;
        public FrontPageSearchViewModel FPSVm { get; set; }
        public RoomSelectionVm Vm { get; set; }
        public HotelsService ServiceVm;
        public RoomSelection()
        {
            this.InitializeComponent();
            this.Vm = new RoomSelectionVm();
            RegionsButton.Content = FrontPageSearchViewModel.Search.Regions.NameOfRegion;
            CityButton.Content = FrontPageSearchViewModel.Search.Cities.NameOfCity;
            StartDateButton.Content = FrontPageSearchViewModel.Search.StartDate.UtcDateTime.ToString("yyyy-MM-dd");
            EndDateButton.Content = FrontPageSearchViewModel.Search.EndDate.UtcDateTime.ToString("yyyy-MM-dd");
            CheckLoginState();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Vm._selectedhotel = HotelsService.SelectedHotel;
            Vm.GetFascilities();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegistrationPage));
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage2));
        }

        private void MenuFlyout_Opening(object sender, object e)
        {
            //kolla om användaren är inloggad och lägg rätt knappar
        }

        private async void roomToBasket_Click(object sender, RoutedEventArgs e)
        {
            if (LogInViewModel.User != null)
            {
                Room TempRoom = (Room)((FrameworkElement)sender).DataContext;
                Vm.AddRoomToBasket(TempRoom);
                Vm.Rooms.Remove(TempRoom);
            }
            if (LogInViewModel.User == null)
            {
                MessageDialog confirmDialog = new MessageDialog("Du måste vara inloggad för att välja ett rum", "ERROR");
                confirmDialog.Commands.Add(new UICommand("OK"));
                var confirmResult = await confirmDialog.ShowAsync();
                // "No" button pressed: Keep the app open.
                if (confirmResult != null && confirmResult.Label == "OK") { return; }
            }
        }

        private async void ConfirmChoosenRooms_Click(object sender, RoutedEventArgs e)
        {
            var SelectedRooms = Vm.RoomBasket;
            if (LogInViewModel.User != null)
            {
                Frame.Navigate(typeof(BookingPage), SelectedRooms);
            }
            if (LogInViewModel.User == null)
            {
                MessageDialog confirmDialog = new MessageDialog("Du måste vara inloggad för att genomföra bokningen", "ERROR");
                confirmDialog.Commands.Add(new UICommand("OK"));
                var confirmResult = await confirmDialog.ShowAsync();
                // "No" button pressed: Keep the app open.
                if (confirmResult != null && confirmResult.Label == "OK") { return; }
            }
        }

        private void Allinclusive_Click(object sender, RoutedEventArgs e)
        {
            if (((Room)((FrameworkElement)sender).DataContext).IsAllInclusive == false)
            {

              Room test = (Room)((FrameworkElement)sender).DataContext;
                test.IsAllInclusive = true;
                for (int i = 0; i < Vm.Rooms.Count; i++)
                {
                    if (Vm.Rooms[i] == test)
                    {
                        Vm.Rooms[i] = test;
                    }
                }
            }
            else
            {
                Room test = (Room)((FrameworkElement)sender).DataContext;
                test.IsAllInclusive = false;
                for (int i = 0; i < Vm.Rooms.Count; i++)
                {
                    if (Vm.Rooms[i] == test)
                    {
                        Vm.Rooms[i] = test;
                    }
                }
            }
        }

        private void FullBoard_Click(object sender, RoutedEventArgs e)
        {
            if (((Room)((FrameworkElement)sender).DataContext).IsFullBoard == false)
            {

                Room test1 = (Room)((FrameworkElement)sender).DataContext;
                test1.IsFullBoard = true;
                for (int i = 0; i < Vm.Rooms.Count; i++)
                {
                    if (Vm.Rooms[i] == test1)
                    {
                        Vm.Rooms[i] = test1;
                    }
                }
            }
            else
            {
                Room test1 = (Room)((FrameworkElement)sender).DataContext;
                test1.IsFullBoard = false;
                for (int i = 0; i < Vm.Rooms.Count; i++)
                {
                    if (Vm.Rooms[i] == test1)
                    {
                        Vm.Rooms[i] = test1;
                    }
                }
            }
        }

        private void HalfBoard_Click(object sender, RoutedEventArgs e)
        {
            if (((Room)((FrameworkElement)sender).DataContext).IsHalfBoard == false)
            {

                Room test1 = (Room)((FrameworkElement)sender).DataContext;
                test1.IsHalfBoard = true;
                for (int i = 0; i < Vm.Rooms.Count; i++)
                {
                    if (Vm.Rooms[i] == test1)
                    {
                        Vm.Rooms[i] = test1;
                    }
                }
            }
            else
            {
                Room test1 = (Room)((FrameworkElement)sender).DataContext;
                test1.IsHalfBoard = false;
                for (int i = 0; i < Vm.Rooms.Count; i++)
                {
                    if (Vm.Rooms[i] == test1)
                    {
                        Vm.Rooms[i] = test1;
                    }
                }
            }
        }

        private void ExtraBed_Click(object sender, RoutedEventArgs e)
        {
            if (((Room)((FrameworkElement)sender).DataContext).IsExtraBed == false)
            {

                Room test1 = (Room)((FrameworkElement)sender).DataContext;
                test1.IsExtraBed = true;
                for (int i = 0; i < Vm.Rooms.Count; i++)
                {
                    if (Vm.Rooms[i] == test1)
                    {
                        Vm.Rooms[i] = test1;
                    }
                }
            }
            else
            {
                Room test1 = (Room)((FrameworkElement)sender).DataContext;
                test1.IsExtraBed = false;
                for (int i = 0; i < Vm.Rooms.Count; i++)
                {
                    if (Vm.Rooms[i] == test1)
                    {
                        Vm.Rooms[i] = test1;
                    }
                }
            }
        }

        private void FilterRoomsByPrice_Click(object sender, RoutedEventArgs e)
        {
                if (BtnClicked == false)
                {
                    BtnClicked = true;
                    HotelsService.SortByInt = 1;
                Vm._rooms = Vm.SortByPrice(1);
                RoomListView.ItemsSource = Vm.Rooms;
                }

                else
                {
                    BtnClicked = false;
                    HotelsService.SortByInt = 2;
                Vm._rooms = Vm.SortByPrice(2);
                RoomListView.ItemsSource = Vm.Rooms;
            }           
        }

        private void EndDateButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FrontPageSearch));
        }

        private void StartDateButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FrontPageSearch));
        }

        private void RegionsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FrontPageSearch));
        }

        private void CityButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FrontPageSearch));
        }

        private void SortRoomsByRating_Click(object sender, RoutedEventArgs e)
        {
            if (BtnClicked == false)
            {
                BtnClicked = true;
                HotelsService.SortByInt = 1;
                Vm._rooms = Vm.SortByRating(1);
                RoomListView.ItemsSource = Vm.Rooms;
            }

            else
            {
                BtnClicked = false;
                HotelsService.SortByInt = 2;
                Vm._rooms = Vm.SortByRating(2);
                RoomListView.ItemsSource = Vm.Rooms;
            }
        }
        public void CheckLoginState()
        {
            if(LogInViewModel.User != null)
            {
                LogInButton.Visibility = Visibility.Collapsed;
                RegisterButton.Visibility = Visibility.Collapsed;
                MyBookingsButton.Visibility = Visibility.Visible;
                LogoutButton.Visibility = Visibility.Visible;
            }
            else
            {
                LogInButton.Visibility = Visibility.Visible;
                RegisterButton.Visibility = Visibility.Visible;
                MyBookingsButton.Visibility = Visibility.Collapsed;
                LogoutButton.Visibility = Visibility.Collapsed;
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LogInViewModel.User = null;
            this.Frame.Navigate(typeof(FrontPageSearch));

        }

        private void MyBookingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyBookingPage));
        }
    }
}
