using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FPTBookstore.Models.Data;

namespace FPTBookstore.Models.Process
{
    public class AdminProcess
    {
        //Data processing layer

        BSDBContext db = null;

        //constructor
        public AdminProcess()
        {
            db = new BSDBContext();
        }

        /// <summary>
        /// Login function
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="password">string</param>
        /// <returns>int</returns>
        public int Login(string username, string password)
        {
            var result = db.Admins.SingleOrDefault(x => x.Account == username);
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

        //Get ID : get code

        #region get the code

        /// <summary>
        /// function to get admin code
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Admin</returns>
        public Admin GetIdAdmin(int id)
        {
            return db.Admins.Find(id);
        }

        /// <summary>
        /// function to get the book's code
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Book</returns>
        public Book GetIdBook(int id)
        {
            return db.Books.Find(id);
        }

        /// <summary>
        /// function to get category code
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Category</returns>
        public Category GetIdCategory(int id)
        {
            return db.Categories.Find(id);
        }

        /// <summary>
        /// function get author code
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Author</returns>
        public Author GetIdAuthor(int id)
        {
            return db.Authors.Find(id);
        }

        /// <summary>
        /// function get publisher code
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Publisher</returns>
        public Publisher GetIdPublish(int id)
        {
            return db.Publishers.Find(id);
        }

        /// <summary>
        /// Function to get customer code to visit
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Customer</returns>
        public Customer GetIdCustomer(int id)
        {
            return db.Customers.Find(id);
        }

        /// <summary>
        /// function get order code
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Order</returns>
        public Order GetIdOrder(int id)
        {
            return db.Orders.Find(id);
        }

        /// <summary>
        /// function get contact (feedback) code
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Feedback</returns>
        public Feedback GetIdContact(int id)
        {
            return db.Feedbacks.Find(id);
        }

        #endregion

        //Category : category

        #region category

        /// <summary>
        /// function to output category list
        /// </summary>
        /// <returns>List</returns>
        public List<Category> ListAllCategory()
        {
            return db.Categories.OrderBy(x => x.CategoryID).ToList();
        }

        /// <summary>
        /// function to add category
        /// </summary>
        /// <param name="entity">Category</param>
        /// <returns>int</returns>
        public int InsertCategory(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.CategoryID;
        }

        /// <summary>
        /// function to update category
        /// </summary>
        /// <param name="entity">Category</param>
        /// <returns>int</returns>
        public int UpdateCategory(Category entity)
        {
            try
            {
                var tl = db.Categories.Find(entity.CategoryID);
                tl.CategoryName = entity.CategoryName;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// function to delete category
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool DeleteCategory(int id)
        {
            try
            {
                var tl = db.Categories.Find(id);
                db.Categories.Remove(tl);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        //Author : author

        #region author

        /// <summary>
        /// function that outputs a list of authors
        /// </summary>
        /// <returns>List</returns>
        public List<Author> ListAllAuthor()
        {
            return db.Authors.OrderBy(x => x.AuthorID).ToList();
        }

        /// <summary>
        /// function to add author
        /// </summary>
        /// <param name="entity">Author</param>
        /// <returns></returns>
        public int InsertAuthor(Author entity)
        {
            db.Authors.Add(entity);
            db.SaveChanges();
            return entity.AuthorID;
        }

        /// <summary>
        /// author update function
        /// </summary>
        /// <param name="entity">Author</param>
        /// <returns>int</returns>
        public int UpdateAuthor(Author entity)
        {
            try
            {
                var tg = db.Authors.Find(entity.AuthorID);
                tg.AuthorName = entity.AuthorName;
                tg.Hometown = entity.Hometown;
                tg.DateOfBirth = entity.DateOfBirth;
                tg.DateOfDeath = entity.DateOfDeath;
                tg.Biographic = entity.Biographic;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// function to remove the author
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>int</returns>
        public bool DeleteAuthor(int id)
        {
            try
            {
                var tg = db.Authors.Find(id);
                db.Authors.Remove(tg);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


        //Publish : publisher

        #region publisher

        /// <summary>
        /// function to output publisher list
        /// </summary>
        /// <returns>List</returns>
        public List<Publisher> ListAllPublish()
        {
            return db.Publishers.OrderBy(x => x.PublisherID).ToList();
        }

        /// <summary>
        /// function to add publisher
        /// </summary>
        /// <param name="entity">Publisher</param>
        /// <returns>int</returns>
        public int InsertPublish(Publisher entity)
        {
            db.Publishers.Add(entity);
            db.SaveChanges();
            return entity.PublisherID;
        }

        /// <summary>
        /// publisher update function
        /// </summary>
        /// <param name="entity">Publisher</param>
        /// <returns>int</returns>
        public int UpdatePublish(Publisher entity)
        {
            try
            {
                var nxb = db.Publishers.Find(entity.PublisherID);
                nxb.PublisherName = entity.PublisherName;
                nxb.Address = entity.Address;
                nxb.Phone = entity.Phone;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// function to remove publisher
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool DeletePublish(int id)
        {
            try
            {
                var nxb = db.Publishers.Find(id);
                db.Publishers.Remove(nxb);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


        //Books : book

        #region book

        /// <summary>
        /// function to output a list of Books
        /// </summary>
        /// <returns>List</returns>
        public List<Book> ListAllBook()
        {
            return db.Books.OrderBy(x => x.BookID).ToList();
        }

        /// <summary>
        /// function to add books
        /// </summary>
        /// <param name="entity">Book</param>
        /// <returns>int</returns>
        public int InsertBook(Book entity)
        {
            db.Books.Add(entity);
            db.SaveChanges();
            return entity.BookID;
        }

        /// <summary>
        /// book update function
        /// </summary>
        /// <param name="entity">Book</param>
        /// <returns>int</returns>
        public int UpdateBook(Book entity)
        {
            try
            {
                var book = db.Books.Find(entity.BookID);
                book.CategoryID = entity.CategoryID;
                book.PublisherID = entity.PublisherID;
                book.AuthorID = entity.AuthorID;
                book.BookName = entity.BookName;
                book.Price = entity.Price;
                book.Description = entity.Description;
                book.Translator = entity.Translator;
                book.Image = entity.Image;
                book.DateUpdate = entity.DateUpdate;
                book.Inventory = entity.Inventory;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// function to delete a book
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool DeleteBook(int id)
        {
            try
            {
                var book = db.Books.SingleOrDefault(x => x.BookID == id);
                db.Books.Remove(book);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        // Contact (feedback) from customer

        #region Customer Feedback

        /// <summary>
        /// function to get a list of feedback from customers
        /// </summary>
        /// <returns>List</returns>
        public List<Feedback> ShowListContact()
        {
            return db.Feedbacks.OrderBy(x => x.FBID).ToList();
        }

        /// <summary>
        /// function to delete customer feedback
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool deleteContact(int id)
        {
            try
            {
                var contact = db.Feedbacks.Find(id);
                db.Feedbacks.Remove(contact);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        //User management

        /// <summary>
        /// user list output function
        /// </summary>
        /// <returns>List</returns>
        public List<Customer> ListUser()
        {
            return db.Customers.OrderBy(x => x.CustomerID).ToList();
        }

        /// <summary>
        /// user delete function
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool DeleteUser(int id)
        {
            try
            {
                var user = db.Customers.Find(id);
                db.Customers.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}