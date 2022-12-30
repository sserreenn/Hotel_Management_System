using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.WebUI.Models.Validations {
      public class Category_Validation {
            public short CategoryId { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(50, ErrorMessage = "Bu alan en fazla 50 karakter içermelidir.")]
            public string Name { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterDate { get; set; }

            public bool? IsActive { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<RoomByCategory> RoomByCategories { get; set; }
      }
}