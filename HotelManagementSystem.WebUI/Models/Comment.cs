namespace HotelManagementSystem.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
      using HotelManagementSystem.WebUI.Models.Validations;

      [MetadataType(typeof(Comment_Validation))]
      public partial class Comment
    {
        public int CommentId { get; set; }

        public int RoomId { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(14)]
        public string PhoneNumber { get; set; }

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
