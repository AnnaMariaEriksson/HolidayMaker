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

        public FrontPageSearch()
        {
            this.InitializeComponent();
            FrontPageSearchViewModel = new FrontPageSearchViewModel();
            this.DataContext = FrontPageSearchViewModel.Rooms;
            GetAllRegionsListView.ItemsSource = FrontPageSearchViewModel.Regions;
        }

        private void DecreaseOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void IncreaseOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            var region = HotelsService.GetRegions();
            var lw = GetAllRegionsListView.Items;
            var searchString = SearchField.Text;
            var endDate = EndDate.MaxDate;
            var startDate = StartDate.MinDate;

            foreach (Regions r in region)
            {
                if (searchString == r.NameOfRegion)
                {
                    lw.Add(r.Cities);
                    //TODO add get method for cities and dates
                    //TODO check number of rooms at get. If rooms < 3 don't show
                }
            }

        }
    }
}
