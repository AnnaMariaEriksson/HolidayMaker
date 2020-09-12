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
        ObservableCollection<Hotel> FilteredHotels { get; set; }
        private bool HasAllInclusive;
        private bool HasFullBoard;
        private bool HasHalfBoard;
        private bool HasRestaurant;
        private bool HasChildrensClub;
        private bool HasEntertainment;
        private bool HasPool;
        ObservableCollection<Hotel> TempRemoveHotel = new ObservableCollection<Hotel>();
        public HotelSearch()
        {
            this.InitializeComponent();

            Hotel h1 = new Hotel() { DistansToCenter = 40, DistansToBeach = 10, HasAllInclusive = "", HasFullBoard = "har", HasHalfBoard = "", HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 1 };
            Hotel h2 = new Hotel() { DistansToCenter = 30, DistansToBeach = 25, HasAllInclusive = "har", HasFullBoard = "", HasHalfBoard = "har", HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 2 };
            Hotel h3 = new Hotel() { DistansToCenter = 50, DistansToBeach = 45, HasAllInclusive = "", HasFullBoard = "", HasHalfBoard = "", HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 3 };
            Hotels.Add(h1);
            Hotels.Add(h2);
            Hotels.Add(h3);
            HasAllInclusive = false;
            HasFullBoard = false;
            HasHalfBoard = false;
            HasRestaurant = false;
            HasChildrensClub = false;
            HasEntertainment = false;
            HasPool = false;
            GetHotels("");
            CenterDistansSlider.Value = 50;
            SeaDistansSlider.Value = 50;
            
    }

       
        //Reset HotelListan
        private ObservableCollection<Hotel> GetHotels(string InclusiveString)
        {

            FilteredHotels = Hotels;
            HotelList.ItemsSource = FilteredHotels;
            return FilteredHotels;
        }

        private void SeaDistansSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            ObservableCollection<Hotel> th = new ObservableCollection<Hotel>();
            SeaDistansValue.Text = SeaDistansSlider.Value.ToString() + "Km";

            foreach (Hotel ho in FilteredHotels)
            {
                if (ho.DistansToBeach > SeaDistansSlider.Value)
                {
                    th.Add(ho);
                    TempRemoveHotel.Add(ho);            
                }
                else
                {
                    th.Remove(ho);
                    TempRemoveHotel.Remove(ho);
                }

            }
              
            foreach (Hotel h in th)
                {
                    FilteredHotels.Remove(h);
                }
           
            foreach (Hotel h in TempRemoveHotel)
             {
                if (h.DistansToBeach <= SeaDistansSlider.Value && h.DistansToCenter <= CenterDistansSlider.Value)
                {
                    FilteredHotels.Add(h);
                    HotelList.ItemsSource = FilteredHotels;
                }
             }

        }

        private void CenterDistansSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            ObservableCollection<Hotel> th = new ObservableCollection<Hotel>();
            CenterDistansValue.Text = CenterDistansSlider.Value.ToString() + "Km";
            foreach (Hotel ho in FilteredHotels)
            {
                if (ho.DistansToCenter > CenterDistansSlider.Value)
                {
                    th.Add(ho);
                    TempRemoveHotel.Add(ho);
                }
                else
                {
                    th.Remove(ho);
                    TempRemoveHotel.Remove(ho);
                }

            }

            foreach (Hotel h in th)
            {
                FilteredHotels.Remove(h);
            }

            foreach (Hotel h in TempRemoveHotel)
            {
                if (h.DistansToCenter <= CenterDistansSlider.Value && h.DistansToBeach <= SeaDistansSlider.Value)
                {
                    FilteredHotels.Add(h);
                    HotelList.ItemsSource = FilteredHotels;
                }
            }

        }

        private void AllInclusiveButton_Click(object sender, RoutedEventArgs e)
        {
            
            //Tar bort alla hotel som inte stämmer med filtret(funkar)
            if (HasAllInclusive == false)
            {

                HasAllInclusive = true;
                AllInclusiveButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));

                foreach (Hotel h in FilteredHotels)
                {
                    if (h.HasAllInclusive == "" && h.DistansToBeach <= SeaDistansSlider.Value && h.DistansToCenter <= CenterDistansSlider.Value)
                        TempRemoveHotel.Add(h);

                }
                foreach (Hotel ho in TempRemoveHotel)
                    FilteredHotels.Remove(ho);
            }
            else
            {
                ObservableCollection<Hotel> th = new ObservableCollection<Hotel>();
                HasAllInclusive = false;
                AllInclusiveButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
               
                foreach (Hotel ho in TempRemoveHotel)
                {
                    if (HasFullBoard || HasHalfBoard == true )
                    {
                        if(ho.HasFullBoard == "har" || ho.HasHalfBoard == "har")
                        {
                            FilteredHotels.Add(ho);
                            th.Add(ho);
                        }
                    }
                    else {
                        if (ho.DistansToBeach <= SeaDistansSlider.Value && ho.DistansToCenter <= CenterDistansSlider.Value)
                        {
                            FilteredHotels.Add(ho);
                            th.Add(ho);
                        }
                    }
                   
                }

                foreach(Hotel h in th)
                {
                    TempRemoveHotel.Remove(h);
                }
              
                
                

            }

        }

        private void FullBoardButton_Click(object sender, RoutedEventArgs e)
        {
            //Tar bort alla hotel som inte stämmer med filtret(funkar)
            if (HasFullBoard == false)
            {

                HasFullBoard = true;
                FullBoardButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));

                foreach (Hotel h in FilteredHotels)
                {
                    if (h.HasFullBoard == "" && h.DistansToBeach <= SeaDistansSlider.Value && h.DistansToCenter <= CenterDistansSlider.Value)
                        TempRemoveHotel.Add(h);

                }
                foreach (Hotel ho in TempRemoveHotel)
                    FilteredHotels.Remove(ho);
            }
            else
            {
                ObservableCollection<Hotel> th = new ObservableCollection<Hotel>();
                HasFullBoard = false;
                FullBoardButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));

                foreach (Hotel ho in TempRemoveHotel)
                {
                    if (HasAllInclusive || HasHalfBoard == true)
                    {
                        if (ho.HasAllInclusive == "har" || ho.HasHalfBoard == "har")
                        {
                            FilteredHotels.Add(ho);
                            th.Add(ho);
                        }
                    }
                    else
                    {
                        if (ho.DistansToBeach <= SeaDistansSlider.Value && ho.DistansToCenter <= CenterDistansSlider.Value)
                        {
                            FilteredHotels.Add(ho);
                            th.Add(ho);
                        }
                    }

                }

                foreach (Hotel h in th)
                {
                    TempRemoveHotel.Remove(h);
                }
            }
        }

        private void HalfBoardButton_Click(object sender, RoutedEventArgs e)
        {
            //Tar bort alla hotel som inte stämmer med filtret(funkar)
            if (HasHalfBoard == false)
            {

                HasHalfBoard = true;
                HalfBoardButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));

                foreach (Hotel h in FilteredHotels)
                {
                    if (h.HasHalfBoard == "" && h.DistansToBeach <= SeaDistansSlider.Value && h.DistansToCenter <= CenterDistansSlider.Value)
                        TempRemoveHotel.Add(h);

                }
                foreach (Hotel ho in TempRemoveHotel)
                    FilteredHotels.Remove(ho);
            }
            else
            {
                ObservableCollection<Hotel> th = new ObservableCollection<Hotel>();
                HasHalfBoard = false;
                HalfBoardButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));

                foreach (Hotel ho in TempRemoveHotel)
                {
                    if (HasAllInclusive || HasFullBoard == true)
                    {
                        if (ho.HasAllInclusive == "har" || ho.HasFullBoard == "har")
                        {
                            FilteredHotels.Add(ho);
                            th.Add(ho);
                        }
                    }
                    else
                    {
                        if (ho.DistansToBeach <= SeaDistansSlider.Value && ho.DistansToCenter <= CenterDistansSlider.Value)
                        {
                            FilteredHotels.Add(ho);
                            th.Add(ho);
                        }
                    }

                }

                foreach (Hotel h in th)
                {
                    TempRemoveHotel.Remove(h);
                }
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

       
    }
}
