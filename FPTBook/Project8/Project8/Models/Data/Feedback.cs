namespace FPTBookstore.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int FBID { get; set; }

        [StringLength(50)]
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "First Name cannot be left blank")]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email cannot be blank")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone number cannot be left blank")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(500)]
        [Display(Name = "Contents")]
        [Required(ErrorMessage = "Your content to enter")]
        public string Contents { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "DateUpdate")]
        [DataType(DataType.DateTime)]
        public DateTime? DateUpdate { get; set; }
    }
}
