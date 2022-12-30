using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.WebUI.Models.Validations {
      public class Price_Validation {
            public int PriceId { get; set; }

            public int? RoomId { get; set; }
            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(10, ErrorMessage = "Bu alan en fazla 10 karakter içermelidir.")]
            public string CurrencyType { get; set; }

            public double? PricePerWeek { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            public byte? MinAccommodationDay { get; set; }

            public bool? IsActive { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterDate { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? AccommodationBeginDate { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? AccommodationEndDate { get; set; }

            public virtual Room Room { get; set; }
      }
}