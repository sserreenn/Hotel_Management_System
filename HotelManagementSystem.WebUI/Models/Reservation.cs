namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservation
    {
        public int ReservationId { get; set; }

        public int RoomId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? RegisterDate { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelayed { get; set; }

        public bool? IsCanceled { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? AccomodationBeginDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? AccomodationEndDate { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(14)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public byte? AdultCount { get; set; }

        public byte? ChildCount { get; set; }

        public byte? BabyCount { get; set; }

        public virtual RoomDetail RoomDetail { get; set; }
    }
}
