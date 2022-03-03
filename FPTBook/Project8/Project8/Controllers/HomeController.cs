using FPTBookstore.Models.Data;
using FPTBookstore.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace FPTBookstore.Controllers
{
    public class HomeController : Controller
    {
        // Program homepage

        // Initialize data variable : db
        BSDBContext db = new BSDBContext();

        //GET : Home/ : homepage
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Home/ShowCategory : display the menu on the left side of the home page
        //Parital View : Showcategory
        public ActionResult ShowCategory()
        {
            //call the function to output the list of categories
            var result = new HomeProcess().ListCategory();

            return PartialView(result);
        }

        public ActionResult ThemesBook(int id)
        {
            var categoryname = new AdminProcess().GetIdCategory(id);
            ViewBag.CategoryName = categoryname.CategoryName;

            var result = new BookProcess().ThemeBook(id);
            return View(result);
        }

        //GET : Show About page
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        // Web site rules
        public ActionResult Regulation()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult Transport()
        {
            return View();
        }
        public ActionResult Exchange()
        {
            return View();
        }
        public ActionResult Help()
        {
            return View();
        }

        //GET : /Home/Contact : contact page, customer feedback
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "We are very pleased to hear from you!";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(Feedback model)
        {
            if (ModelState.IsValid)
            {
                var home = new HomeProcess();
                var lh = new Feedback();

                //assign data from client to model
                lh.FirstName = model.FirstName;
                lh.LastName = model.LastName;
                lh.Email = model.Email;
                lh.Phone = model.Phone;
                lh.Contents = model.Contents;
                lh.DateUpdate = DateTime.Now;

                //call the function to save the feedback from the client
                var result = home.InsertContact(lh);

                if (result > 0)
                {
                    ViewBag.success = "Your feedback has been received";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Recording error");
                }
            }

            return View(model);
        }

        //GET : /Home/SearchResult : book search page
        [HttpGet]
        public ActionResult SearchResult(int? page, string key)
        {
            ViewBag.Key = key;

            //paging
            int pageNumber = (page ?? 1);
            int pageSize = 6;

            var result = new HomeProcess().Search(key).ToPagedList(pageNumber, pageSize);

            if (result.Count == 0 || key==null || key=="")
            {
                ViewBag.Notification = "No product found";
                return View(result);
            }
            ViewBag.Notification = "Now available " + result.Count + " results on this page";

            return View(result);
        }

        //POST : /Home/SearchResult : perform a book search
        [HttpPost]
        public ActionResult SearchResult(int? page, FormCollection f)
        {
            //assign the search keyword entered from the client
            string key = f["txtSearch"].ToString();

            ViewBag.Key = key;

            //paging
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            
            var result = new HomeProcess().Search(key).ToPagedList(pageNumber, pageSize);

            if (result.Count == 0 || key == null || key == "")
            {
                ViewBag.Notification = "No product found";
                return View(result);
            }
            ViewBag.Notification = "Now available " + result.Count + " results on this page";

            return View(result);
        }

    }
}