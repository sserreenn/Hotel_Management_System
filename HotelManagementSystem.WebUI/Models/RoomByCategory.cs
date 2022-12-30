namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoomByCategory
    {
        public int RoomByCategoryId { get; set; }

        public short? CategoryId { get; set; }

        public int? RoomId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Room Room { get; set; }
    }
}
