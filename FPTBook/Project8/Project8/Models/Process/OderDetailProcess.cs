using FPTBookstore.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTBookstore.Models.Process
{
    public class OderDetailProcess
    {
        BSDBContext db = null;
        public OderDetailProcess()
        {
            db = new BSDBContext();
        }

        /// <summary>
        /// function to get order item code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderDetail GetIdOrderDetail(int id)
        {
            return db.OrderDetails.Find(id);
        }

        /// <summary>
        /// View order details
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>List</returns>
        public List<OrderDetail> ListDetail(int id)
        {
            return db.OrderDetails.Where(x => x.OrderID == id).OrderBy(x => x.OrderID).ToList();
        }

        /// <summary>
        /// function to add products to the order
        /// </summary>
        /// <param name="detail">OrderDetails</param>
        /// <returns>bool</returns>
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}