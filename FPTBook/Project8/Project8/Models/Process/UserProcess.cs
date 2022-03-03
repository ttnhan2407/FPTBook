using FPTBookstore.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FPTBookstore.Models.Process;

namespace FPTBookstore.Models.Process
{
    public class UserProcess
    {
        //Customer data processing layer

        BSDBContext db = null;

        /// <summary>
        /// Contructor
        /// </summary>
        public UserProcess()
        {
            db = new BSDBContext();
        }

        /// <summary>
        /// function to get customer code
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Customer</returns>
        public Customer GetIdUser(int id)
        {
            return db.Customers.Find(id);
        }

        /// <summary>
        /// Function to add new customer
        /// </summary>
        /// <param name="entity">Customer</param>
        /// <returns>int</returns>
        public int InsertUser(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.CustomerID;
        }

        /// <summary>
        /// customer login function
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="password">string</param>
        /// <returns>int</returns>
        public int Login(string username, string password)
        {
            var result = db.Customers.SingleOrDefault(x => x.Account == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == password)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// function to check for existing account in db
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="password">string</param>
        /// <returns>int</returns>
        public int CheckUsername(string username,string password)
        {
            var result = db.Customers.SingleOrDefault(x => x.Account == username);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.Password == password)
                {
                    return 1;
                }
                return -1;
            }
        }

        /// <summary>
        /// function to save customer updates
        /// </summary>
        /// <param name="entity">Customer</param>
        /// <returns>int</returns>
        public int UpdateUser(Customer entity)
        {
            try
            {
                var kh = db.Customers.Find(entity.CustomerID);
                kh.CustomerName = entity.CustomerName;
                kh.Email = entity.Email;
                kh.Address = entity.Address;
                kh.Phone = entity.Phone;
                kh.DateOfBirth = entity.DateOfBirth;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }



    }
}