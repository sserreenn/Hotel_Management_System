namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServiceByRoom
    {
        public int ServiceByRoomId { get; set; }

        public int ServiceId { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public virtual Service Service { get; set; }
    }
}
