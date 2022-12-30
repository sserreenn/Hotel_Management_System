namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
      using HotelManagementSystem.WebUI.Models.Validations;

      [MetadataType(typeof(Amenity_Validation))]
      public partial class Amenity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Amenity()
        {
            AmenityByRooms = new HashSet<AmenityByRoom>();
        }

        public int AmenityId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string ImageURL { get; set; }

        public bool? IsActive { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? RegisterDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AmenityByRoom> AmenityByRooms { get; set; }
    }
}
