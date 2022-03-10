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

        
        public OrderDetail GetIdOrderDetail(int id)
        {
            return db.OrderDetails.Find(id);
        }

        
        public List<OrderDetail> ListDetail(int id)
        {
            return db.OrderDetails.Where(x => x.OrderID == id).OrderBy(x => x.OrderID).ToList();
        }

        
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