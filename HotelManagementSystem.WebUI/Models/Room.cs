namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
      using HotelManagementSystem.WebUI.Models.Validations;

      [MetadataType(typeof(Room_Validation))]
      public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            AmenityByRooms = new HashSet<AmenityByRoom>();
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
            Prices = new HashSet<Price>();
            RoomByCategories = new HashSet<RoomByCategory>();
            ServiceByRooms = new HashSet<ServiceByRoom>();
        }

        public int RoomId { get; set; }

        public string ImageURL { get; set; }

        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }

        [StringLength(10)]
        public string CurrencyType { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(200)]
        public string BriefDescription { get; set; }

        public byte? BedCapacity { get; set; }

        public byte? Size { get; set; }

        public byte? BathCapacity { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? RegisterDate { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(50)]
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
