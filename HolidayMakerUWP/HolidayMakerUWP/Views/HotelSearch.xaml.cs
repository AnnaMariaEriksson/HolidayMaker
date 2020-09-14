using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

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
            CenterDistansSlider.Value = 50;
            SeaDistansSlider.Value = 50;
            this.Vm = new HotelSearchVm();
            
    }

        private void DecreaseOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Hotel> th = new ObservableCollection<Hotel>();
            SeaDistansValue.Text = SeaDistansSlider.Value.ToString() + "Km";


        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Hotel> th = new ObservableCollection<Hotel>();
            CenterDistansValue.Text = CenterDistansSlider.Value.ToString() + "Km";
        
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


        private void SeaDistansSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            
        }

        private void CenterDistansSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            
        }
    }
}
