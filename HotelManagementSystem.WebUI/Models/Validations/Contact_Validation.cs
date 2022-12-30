using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.WebUI.Models.Validations {
      public class Contact_Validation {
            public byte ContactId { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(14, ErrorMessage = "Bu alan en fazla 14 karakter içermelidir.")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(100, ErrorMessage = "Bu alan en fazla 100 karakter içermelidir.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(200, ErrorMessage = "Bu alan en fazla 200 karakter içermelidir.")]
            public string Address { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(5, ErrorMessage = "Bu alan en fazla 5 karakter içermelidir.")]
            public string ZipCode { get; set; }

            public string Map { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(100, ErrorMessage = "Bu alan en fazla 100 karakter içermelidir.")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MinLength(5, ErrorMessage = "Bu alan en az 5 karakter içermelidir.")]
            public string Description { get; set; }

            public string ImageURL { get; set; }
      }
}