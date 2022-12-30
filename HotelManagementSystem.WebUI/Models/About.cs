namespace HotelManagementSystem.WebUI.Models {      
      using System;
      using System.Collections.Generic;
      using System.ComponentModel.DataAnnotations;
      using System.ComponentModel.DataAnnotations.Schema;
      using System.Data.Entity.Spatial;
      using HotelManagementSystem.WebUI.Models.Validations;

      [MetadataType(typeof(About_Validation))]
      public partial class About {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public byte AboutId { get; set; }

            [StringLength(100)]
            public string Title { get; set; }

            public string Description { get; set; }

            public string ImageURL { get; set; }
      }
}
