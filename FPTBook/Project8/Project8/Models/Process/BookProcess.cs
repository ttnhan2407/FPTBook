using FPTBookstore.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTBookstore.Models.Process
{
    public class BookProcess
    {
        // Initialize data variable : db
        BSDBContext db = null;

        //constructor : initialize object
        public BookProcess()
        {
            db = new BSDBContext();
        }

        /// <summary>
        /// get the latest book by update date
        /// </summary>
        /// <param name="count">int</param>
        /// <returns>List</returns>
        public List<Book> NewDateBook(int count)
        {
            return db.Books.OrderByDescending(x => x.DateUpdate).Take(count).ToList();
        }

        /// <summary>
        /// filter books by subject
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>List</returns>
        public List<Book> ThemeBook(int id)
        {
            return db.Books.Where(x => x.CategoryID == id).ToList();
        }

        /// <summary>
        /// Get selected books
        /// </summary>
        /// <param name="count">int</param>
        /// <returns>List</returns>
        public List<Book> TakeBook(int count)
        {
            return db.Books.OrderBy(x => x.DateUpdate).Take(count).ToList();
        }

        /// <summary>
        /// View all books
        /// </summary>
        /// <returns>List</returns>
        public List<Book> ShowAllBook()
        {
            return db.Books.OrderBy(x => x.BookID).ToList();
        }

    }
}