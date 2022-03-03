using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookstore.Models.Data;
using FPTBookstore.Models.Process;
using System.IO;
using FPTBookstore.Areas.Admin.Code;

namespace FPTBookstore.Areas.Admin.Controllers
{
    [SessionAuthorize]
    public class HomeController : Controller
    {
        //Management page

        // Initialize data variable : db
        BSDBContext db = new BSDBContext();

        // GET: Admin/Home : Admin homepage
        public ActionResult Index()
        {
            return View();
        }

        #region Product

        //GET : Admin/Home/ShowListBook : Book management page
        [HttpGet]
        public ActionResult ShowListBook()
        {
            // Call the ListAllBook function and pass the View return model
            var model = new AdminProcess().ListAllBook();

            return View(model);
        }

        //GET : Admin/Home/AddBook : Add new book page
        public ActionResult AddBook()
        {
            //get the code that displays the name
            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(x => x.CategoryName), "CategoryID", "CategoryName");
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(x => x.PublisherName), "PublisherID", "PublisherName");
            ViewBag.AuthorID = new SelectList(db.Authors.ToList().OrderBy(x => x.AuthorName), "AuthorID", "AuthorName");

            return View();
        }

        //POST : Admin/Home/AddBook : add books
        [HttpPost]
        public ActionResult AddBook(Book book, HttpPostedFileBase fileUpload)
        {
            //get the code that displays the name
            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(x => x.CategoryName), "CategoryID", "CategoryName");
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(x => x.PublisherName), "PublisherID", "PublisherName");
            ViewBag.AuthorID = new SelectList(db.Authors.ToList().OrderBy(x => x.AuthorName), "AuthorID", "AuthorName");

            //check image upload
            if (fileUpload == null)
            {
                ViewBag.Alert = "Please choose a cover photo";
                return View();
            }
            else
            {
                //check if db data is valid?
                if (ModelState.IsValid)
                {
                    //get file path
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //pass file path and compile to /images
                    var path = Path.Combine(Server.MapPath("/images"), fileName);

                    //check image path exists?
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Alert = "Image already exists";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }

                    //execute the image link to the cover image link
                    book.Image = fileName;
                    //do save to db
                    var result = new AdminProcess().InsertBook(book);
                    if (result > 0)
                    {
                        ViewBag.Success = "Successfully added";
                        //delete state to add new
                        ModelState.Clear();
                    }
                    else
                    {
                        ModelState.AddModelError("", "add failed.");
                    }
                }
            }

            return View();
        }

        //GET : Admin/Home/DetailsBook/:id : Detail page for a book
        [HttpGet]
        public ActionResult DetailsBook(int id)
        {
            //call the function to get the book id and pass it to the View
            var book = new AdminProcess().GetIdBook(id);

            return View(book);
        }

        public ActionResult UpdateBook(int id)
        {
            //call the function to get the code
            var book = new AdminProcess().GetIdBook(id);

            // perform code retrieval but display the name and correct at the specified code and assign it to the ViewBag
            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(x => x.CategoryName), "CategoryID", "CategoryName", book.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(x => x.PublisherName), "PublisherID", "PublisherName", book.PublisherID);
            ViewBag.AuthorID = new SelectList(db.Authors.ToList().OrderBy(x => x.AuthorName), "AuthorID", "AuthorName", book.AuthorID);

            return View(book);
        }

        //POST : /Admin/Home/UpdateBook : perform book update
        //Similar to adding books
        [HttpPost]
        public ActionResult UpdateBook(Book book, HttpPostedFileBase fileUpload)
        {
            // do get the code but display the name right after the selected code and assign it to the ViewBag
            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(x => x.CategoryName), "CategoryID", "CategoryName", book.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(x => x.PublisherName), "PublisherID", "PublisherName", book.PublisherID);
            ViewBag.AuthorID = new SelectList(db.Authors.ToList().OrderBy(x => x.AuthorName), "AuthorID", "AuthorName", book.AuthorID);

            //If you don't change the cover photo, do it
            if (fileUpload == null)
            {
                //check data validity
                if (ModelState.IsValid)
                {
                    //call the UpdateBook function for updating the book
                    var result = new AdminProcess().UpdateBook(book);

                    if (result == 1)
                    {
                        ViewBag.Success = "Update successful";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update failed.");
                    }
                }
            }
            //if you change the cover photo, do it
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("/images"), fileName);

                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Alert = "Image already exists";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }

                    book.Image = fileName;
                    var result = new AdminProcess().UpdateBook(book);
                    if (result == 1)
                    {
                        ViewBag.Success = "Update successful";
                    }
                    else
                    {
                        ModelState.AddModelError("", "update failed.");
                    }
                }
            }

            return View(book);
        }

        //DELETE : Admin/Home/DeleteBook/:id : delete 1 book
        [HttpDelete]
        public ActionResult DeleteBook(int id)
        {
            //call the DeleteBook function to delete it
            new AdminProcess().DeleteBook(id);

            //return the book management page
            return RedirectToAction("ShowListBook");
        }

        //Category

        //GET : /Admin/Home/Show List Category : category management page
        [HttpGet]
        public ActionResult ShowListCategory()
        {
            //call the ListAllCategory function to display the categories in the db
            var model = new AdminProcess().ListAllCategory();

            return View(model);
        }

        //GET : Admin/Home/AddCategory : category add page
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        //POST : Admin/Home/AddCategory/:model : add category to db
        [HttpPost]
        public ActionResult AddCategory(Category model)
        {
            //check valid data
            if (ModelState.IsValid)
            {
                //initialize the admin variable in the FPTBookstore.Models.Process
                var admin = new AdminProcess();

                //initialize variable of category object in db
                var tl = new Category();

                //assign the category name attribute
                tl.CategoryName = model.CategoryName;

                //call the function to add category (InsertCategory) in the variable admin
                var result = admin.InsertCategory(tl);

                //test function
                if (result > 0)
                {
                    ViewBag.Success = "Successfully added";
                    //delete state
                    ModelState.Clear();

                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Add failed.");
                }
            }

            return View(model);
        }

        //GET : Admin/Home/UpdateCategory/:id : category update page
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            //call the function to get the category code
            var tl = new AdminProcess().GetIdCategory(id);

            //return the corresponding View data
            return View(tl);
        }

        //POST : /Admin/Home/UpdateCategory/:id : perform category update
        [HttpPost]
        public ActionResult UpdateCategory(Category tl)
        {
            //check data validity
            if (ModelState.IsValid)
            {
                //initialize variable admin
                var admin = new AdminProcess();

                //call the function to update the category
                var result = admin.UpdateCategory(tl);

                //do a test
                if (result == 1)
                {
                    return RedirectToAction("ShowListCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Update failed.");
                }
            }

            return View(tl);
        }

        //DELETE : /Admin/Home/DeleteCategory:id : perform category deletion
        [HttpDelete]
        public ActionResult DeleteCategory(int id)
        {
            // call the delete category function
            new AdminProcess().DeleteCategory(id);

            //return category management page
            return RedirectToAction("ShowListCategory");
        }

        //Author

        //GET : /Admin/Home/ShowListAuthor : author management page
        [HttpGet]
        public ActionResult ShowListAuthor()
        {
            //call the function to output the list of authors in db
            var model = new AdminProcess().ListAllAuthor();

            //return the corresponding View
            return View(model);
        }

        //GET : /Admin/Home/AddAuthor : add author page
        public ActionResult AddAuthor()
        {
            return View();
        }

        //POST : /Admin/Home/AddAuthor/:model : perform adding author
        [HttpPost]
        public ActionResult AddAuthor(Author model)
        {
            //check data validity
            if (ModelState.IsValid)
            {
                //initialize variable admin
                var admin = new AdminProcess();

                //initialize object tg
                var tg = new Author();

                //gán dữ liệu
                tg.AuthorName = model.AuthorName;
                tg.Hometown = model.Hometown;
                tg.DateOfBirth = model.DateOfBirth;
                tg.DateOfDeath = model.DateOfDeath;
                tg.Biographic = model.Biographic;

                //call the function to add author
                var result = admin.InsertAuthor(tg);

                //test function
                if (result > 0)
                {
                    ViewBag.Success = "Successfully added";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Add failed.");
                }
            }

            return View(model);
        }

        //GET : /Admin/Home/UpdateAuthor/:id : page add author
        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            //call the function to get the author's code
            var tg = new AdminProcess().GetIdAuthor(id);

            return View(tg);
        }

        //POST : /Admin/Home/UpdateAuthor/:id : perform adding author
        [HttpPost]
        public ActionResult UpdateAuthor(Author tg)
        {
            //check data validity
            if (ModelState.IsValid)
            {
                //initialize variable admin
                var admin = new AdminProcess();

                //call author update function
                var result = admin.UpdateAuthor(tg);
                //execute test
                if (result == 1)
                {
                    ViewBag.Success = "Update successful";
                }
                else
                {
                    ModelState.AddModelError("", "Update failed.");
                }
            }

            return View(tg);
        }

        //DELETE : /Admin/Home/DeleteAuthor/:id : perform author deletion
        [HttpDelete]
        public ActionResult DeleteAuthor(int id)
        {
            //call the function to remove the author
            new AdminProcess().DeleteAuthor(id);

            return RedirectToAction("ShowListAuthor");
        }

        //Publish

        //GET : /Admin/Home/ShowListPublish : publisher management page
        [HttpGet]
        public ActionResult ShowListPublish()
        {
            //call the function to output the publisher list
            var model = new AdminProcess().ListAllPublish();

            return View(model);
        }

        //GET : /Admin/Home/AddPublish : publisher management page
        public ActionResult AddPublish()
        {
            return View();
        }

        //POST : /Admin/Home/AddPublish/:model : perform adding publisher
        [HttpPost]
        public ActionResult AddPublish(Publisher model)
        {
            //check data validity
            if (ModelState.IsValid)
            {
                //initialize variable admin
                var admin = new AdminProcess();

                //initialize the publisher object
                var nxb = new Publisher();

                //assign data
                nxb.PublisherName = model.PublisherName;
                nxb.Address = model.Address;
                nxb.Phone = model.Phone;

                //call the function to add publisher
                var result = admin.InsertPublish(nxb);
                //test function
                if (result > 0)
                {
                    ViewBag.Success = "Successfully added";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Add failed.");
                }
            }

            return View(model);
        }

        //GET : /Admin/Home/UpdatePublish/:id : page add publisher
        [HttpGet]
        public ActionResult UpdatePublish(int id)
        {
            //call the function to get the publisher code
            var nxb = new AdminProcess().GetIdPublish(id);

            return View(nxb);
        }

        //GET : /Admin/Home/UpdatePublish/:id : perform add publisher
        [HttpPost]
        public ActionResult UpdatePublish(Publisher nxb)
        {
            //check data validity
            if (ModelState.IsValid)
            {
                //initialize variable admin
                var admin = new AdminProcess();

                //call publisher update function
                var result = admin.UpdatePublish(nxb);
                //test function
                if (result == 1)
                {
                    ViewBag.Success = "Update successful";
                }
                else
                {
                    ModelState.AddModelError("", "Update failed.");
                }
            }

            return View(nxb);
        }

        //DELETE : Admin/Home/DeletePublish/:id : delete publisher
        [HttpDelete]
        public ActionResult DeletePublish(int id)
        {
            //call delete function publish function
            new AdminProcess().DeletePublish(id);

            //return publisher management page
            return RedirectToAction("ShowListPublish");
        }

        #endregion

        #region Feedback

        //Contact/Feedback : Contact / customer feedback

        [HttpGet]
        //GET : Admin/Home/FeedBack : view the list of response messages
        public ActionResult FeedBack()
        {
            var result = new AdminProcess().ShowListContact();

            return View(result);
        }

        //GET : Admin/Home/FeedDetail/:id : view customer feedback
        public ActionResult FeedDetail(int id)
        {
            var result = new AdminProcess().GetIdContact(id);

            return View(result);
        }

        //DELETE : Admin/Home/DeleteFeedBack/:id : delete customer feedback
        [HttpDelete]
        public ActionResult DeleteFeedBack(int id)
        {
            new AdminProcess().deleteContact(id);

            return RedirectToAction("FeedBack");
        }

        #endregion

        #region User

        //GET : /Admin/Home/ShowUser : user management page
        public ActionResult ShowUser()
        {
            var result = new AdminProcess().ListUser();

            return View(result);
        }

        //GET : /Admin/Home/Detail User/:id : user details page
        public ActionResult DetailsUser(int id)
        {
            var result = new AdminProcess().GetIdCustomer(id);

            return View(result);
        }

        //DELETE : Admin/Home/DeleteUser/:id : delete user information
        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            new AdminProcess().DeleteUser(id);

            return RedirectToAction("ShowUser");
        }

        #endregion

        #region The order

        //GET : Admin/Home/Order : order management page
        public ActionResult Order()
        {
            var result = new OrderProcess().ListOrder();

            return View(result);
        }

        //GET : /Admin/Home/DetailsOrder : order detail page
        public ActionResult DetailsOrder(int id)
        {
            var result = new OderDetailProcess().ListDetail(id);

            return View(result);
        }

        #endregion

    }
}