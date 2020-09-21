using HolidayMakerUWP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace HolidayMakerUWP.Model
{
    public class NavMenu
    {
        public string BackgroundColor { get; set; }
        public List<Nav> MenuItems { get; set; }
        public NavMenu()
        {
            BackgroundColor = "#32A852";
            MenuItems = new List<Nav>() {
                new Nav("\uE1CE","Logga in", typeof(LoginPage2)),
                //new Nav("\uE1CF","Registrera dig", typeof(RegistrationPage)),
                new Nav("\uE104","Mina bokningar", typeof(Booking)),
            };
        }
    }
}
