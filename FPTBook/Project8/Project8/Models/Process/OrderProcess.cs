using FPTBookstore.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTBookstore.Models.Process
{
    public class OrderProcess
    {
        //initialize data from data layer
        BSDBContext db = null;

        //contructor
        public OrderProcess()
        {
            db = new BSDBContext();
        }

        
        public Order GetIdOrder(int id)
        {
            return db.Orders.Find(id);
        }

        
        public List<Order> ListOrder()
        {
            return db.Orders.OrderBy(x => x.OrderID).ToList();
        }

        
        public int Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.OrderID;
        }
    }
}