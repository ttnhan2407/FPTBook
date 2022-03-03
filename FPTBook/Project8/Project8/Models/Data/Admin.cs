namespace FPTBookstore.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [Display(Name = "IDAdmin")]
        public int IDAdmin { get; set; }

        [StringLength(50)]
        [Display(Name = "Account")]
        [Required(ErrorMessage = "Enter account")]
        public string Account { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Enter password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Display(Name = "Status")]
        public bool? Status { get; set; }
    }
}
