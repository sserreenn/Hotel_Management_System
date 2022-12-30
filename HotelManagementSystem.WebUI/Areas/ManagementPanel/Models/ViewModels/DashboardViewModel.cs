using HotelManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.WebUI.Areas.ManagementPanel.Models.ViewModels {
      public class DashboardViewModel {
            public List<Room> RoomList { get; set; }

            public int ContactMessageCount { get; set; }
            public int UserCount { get; set; }
            public int RoomCount { get; set; }
            public int CategoryCount { get; set; }
      }
}