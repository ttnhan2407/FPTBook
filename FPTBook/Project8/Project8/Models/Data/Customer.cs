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

        [StringLength(50)]
        [Required(ErrorMessage = "Email cannot be blank")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(250)]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address cannot be left blank")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone number cannot be left blank")]
        [DataType(DataType.PhoneNumber)]
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

        [Display(Name = "DateCreate")]
        [DataType(DataType.DateTime)]
        public DateTime? DateCreate { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
