using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
using HolidayMakerUWP.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HolidayMakerUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FrontPageSearch : Page
    {
        public FrontPageSearchViewModel FrontPageSearchViewModel { get; set; }
        public HotelsService HotelsService { get; set; }
        public City City { get; set; }
        public Regions Region { get; set; }

        public FrontPageSearch()
        {
            this.InitializeComponent();
            FrontPageSearchViewModel = new FrontPageSearchViewModel();
            this.DataContext = FrontPageSearchViewModel.Regions;
            GetAllRegionsListView.ItemsSource = FrontPageSearchViewModel.TempCity;
            CheckLoginState();
        }

        public async void GetAllCitiesInRegions()
        {
            //var cities = await HotelsService.GetAllCitiesAsync();

            //foreach (City city in cities)
            //{
            //    FrontPageSearchViewModel.Cities.Add(city);
            //}
        }

        public async void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
          
            //GetAllCitiesInRegions();
            FrontPageSearchViewModel.TempCity.Clear();
            var regions = await HotelsService.GetAllRegionsAsync();
            var cities = FrontPageSearchViewModel.Cities;
            var tempCity = FrontPageSearchViewModel.TempCity;
            var searchString = SearchField.Text;
            var endDate = EndDate.MaxDate;
            var startDate = StartDate.MinDate;

            foreach (Regions r in regions)
            {
                
                if (searchString.ToLower() == r.NameOfRegion.ToLower())
                {
                    Region = r;
                    foreach (City city in r.Cities)
                    {
                           tempCity.Add(city);
                        
                    }
                    
                    break;
                   
                    //TODO add get method for cities and dates
                    //TODO check number of rooms at get. If rooms < 3 don't show
                }
                
            }
            if (!tempCity.Any())
            {
                IfNotFoundLabel.Text = "Tyvärr, vi hittade inget som matchade din sökning.";
            }
            else
            {
                IfNotFoundLabel.Text = ($"Vi hittade ({tempCity.Count()}) hotell.");
            }

        }

        private void GetAllRegionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FrontPageSearchViewModel.Search = new Search
            {
                Cities = (City)GetAllRegionsListView.SelectedItem,
                Regions = Region,
                StartDate = (DateTimeOffset)StartDate.Date,
                EndDate = (DateTimeOffset)EndDate.Date
            };
            this.Frame.Navigate(typeof(HotelSearch));
        }

        public void CheckLoginState()
        {
            if (LogInViewModel.User != null)
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

        private void EndDateButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FrontPageSearch));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LogInViewModel.User = null;
            this.Frame.Navigate(typeof(FrontPageSearch));

        }
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage2));
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegistrationPage));
        }

        private void MyBookingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyBookingPage));
        }
    }
}
