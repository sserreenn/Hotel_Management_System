using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.WebUI.Models.Validations {
      public class Room_Validation {
            public int RoomId { get; set; }

            public string ImageURL { get; set; }
            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            public double? MinPrice { get; set; }
            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            public double? MaxPrice { get; set; }
            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(10, ErrorMessage = "Bu alan en fazla 10 karakter içermelidir.")]
            public string CurrencyType { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(100, ErrorMessage = "Bu alan en fazla 100 karakter içermelidir.")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(50, ErrorMessage = "Bu alan en fazla 50 karakter içermelidir.")]
            public string Code { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(200, ErrorMessage = "Bu alan en fazla 200 karakter içermelidir.")]
            public string BriefDescription { get; set; }
             
            public byte? BedCapacity { get; set; } 
            public byte? Size { get; set; } 
            public byte? BathCapacity { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterDate { get; set; }

            public bool? IsActive { get; set; }

            [MaxLength(50, ErrorMessage = "Bu alan en fazla 50 karakter içermelidir.")]
            public string Characteristic { get; set; }
            public int? OrderNo { get; set; }

            public byte? PersonCapacity { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<AmenityByRoom> AmenityByRooms { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Comment> Comments { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Image> Images { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Price> Prices { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<RoomByCategory> RoomByCategories { get; set; }

            public virtual RoomDetail RoomDetail { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<ServiceByRoom> ServiceByRooms { get; set; }
      }
}