namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
      using HotelManagementSystem.WebUI.Models.Validations;

      [MetadataType(typeof(Price_Validation))]
      public partial class Price
    {
        public int PriceId { get; set; }

        public int? RoomId { get; set; }

        [StringLength(10)]
        public string CurrencyType { get; set; }

        public double? PricePerWeek { get; set; }

        public bool? IsActive { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? RegisterDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? AccommodationBeginDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? AccommodationEndDate { get; set; }

        public byte? MinAccommodationDay { get; set; }

        public virtual Room Room { get; set; }
    }
}
