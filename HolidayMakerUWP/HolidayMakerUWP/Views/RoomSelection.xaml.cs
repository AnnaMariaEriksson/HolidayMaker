using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
using Newtonsoft.Json;
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
    public sealed partial class RoomSelection : Page
    {
        public RoomSelectionVm Vm { get; set; }
        public HotelsService ServiceVm;
        public RoomSelection()
        {
            this.InitializeComponent();
            this.Vm = new RoomSelectionVm();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Vm._selectedhotel = HotelsService.SelectedHotel;
            Vm.GetFascilities();
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

        private void Skander()
        {
            Vm.selectedRooms.Add((Room)RoomListView.SelectedItem);
        }

        private void roomToBasket_Click(object sender, RoutedEventArgs e)
        {
            Room TempRoom = (Room)((FrameworkElement)sender).DataContext;
            Vm.AddRoomToBasket(TempRoom);
            Vm.Rooms.Remove(TempRoom);
        }

        private void ConfirmChoosenRooms_Click(object sender, RoutedEventArgs e)
        {
            var SelectedRooms = Vm.RoomBasket;
            Frame.Navigate(typeof(BookingPage), SelectedRooms);
        }
    }
}
