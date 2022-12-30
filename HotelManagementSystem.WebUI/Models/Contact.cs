namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
      using HotelManagementSystem.WebUI.Models.Validations;

      [MetadataType(typeof(Contact_Validation))]
      public partial class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ContactId { get; set; }

        [StringLength(14)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(5)]
        public string ZipCode { get; set; }

        public string Map { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
    }
}
