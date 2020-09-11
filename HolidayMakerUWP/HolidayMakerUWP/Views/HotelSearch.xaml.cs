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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HolidayMakerUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HotelSearch : Page
    {
        public HotelSearch()
        {
            this.InitializeComponent();
        }

        private void Slider_Holding(object sender, HoldingRoutedEventArgs e)
        {
            SeaDistansValue.Text = SeaDistansSlider.Value.ToString();
        }

        private void SeaDistansSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SeaDistansValue.Text = SeaDistansSlider.Value.ToString() + "Km";
        }

        private void CenterDistansSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            CenterDistansValue.Text = CenterDistansSlider.Value.ToString() + "Km";
        }
    }
}
