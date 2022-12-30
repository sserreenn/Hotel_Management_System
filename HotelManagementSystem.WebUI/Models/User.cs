namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
      using HotelManagementSystem.WebUI.Models.Validations;

      [MetadataType(typeof(User_Validation))]
      public partial class User
    {
        public int UserId { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? RegisterDate { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(14)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Address { get; set; }
    }
}
