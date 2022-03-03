namespace FPTBookstore.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        
        [Key]
        [Display(Name = "OrderID")]
        public int OrderID { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "DateStart")]
        public DateTime DateStart { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "DateEnd")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "OrderStatus")]
        public bool OrderStatus { get; set; }

        public int CustomerID { get; set; }
        public int? Payment { get; set; }
        public int? Tracking { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
