using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.WebUI.Areas.ManagementPanel.Models.ViewModels {
      public class LoginViewModel {

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir email girin.")]
            [MaxLength(100, ErrorMessage = "Bu alan en fazla 100 karakter içermelidir.")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            public string Password { get; set; }
      }
}