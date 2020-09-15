using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
    public sealed partial class HotelSearch : Page
    {
       
        ObservableCollection<Hotel> FilteredHotels { get; set; }
        public static bool HasAllInclusive { get; set; }
        public bool HasFullBoard;
        public bool HasHalfBoard;
        public bool HasRestaurant;
        public bool HasChildrensClub;
        public bool HasEntertainment;
        public bool HasPool;
        public HotelSearchVm Vm { get; set; }
        public HotelsService _service;
        public HotelSearch()
        {
            this.InitializeComponent();
            HasAllInclusive = false;
            HasFullBoard = false;
            HasHalfBoard = false;
            HasRestaurant = false;
            HasChildrensClub = false;
            HasEntertainment = false;
            HasPool = false;
            this.Vm = new HotelSearchVm();
            this._service = new HotelsService();
            SeaDistansValue.Text = Vm.DistansToBeach + "+Km";
            CenterDistansValue.Text = Vm.DistansToCenter + "+Km";

        }

        private void SeaDistansSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            FilterSlides();
            if (Vm.DistansToBeach == 50)
            {
                SeaDistansValue.Text = Vm.DistansToBeach + "+Km";
            }
            else
            {
                SeaDistansValue.Text = Vm.DistansToBeach + "Km";
            }
          
        }

        private void CenterDistansSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            FilterSlides();
            if (CenterDistansSlider.Value == 50)
            {
                CenterDistansValue.Text = Vm.DistansToCenter + "+Km";
            }
            else
            {
                CenterDistansValue.Text = Vm.DistansToCenter + "Km";
            }
            
        }

        public void FilterSlides()
        {
          //  ObservableCollection<Hotel> te = new ObservableCollection<Hotel>();
          //  ObservableCollection<Hotel> th = new ObservableCollection<Hotel>();
          //  foreach (Hotel h in _service.GetHotels())
          //  {
          //      if ( h.DistansToBeach >= Vm.DistansToBeach)
          //      {
          //          te.Add(h);
          //      }
          //  }

          //Vm.RemoveFilteredHotels(te);

           
        }

        private void AllInclusiveButton_Click(object sender, RoutedEventArgs e)
        {   
            //Tar bort alla hotel som inte stämmer med filtret(funkar)
            if (HasAllInclusive == false)
            {
                HasAllInclusive = true;
                AllInclusiveButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221)); 
            }
            else
            {
                HasAllInclusive = false;
                AllInclusiveButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
            }
        }

        private void FullBoardButton_Click(object sender, RoutedEventArgs e)
        {

            if (HasFullBoard == false)
            {
                HasFullBoard = true;
                FullBoardButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));
            }
            else
            {
                HasFullBoard = false;
                FullBoardButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
              
            }
        }

        private void HalfBoardButton_Click(object sender, RoutedEventArgs e)
        {
            if (HasHalfBoard == false)
            {
                HasHalfBoard = true;
                HalfBoardButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));

            }
            else
            {
                HasHalfBoard = false;
                HalfBoardButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
            }
        }

        private void PoolButton_Click(object sender, RoutedEventArgs e)
        {
            if (HasPool == false)
            {
                HasPool = true;
                PoolButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));
            }
            else
            {
                HasPool = false;
                PoolButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
            }
        }

        private void EntertainmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (HasEntertainment == false)
            {
                HasEntertainment = true;
                EntertainmentButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));
            }
            else
            {
                HasEntertainment = false;
                EntertainmentButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
            }
        }

        private void RestaurantButton_Click(object sender, RoutedEventArgs e)
        {
            if (HasRestaurant == false)
            {
                HasRestaurant = true;
                RestaurantButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));
            }
            else
            {
                HasRestaurant = false;
                RestaurantButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
            }
        }

        private void ChildrensClubButton_Click(object sender, RoutedEventArgs e)
        {
            if (HasChildrensClub == false)
            {
                HasChildrensClub = true;
                ChildrensClubButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));
            }
            else
            {
                HasChildrensClub = false;
                ChildrensClubButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
            }
        }

        private void HotelList_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void HotelList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hotel SelectedHotel = (Hotel)HotelList.SelectedItem;
            Frame.Navigate(typeof(RoomSelection), SelectedHotel);
        }
    }
}
