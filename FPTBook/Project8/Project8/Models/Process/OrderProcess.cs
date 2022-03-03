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

        /// <summary>
        /// function get order code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetIdOrder(int id)
        {
            return db.Orders.Find(id);
        }

        /// <summary>
        /// function to output order list
        /// </summary>
        /// <returns>List</returns>
        public List<Order> ListOrder()
        {
            return db.Orders.OrderBy(x => x.OrderID).ToList();
        }

        /// <summary>
        /// function to add order
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>int</returns>
        public int Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.OrderID;
        }
    }
}