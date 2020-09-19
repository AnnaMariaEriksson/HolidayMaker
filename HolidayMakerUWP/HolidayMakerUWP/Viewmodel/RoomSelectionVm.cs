using GalaSoft.MvvmLight.Command;
using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HolidayMakerUWP.Viewmodel
{
    public class RoomSelectionVm : INotifyPropertyChanged
    {
        public HotelsService Vm;
        public HotelsService ServiceVm;
        public ICommand AddRoomBtn { get; set; }
        public ICommand AddAllInclusiveBtn { get; set; }
        public ICommand AddFullBoardBtn { get; set; }
        public ICommand AddHalfBoardBtn { get; set; }
        public ICommand AddExtraBedBtn { get; set; }
        public static ObservableCollection<Room> TempRooms { get; set; }
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
        public ObservableCollection<Room> _rooms { get; set;  }
        public ObservableCollection<Room> Rooms
        {
            get
            {             
                    return _rooms;
            }
            set
            {
                _rooms = value;
                //NotifyPropertyChanged("Rooms");
               
            }
        }
        public RoomSelectionVm()
        {
            this.Vm = new HotelsService();
            _roomBasket = new ObservableCollection<Room>();
            _rooms = Task.Run(() => HotelsService.GetRooms(HotelsService.SelectedHotel.HotelID)).Result;
            
        }
        public void AddRoomToBasket(Room selectedRoom)
        {
            RoomBasket.Add(selectedRoom);
        }
        public ObservableCollection<Room> SortByPrice(int SortByInt)
        {
            ObservableCollection<Room> test = new ObservableCollection<Room>();
            if(SortByInt == 1) { 
            test = new ObservableCollection<Room>(TempRooms.OrderBy(r => r.Price));
            }else if(SortByInt == 2)
            {
                test = new ObservableCollection<Room>(TempRooms.OrderByDescending(r => r.Price));
            }
            return test;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
