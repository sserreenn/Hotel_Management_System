using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.WebUI.Models.Validations {
      public class About_Validation {
            public byte AboutId { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(100, ErrorMessage = "Bu alan en fazla 100 karakter içermelidir.")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MinLength(5, ErrorMessage = "En az 5 karakter içermelidir.")]
            public string Description { get; set; }

            public string ImageURL { get; set; }
      }
}