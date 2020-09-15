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

        public FrontPageSearch()
        {
            this.InitializeComponent();
            FrontPageSearchViewModel = new FrontPageSearchViewModel();
            this.DataContext = FrontPageSearchViewModel.TempCity;
            GetAllRegionsListView.ItemsSource = FrontPageSearchViewModel.TempCity;
        }

        private void DecreaseOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void IncreaseOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public async void GetAllCitiesInRegion()
        {
            var cities = await HotelsService.GetAllCitiesAsync();

            foreach (City city in cities)
            {
                FrontPageSearchViewModel.Cities.Add(city);
            }
        }

        public void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
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
                    foreach (City city in cities)
                    {
                        if (city.RegionID == r.RegionID)
                        {
                            //TODO do something...
                        }
                    }
                    //TODO add get method for cities and dates
                    //TODO check number of rooms at get. If rooms < 3 don't show
                }
                else
                {
                    IfNotFoundLabel.Text = "Tyvärr, vi hittade inget som matchade din sökning.";
                }
            }

        }

        private void ChooseCityButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HotelSearch));
        }
    }
}
