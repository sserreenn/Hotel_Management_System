namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AmenityByRoom
    {
        public int AmenityByRoomId { get; set; }

        public int AmenityId { get; set; }

        public int RoomId { get; set; }

        public virtual Amenity Amenity { get; set; }

        public virtual Room Room { get; set; }
    }
}
