using HolidayMakerUWP.Model;
using HolidayMakerUWP.Viewmodel;
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
    public sealed partial class BasePage : Page
    {
        LogInViewModel lVm { get; set; }
        User tempUser;
        public BasePage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(FrontPageSearch));
            tempUser = LogInViewModel.User;
        }
        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            NavStrip.IsPaneOpen = !NavStrip.IsPaneOpen;
        }

        private void NavMenu_SelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (list.SelectedIndex == -1) { return; }
            Frame current = NavStrip.Content as Frame;
            current.Navigate(((Nav)list.SelectedItem).Page);
            NavStrip.IsPaneOpen = false;
        }
    }
}
