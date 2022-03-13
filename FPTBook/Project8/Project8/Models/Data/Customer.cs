namespace FPTBookstore.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Display(Name = "CustomerID")]
        public int CustomerID { get; set; }


        [StringLength(50)]
        [Required(ErrorMessage = "Names cannot be left blank")]
        [Display(Name = "CustomerName")]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "Email can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        

        [StringLength(250)]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address cannot be left blank")]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "DateOfBirth")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "User Account cannot be empty")]
        [StringLength(50)]
        [Display(Name = "Account")]
        public string Account { get; set; }

        [Required(ErrorMessage = "Password can not be blank")]
        [StringLength(50)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "DateCreate")]
        [DataType(DataType.DateTime)]
        public DateTime? DateCreate { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}

