using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FPTBookstore.Models.Data;
using FPTBookstore.Models.Process;
using FPTBookstore.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project8.Models.Data;
using Project8.Models.Process;

namespace FPTBookstore.Controllers
{
    public class CartController : Controller
    {
        //initialize data
        BSDBContext db = new BSDBContext();

        //create a string constant to assign session
        private const string CartSession = "CartSession";

        // GET: Cart/ : cart page
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartModel>();
            var sl = 0;
            decimal? total = 0;
            if (cart != null)
            {
                list = (List<CartModel>)cart;
                sl = list.Sum(x => x.Quantity);
                total = list.Sum(x => x.Total);
            }
            ViewBag.Quantity = sl;
            ViewBag.Total = total;
            return View(list);
        }

        //GET : /Cart/CartHeader : count the products in the cart
        //PartialView : CartHeader
        public ActionResult CartHeader()
        {
            var cart = Session[CartSession];
            var list = new List<CartModel>();
            if (cart != null)
            {
                list = (List<CartModel>)cart;
            }

            return PartialView(list);
        }

        //Delete 1 product in cart
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartModel>)Session[CartSession];
            //delete values that have the same code as id
            sessionCart.RemoveAll(x => x.book.BookID == id);
            //assign the value to session
            Session[CartSession] = sessionCart;

            return Json(new
            {
                status = true
            });
        }

        //Delete all products in cart
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        //Update cart
        public JsonResult Update(string cartModel)
        {
            //create a json object
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartModel>>(cartModel);

            //cast type from session
            var sessionCart = (List<CartModel>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.Single(x => x.book.BookID == item.book.BookID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            //update session
            Session[CartSession] = sessionCart;

            return Json(new
            {
                status = true
            });
        }

        //GET : /Cart/AddItem/?id=?&quantity=1 : add product to cart
        public ActionResult AddItem(int id, int quantity)
        {
            //get book code and assign object
            var book = new AdminProcess().GetIdBook(id);

            //get cart from session
            var cart = Session[CartSession];

            //if there is a product in the cart
            if (cart != null)
            {
                var list = (List<CartModel>)cart;
                if (list.Exists(x => x.book.BookID == id))
                {

                    foreach (var item in list)
                    {
                        if (item.book.BookID == id)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //create new cart item
                    var item = new CartModel();
                    item.book = book;
                    item.Quantity = quantity;
                    list.Add(item);
                }

                //Assign to session
                Session[CartSession] = list;
            }
            else
            {
                //create new cart
                var item = new CartModel();
                item.book = book;
                item.Quantity = quantity;
                var list = new List<CartModel>();
                list.Add(item);

                //assign to session
                Session[CartSession] = list;
            }

            return RedirectToAction("Index");
        }

        //Customer information
        [HttpGet]
        [ChildActionOnly]
        public PartialViewResult UserInfo()
        {
            // get data from session
            var model = Session["User"];

            if (ModelState.IsValid)
            {
                //find account name
                var result = db.Customers.SingleOrDefault(x => x.Account == model);

                //return the corresponding data
                return PartialView(result);
            }

            return PartialView();
        }

        [HttpGet]
        public ActionResult Payment()
        {
            //check login
            if (Session["User"] == null || Session["User"].ToString() == "")
            {
                return RedirectToAction("LoginPage", "User");
            }

            if (UserController.customerstatic.Status == false)
            {
                return RedirectToAction("ActivationNotice", "User");
            }
            else
            {
                var cart = Session[CartSession];
                var list = new List<CartModel>();
                var sl = 0;
                decimal? total = 0;
                if (cart != null)
                {
                    list = (List<CartModel>)cart;
                    sl = list.Sum(x => x.Quantity);
                    total = list.Sum(x => x.Total);
                }
                ViewBag.Quantity = sl;
                ViewBag.Total = total;
                return View(list);
            }
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [HttpPost]
        public ActionResult Payment(int CustomerID,FormCollection f)
        {
            var PMethod = int.Parse(f["PaymentMethod"]);
            var order = new Order();
            order.DateStart = DateTime.Now;
            order.DateEnd = DateTime.Now.AddDays(3);
            order.OrderStatus = true; //has received the goods
            order.CustomerID = CustomerID;
            
            try
            {
                if (PMethod == 1)
                {
                    //add data to order
                    order.Payment = 1;
                    var result1 = new OrderProcess().Insert(order);
                    var cart = (List<CartModel>)Session[CartSession];
                    var result2 = new OderDetailProcess();
                    decimal? total = 0;
                    foreach (var item in cart)
                    {
                        var orderDetail = new OrderDetail();
                        orderDetail.BookID = item.book.BookID;
                        orderDetail.OrderID = result1;
                        orderDetail.Quantity = item.Quantity;
                        orderDetail.Price = item.book.Price;
                        result2.Insert(orderDetail);

                        total = cart.Sum(x => x.Total);
                        
                    }

                    Session[CartSession] = null;
                    return Redirect("/Cart/Success");
                }
                else
                {
                    order.Payment = 0;
                    var result1 = new OrderProcess().Insert(order);
                    var cart = (List<CartModel>)Session[CartSession];
                    var result2 = new OderDetailProcess();
                    decimal? total = 0;
                    foreach (var item in cart)
                    {
                        var orderDetail = new OrderDetail();
                        orderDetail.BookID = item.book.BookID;
                        orderDetail.OrderID = result1;
                        orderDetail.Quantity = item.Quantity;
                        orderDetail.Price = item.book.Price;
                        result2.Insert(orderDetail);

                        total = cart.Sum(x => x.Total);
                    }
                    Session[CartSession] = null;
                    return Redirect(PaymentMoMo(result1.ToString(), 
                        total.ToString().Substring(0, total.ToString().Length - 5)));
                    

                }
            }
            catch (Exception)
            {
                return Redirect("/Cart/Error");
            }

            return new EmptyResult();

        }

        protected string PaymentMoMo(string OrderID, string total)
        {
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOHDRK20200430";
            string accessKey = "68tVdaHzCcvtfzwH";
            string serectkey = "8AWejATXBF96XL3CqeICtqiiKwheEUAv";
            string orderInfo = "OrderBook";
            string returnUrl = "";
            string notifyurl = "";

            string amount = total;
            string orderid = OrderID;
            string requestId = OrderID;
            string extraData = "";

            string rawHash = "partnerCode=" +
                             partnerCode + "&accessKey=" +
                             accessKey + "&requestId=" +
                             requestId + "&amount=" +
                             amount + "&orderId=" +
                             orderid + "&orderInfo=" +
                             orderInfo + "&returnUrl=" +
                             returnUrl + "&notifyUrl=" +
                             notifyurl + "&extraData=" +
                             extraData;

            log.Debug("rawHash = " + rawHash);
            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);
            log.Debug("Signature = " + signature);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };
            log.Debug("Json request to MoMo: " + message.ToString());
            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);
            log.Debug("Return from MoMo: " + jmessage.ToString());
            
            return jmessage.GetValue("payUrl").ToString();
            
        }
        public ActionResult Success()
        {
            return View();
        }

        public ActionResult TrackingOder()
        {
            List<Order> Order = db.Orders.Where(p => p.CustomerID == UserController.customerstatic.CustomerID).ToList();
            return View(Order);
        }
        public ActionResult TrackingOderDetails()
        {
            return View();
        }

        public JsonResult loadOrder()
        {
            //if (id!=null)
            //{
            db.Configuration.ProxyCreationEnabled = false;
            var Order = db.Orders.ToList();
            
            return Json(new {data= Order }
                , JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    List<Order> Order = db.Orders.Where(p => p.CustomerID == UserController.customerstatic.CustomerID).ToList();
            //    return Json(Order, JsonRequestBehavior.AllowGet);
            //}
        }
    }
}