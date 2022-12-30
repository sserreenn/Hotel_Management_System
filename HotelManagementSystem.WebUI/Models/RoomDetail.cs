namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
      using HotelManagementSystem.WebUI.Models.Validations;

      [MetadataType(typeof(RoomDetail_Validation))]
      public partial class RoomDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomDetail()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomId { get; set; }

        public double? AverageReview { get; set; }

        public int? ReviewCounter { get; set; }

        public string Description { get; set; }

        public string Rules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual Room Room { get; set; }
    }
}
