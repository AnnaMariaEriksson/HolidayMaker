using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public sealed partial class HotelSearch : Page
    {
        ObservableCollection<Hotel> Hotels = new ObservableCollection<Hotel>();
        ObservableCollection<Hotel> FilteredHotels;
        private bool HasAllInclusive;
        private bool HasFullBoard;
        private bool HasHalfBoard;
        private bool HasRestaurant;
        private bool HasChildrensClub;
        private bool HasEntertainment;
        private bool HasPool;
        public HotelSearch()
        {
            this.InitializeComponent();

            Hotel h1 = new Hotel() { DistansToCenter = 30, DistansToBeach = 45, HasAllInclusive = "", HasFullBoard = "har", HasHalfBoard = false, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 1 };
            Hotel h2 = new Hotel() { DistansToCenter = 30, DistansToBeach = 45, HasAllInclusive = "har", HasFullBoard = "", HasHalfBoard = false, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 2 };
            Hotel h3 = new Hotel() { DistansToCenter = 30, DistansToBeach = 45, HasAllInclusive = "", HasFullBoard = "", HasHalfBoard = false, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 3 };
            Hotels.Add(h1);
            Hotels.Add(h2);
            Hotels.Add(h3);
            HasFullBoard = false;
            HasHalfBoard = false;
            HasRestaurant = false;
            HasChildrensClub = false;
            HasEntertainment = false;
            HasPool = false;
            CenterDistansSlider.Value = 50;
            SeaDistansSlider.Value = 50;
    }
        //Skitstort error fixa annars krashar det. kraschar vid andra knapptrycket.
        public void GetHotelList()
        {
                foreach(Hotel h in Hotels) 
                {
                foreach(Hotel ho in FilteredHotels)
                {
                    if(h.HotelID != ho.HotelID)
                    {
                        FilteredHotels.Add(h);
                    }
 
                }
                }
                
        }
        private void Slider_Holding(object sender, HoldingRoutedEventArgs e)
        {
            SeaDistansValue.Text = SeaDistansSlider.Value.ToString();
        }

        private void SeaDistansSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SeaDistansValue.Text = SeaDistansSlider.Value.ToString() + "Km";
            string test;
            GetHotels(test = "");
        }

        private void CenterDistansSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            CenterDistansValue.Text = CenterDistansSlider.Value.ToString() + "Km";
            string test;
            GetHotels(test = "");
            
        }

        private ObservableCollection<Hotel> GetHotels(string InclusiveString)
        {
            var FilteredHotelsTemp = Hotels;
             FilteredHotels = new ObservableCollection<Hotel>(FilteredHotelsTemp);
            return FilteredHotels;
        }

        private void AllInclusiveButton_Click(object sender, RoutedEventArgs e)
        {
            string test2;
            Debug.WriteLine("Test");    
            if (HasAllInclusive == false)
            {
                HasAllInclusive = true;
                AllInclusiveButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));

                var test = FilteredHotels.Where(h => h.HasAllInclusive == "");
                ObservableCollection<Hotel> temp = new ObservableCollection<Hotel>(test);
                foreach(Hotel h in temp)
                {
                    FilteredHotels.Remove(h);
                    GetHotels("");
                }
               
            }
            else
            {
                GetHotelList();
                HasAllInclusive = false;
                Debug.WriteLine(HasAllInclusive);
                AllInclusiveButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
                GetHotels(test2 = "har");
            }
        }

        private void FullBoardButton_Click(object sender, RoutedEventArgs e)
        {
            string test2;
            if (HasFullBoard == false)
            {
                FullBoardButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));
                var test = FilteredHotels.Where(h => h.HasFullBoard == "");
                ObservableCollection<Hotel> temp = new ObservableCollection<Hotel>(test);

                foreach (Hotel h in temp)
                {
                    FilteredHotels.Remove(h);
                   GetHotels(test2 = "");
                }
                
                HasFullBoard = true;
                HotelList.ItemsSource = FilteredHotels;
            }
            else
            {
                GetHotelList();
                GetHotels(test2 = "har");
                HasFullBoard = false;
                FullBoardButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
                HotelList.ItemsSource = FilteredHotels;
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

        private void AllInclusiveButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
        }
    }
}
