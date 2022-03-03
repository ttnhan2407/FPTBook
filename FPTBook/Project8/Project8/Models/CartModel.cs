using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FPTBookstore.Models.Data;

namespace FPTBookstore.Models
{
    [Serializable]
    public class CartModel
    {
        public Book book { get; set; }
        public int Quantity { get; set; }
        public decimal? Total
        {
            get { return Quantity * book.Price; }
        }
    }
}