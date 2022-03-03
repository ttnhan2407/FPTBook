using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookstore.Models.Process;
using FPTBookstore.Areas.Admin.Models;
using FPTBookstore.Models.Data;

namespace FPTBookstore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //Admin login page

        // Initialize data variable : db
        BSDBContext db = new BSDBContext();

        // GET: Admin/Login : login page
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Admin/Login/AdminProfile : button to view information about the administrator
        //Partial View : AdminProfile
        public ActionResult AdminProfile()
        {
            return PartialView();
        }

        //GET : /Admin/Login/AdminInfo : admin information page
        public ActionResult AdminInfo()
        {
            //get session data
            var model = Session["LoginAdmin"];

            //check data validity
            if (ModelState.IsValid)
            {
                if (Session["LoginAdmin"] != null)
                {
                    //compare and find the account name
                    var result = db.Admins.SingleOrDefault(x => x.Account == model);
                    //return corresponding data in View
                    return View(result);
                }             
            }

            return View();
        }

        //GET : /Admin/Login/Logout : admin account logout page
        public ActionResult Logout()
        {
            //set session with null
            Session["LoginAdmin"] = null;

            //return login page
            return Redirect("/Admin/Login");
        }

        //POST : /Admin/Login/Index : perform administrator login
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            //check data validity
            if (ModelState.IsValid)
            {
                //call login function in AdminProcess and assign data in model variable
                var result = new AdminProcess().Login(model.Account, model.Password);
                //If right
                if (result == 1)
                {
                    //assign Session["LoginAdmin"] with logged in data
                    Session["LoginAdmin"] = model.Account;

                    //return the management page
                    return RedirectToAction("Index", "Home");                
                }
                //if the account doesn't exist
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Account does not exist.");
                }
                //if you enter the wrong account or password
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Incorrect account or password");
                }
            }

            return View();
        }
    }
}