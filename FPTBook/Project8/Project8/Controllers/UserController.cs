using FPTBookstore.Areas.Admin.Models;
using FPTBookstore.Models.Data;
using FPTBookstore.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace FPTBookstore.Controllers
{
    public class UserController : Controller
    {
        // Initialize data variable : db
        BSDBContext db = new BSDBContext();
        public static Customer customerstatic;
        [HttpGet]
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //GET: /User/Register : register a member account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //POST: /User/Register : save user account registration data
        public ActionResult Register(Customer model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserProcess();

                var kh = new Customer();

                if (user.CheckUsername(model.Account, model.Password) == 1)
                {
                    ModelState.AddModelError("", "Account already exists");
                }
                else if (user.CheckUsername(model.Account, model.Password) == -1)
                {
                    ModelState.AddModelError("", "Account already exists");
                }
                else
                {
                    kh.Account = model.Account;
                    kh.Password = model.Password;
                    kh.CustomerName = model.CustomerName;
                    kh.Email = model.Email;
                    kh.Address = model.Address;
                    kh.Phone = model.Phone;
                    kh.DateOfBirth = model.DateOfBirth;
                    kh.DateCreate = DateTime.Now;
                    kh.Status = false;
                    
                    var result = user.InsertUser(kh);
                    
                    var idUser = db.Customers.FirstOrDefault(n => n.Email == kh.Email && n.CustomerName == kh.CustomerName);
                    BuildUserTemplate(idUser.CustomerID);
                    if (result > 0)
                    {
                        //Session["User"] = result;
                        ModelState.Clear();
                        //return Redirect("/Home/");
                        //ModelState.AddModelError("", "Please Check Email Account Activation !");
                        return RedirectToAction("CheckActivationNotification", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Registration failed.");
                    }
                }
                            
            }

            return View(model);
        }

        public ActionResult Confirm(int khCustomerID)
        {
            ViewBag.CustomerID = khCustomerID;
            return View();
        }

        public JsonResult ConfirmEmail(int khCustomerID)
        {
            Customer Data = db.Customers.Where(x => x.CustomerID == khCustomerID).FirstOrDefault();
            Data.Status = true;
            db.SaveChanges();
            var msg = "Email Confirmed!";
            Session["User"] = null;
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public void BuildUserTemplate(int khCustomerID)
        {
            string body =
                System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
            var inforKH = db.Customers.Where(x => x.CustomerID == khCustomerID).First();
            var url = "https://FPTBookstore.cf/" + "User/Confirm?khCustomerID=" + khCustomerID;
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate("Account Created Successfully", body, inforKH.Email);

        }

        public void BuildEmailTemplate(string subjectText, string bodyText, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = "FPTBookstore@gmail.com";
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }

            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(body, new ContentType("text/html")));
            SendEmail(mail);
        }

        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("webbansach17dtha3@gmail.com", "webbansach123");

        }

        public ActionResult ActivationNotice()
        {
            return View();
        }
        public ActionResult CheckActivationNotification()
        {
            return View();
        }

        //GET : /User/LoginPage : login page

        public ActionResult LoginPage()
        {
            return View();
        }

        //POST : /User/LoginPage : perform login
        [HttpPost]
        public ActionResult LoginPage(LoginModel model)
        {
            //check data validity
            if (ModelState.IsValid)
            {
                //call login function in AdminProcess and assign data in model variable
                var result = new UserProcess().Login(model.Account, model.Password);
                //If right
                if (result == 1)
                {
                    //assign Session["LoginAdmin"] with logged in data
                    Session["User"] = model.Account;
                    var kh = db.Customers.Where(x => x.Account == model.Account).FirstOrDefault();
                    customerstatic = kh;
                    //return home page
                    return RedirectToAction("Index", "Home");
                }
                //if the account doesn't exist
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Account does not exist.");
                    //return RedirectToAction("LoginPage", "User");
                }
                //if you enter the wrong account or password
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Incorrect account or password");
                    //return RedirectToAction("LoginPage", "User");
                }
            }

            return View();
        }

        //GET : /User/Login : login account
        //Parital View : Login

        [ChildActionOnly]
        public ActionResult Login()
        {
            return PartialView();
        }

        //POST : /User/Login : perform login
        [HttpPost]
        [ChildActionOnly]
        public ActionResult Login(LoginModel model)
        {
            //check data validity
            if (ModelState.IsValid)
            {
                //call login function in AdminProcess and assign data in model variable
                var result = new UserProcess().Login(model.Account, model.Password);

                //If right
                if (result == 1)
                {
                    //assign Session["LoginAdmin"] with logged in data
                    Session["User"] = model.Account;
                    var kh = db.Customers.Where(x => x.Account == model.Account).FirstOrDefault();
                    customerstatic = kh;
                    //return home page
                    return RedirectToAction("Index", "Home");
                }
                //if the account doesn't exist
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Account does not exist.");
                    //return RedirectToAction("LoginPage", "User");
                }
                //if you enter the wrong account or password
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Incorrect account or password");
                    //return RedirectToAction("LoginPage", "User");
                }
            }

            return PartialView();
        }

        //GET : /User/Logout : logout customer account
        [HttpGet]
        public ActionResult Logout()
        {
            Session["User"] = null;
            customerstatic = null;
            return RedirectToAction("Index", "Home");
        }

        //GET : /User/EditUser : update customer information
        [HttpGet]
        public ActionResult EditUser()
        {
            // get data from session
            var model = Session["User"];

            if (ModelState.IsValid)
            {
                //find account name
                var result = db.Customers.SingleOrDefault(x => x.Account == model);

                //return the corresponding data
                return View(result);
            }

            return View();
        }

        //POST : /User/EditUser : update customer information
        [HttpPost]
        public ActionResult EditUser(Customer model)
        {
            if (ModelState.IsValid)
            {
                //call the function to update customer information
                var result = new UserProcess().UpdateUser(model);

                //do a test
                if (result == 1)
                {
                    return RedirectToAction("EditUser");                  
                }
                else
                {
                    ModelState.AddModelError("", "Update failed.");
                }
            }

            return View(model);
        }

    }
}