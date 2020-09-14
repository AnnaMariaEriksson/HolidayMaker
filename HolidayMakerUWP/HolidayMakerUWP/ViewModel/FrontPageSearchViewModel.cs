using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HolidayMakerUWP.Model;
using Newtonsoft.Json;

namespace HolidayMakerUWP.Viewmodel
{
    public class FrontPageSearchViewModel
    {
        public ObservableCollection<Room> Rooms { get; set; }

        private HttpClient httpClient;
        private string roomURL = "";
        //Just a comment.

        public FrontPageSearchViewModel()
        {
            Rooms = new ObservableCollection<Room>();
            httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<Room>> GetAllRoomsAsync()
        {
            var jsonRooms = await httpClient.GetStringAsync(roomURL);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(jsonRooms, settings);

            return rooms;
        }
    }
}
