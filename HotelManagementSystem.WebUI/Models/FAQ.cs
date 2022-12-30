namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
      using HotelManagementSystem.WebUI.Models.Validations;

      [MetadataType(typeof(FAQ_Validation))]
      public partial class FAQ
    {
        public int FAQId { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? RegisterDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
