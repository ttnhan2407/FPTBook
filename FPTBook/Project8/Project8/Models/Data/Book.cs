namespace FPTBookstore.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Display(Name = "BookID")]
        public int BookID { get; set; }

        [Display(Name = "CategoryID")]
        [Required(ErrorMessage = "Please select category")]
        public int CategoryID { get; set; }

        [Display(Name = "PublisherID")]
        [Required(ErrorMessage = "Please select a publisher")]
        public int PublisherID { get; set; }

        [Display(Name = "AuthorID")]
        [Required(ErrorMessage = "Please select an author")]
        public int AuthorID { get; set; }

        [StringLength(250)]
        [Display(Name = "BookName")]
        [Required(ErrorMessage = "Please enter book title")]
        public string BookName { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }

        [StringLength(500)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Translator")]
        public string Translator { get; set; }

        [StringLength(50)]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "DateUpdate")]
        public DateTime? DateUpdate { get; set; }

        [Display(Name = "Inventory")]
        public int? Inventory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual Category Category { get; set; }

        public virtual Author Author { get; set; }
       
    }
}
