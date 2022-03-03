using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FPTBookstore.Models.Data;

namespace FPTBookstore.Models.Process
{
    public class HomeProcess
    {
        // Initialize data variable : db
        BSDBContext db = null;

        //constructor : initialize object
        public HomeProcess()
        {
            db = new BSDBContext();
        }

        /// <summary>
        /// function to output category list
        /// </summary>
        /// <returns></returns>
        public List<Category> ListCategory()
        {
            return db.Categories.OrderBy(x => x.CategoryID).ToList();
        }

        /// <summary>
        /// function to save the feedback from the client in db
        /// </summary>
        /// <param name="entity">Feedback</param>
        /// <returns>int</returns>
        public int InsertContact(Feedback entity)
        {
            db.Feedbacks.Add(entity);
            db.SaveChanges();

            return entity.FBID;
        }

        /// <summary>
        /// book title search function
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>List</returns>
        public List<Book> Search(string key)
        {
            return db.Books.Where(x => x.BookName.Contains(key)).OrderBy(x=>x.BookName).ToList();
        }

    }
}