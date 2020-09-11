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
using HolidayMakerUWP.Model;
using HolidayMakerUWP.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HolidayMakerUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HotelSearch : Page
    {
        public HotelSearchViewModel HotelSearchViewModel { get; set; }
        public HotelSearch()
        {
            this.InitializeComponent();
            HotelSearchViewModel = new HotelSearchViewModel();
            this.DataContext = HotelSearchViewModel.Rooms;
        }

        private void IncreaseOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DecreaseOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            WhenSearchButtonHasBeenPressedLabel.Text = "Du tryckte på sökknappen. Tack!";
            var rooms = HotelSearchViewModel.Rooms;

            foreach (Room room in rooms)
            {
                
            }
        }
    }
}
