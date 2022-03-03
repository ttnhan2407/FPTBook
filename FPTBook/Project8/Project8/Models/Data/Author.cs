namespace FPTBookstore.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Display(Name = "AuthorID")]
        public int AuthorID { get; set; }

        [StringLength(50)]
        [Display(Name = "AuthorName")]
        [Required(ErrorMessage = "Names cannot be left blank")]
        public string AuthorName { get; set; }

        [StringLength(250)]
        [Display(Name = "Hometown")]
        public string Hometown { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "DateOfDeath")]
        public DateTime? DateOfDeath { get; set; }

        [StringLength(500)]
        [Display(Name = "Biographic")]
        public string Biographic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
