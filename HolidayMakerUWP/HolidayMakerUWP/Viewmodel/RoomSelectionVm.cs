using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Viewmodel
{
    public class RoomSelectionVm
    {
        public HotelsService Vm;

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
    }
}
