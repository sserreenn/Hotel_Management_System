using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.WebUI.Models.Validations {
      public class RoomDetail_Validation {
            public int RoomId { get; set; }

            public double? AverageReview { get; set; }

            public int? ReviewCounter { get; set; }
            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MinLength(5, ErrorMessage = "En az 5 karakter içermelidir.")]
            public string Description { get; set; }
            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MinLength(5, ErrorMessage = "En az 5 karakter içermelidir.")]
            public string Rules { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Reservation> Reservations { get; set; }

            public virtual Room Room { get; set; }
      }
}