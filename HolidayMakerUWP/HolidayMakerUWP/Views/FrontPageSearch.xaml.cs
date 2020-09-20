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
        }

        public async void GetAllCitiesInRegions()
        {
            //var cities = await HotelsService.GetAllCitiesAsync();

            //foreach (City city in cities)
            //{
            //    FrontPageSearchViewModel.Cities.Add(city);
            //}
        }

        public void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            //GetAllCitiesInRegions();
            FrontPageSearchViewModel.TempCity.Clear();
            var region = FrontPageSearchViewModel.Regions;
            var cities = FrontPageSearchViewModel.Cities;
            var tempCity = FrontPageSearchViewModel.TempCity;
            var searchString = SearchField.Text;
            var endDate = EndDate.MaxDate;
            var startDate = StartDate.MinDate;

            foreach (Regions r in region)
            {
                
                if (searchString == r.NameOfRegion)
                {
                    Region = r;
                    foreach (City city in cities)
                    {
                        if (city.RegionID == r.RegionID)
                        {
                            //TODO do something...
                           tempCity.Add(city);
                        }
                    }
                   
                    
                    //TODO add get method for cities and dates
                    //TODO check number of rooms at get. If rooms < 3 don't show
                }
                if (tempCity.Count() == 0)
                {
                    IfNotFoundLabel.Text = "Tyvärr, vi hittade inget som matchade din sökning.";
                }
                else
                {
                    IfNotFoundLabel.Text = ($"Vi hittade ({tempCity.Count()}) hotell.");
                }
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
    }
}
