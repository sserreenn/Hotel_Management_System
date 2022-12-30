using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagementSystem.WebUI.Models.Validations {
      public class Comment_Validation {
            public int CommentId { get; set; }

            public int RoomId { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(100, ErrorMessage = "Bu alan en fazla 100 karakter içermelidir.")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(100, ErrorMessage = "Bu alan en fazla 100 karakter içermelidir.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MaxLength(14, ErrorMessage = "Bu alan en fazla 14 karakter içermelidir.")]
            public string PhoneNumber { get; set; }
            [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
            [MinLength(5, ErrorMessage = "Bu alan en az 5 karakter içermelidir.")]
            public string Message { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterDate { get; set; }

            public bool? IsActive { get; set; }

            public byte? ServiceReview { get; set; }

            public byte? CleaningReview { get; set; }

            public byte? GeneralReview { get; set; }

            public virtual Room Room { get; set; }
      }
}