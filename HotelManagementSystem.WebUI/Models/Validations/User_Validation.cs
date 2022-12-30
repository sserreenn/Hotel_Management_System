using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.WebUI.Models.Validations {
      public class User_Validation {
            public int UserId { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(80, ErrorMessage = "Bu alan en fazla 80 karakter içermelidir.")]
            public string FullName { get; set; }

            [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir email adresi girin.")]
            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(100, ErrorMessage = "Bu alan en fazla 100 karakter içermelidir.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(50, ErrorMessage = "Bu alan en fazla 50 karakter içermelidir.")]
            public string Password { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterDate { get; set; }

            public bool? IsActive { get; set; }

            [DataType(DataType.PhoneNumber, ErrorMessage = "Geçerli bir telefon numarası girin.")]
            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(14, ErrorMessage = "Bu alan en fazla 13 karakter içermelidir.")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(200, ErrorMessage = "Bu alan en fazla 200 karakter içermelidir.")]
            public string Address { get; set; }
      }
}