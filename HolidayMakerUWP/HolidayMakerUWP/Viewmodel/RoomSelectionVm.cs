using GalaSoft.MvvmLight.Command;
using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HolidayMakerUWP.Viewmodel
{
    public class RoomSelectionVm
    {
        public HotelsService Vm;
        public ICommand AddRoomBtn { get; set; }
        public ObservableCollection<Room> _roomBasket { get; set; }
        public ObservableCollection<Room> RoomBasket
        {
            get
            {
                return _roomBasket;
            }
            set
            {
                _roomBasket = value;
            }
        }
        public ObservableCollection<Room> _selectedRooms { get; set; }
        public ObservableCollection<Room> selectedRooms
        {
            get
            {
                return _selectedRooms;
            }
            set
            {
                _selectedRooms = value;
            }
        }

        public ObservableCollection<string> _listOfFascilities { get; set; }
        public ObservableCollection<string> ListOfFascilities
        {
            get
            {
                return _listOfFascilities;
            }
            set
            {
                _listOfFascilities = value;
            }
        }
        public Hotel _selectedhotel { get; set; }
        public Hotel SelectedHotel
        {
            get
            {
                return _selectedhotel;
            }
            set
            {
                _selectedhotel = value;
            }
        }
        public ObservableCollection<Room> _rooms { get; set; }
        public ObservableCollection<Room> Rooms
        {
            get
            {
                return _rooms;
            }
            set
            {
                _rooms = value;
            }
        }
        public RoomSelectionVm()
        {
            this.Vm = new HotelsService();
            _rooms = Vm.GetRooms();
        }
        public void AddRoomToBasket(Room selectedRoom)
        {
            //RoomBasket.Add(selectedRoom);
        }
        public void GetFascilities()
        {
            ObservableCollection<string> listoffascilities = new ObservableCollection<string>();
            if (SelectedHotel.HasAllInclusive == true)
            {
                listoffascilities.Add(" Allinclusive är tillgängligt, ");
            }
            else
            {
                listoffascilities.Add("");
            }
            if (SelectedHotel.HasChildrensClub == true)
            {
                listoffascilities.Add(" Det finns barnklubb på hotellet, ");
            }
            else
            {
                listoffascilities.Add("");
            }
            if (SelectedHotel.HasFullBoard == true)
            {
                listoffascilities.Add(" Hotellet erbjuder Helpension, ");
            }
            else
            {
                listoffascilities.Add("");
            }
            if (SelectedHotel.HasHalfBoard == true)
            {
                listoffascilities.Add(" Hotellet erbjuder Halvpension, ");
            }
            else
            {
                listoffascilities.Add("");
            }
            if (SelectedHotel.HasPool == true)
            {
                listoffascilities.Add(" Det finns pool på hotellet, ");
            }
            else
            {
                listoffascilities.Add("");
            }
            if (SelectedHotel.HasRestaurant == true)
            {
                listoffascilities.Add(" Det finns restaurang/er på hotellet, ");
            }
            else
            {
                listoffascilities.Add("");
            }
            _listOfFascilities = listoffascilities;
        }
    }
}
