namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public int ImageId { get; set; }

        public string ImageURL { get; set; }

        public int? RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
