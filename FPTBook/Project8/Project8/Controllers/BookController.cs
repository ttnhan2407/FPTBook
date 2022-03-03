using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookstore.Models.Data;
using FPTBookstore.Models.Process;
using PagedList;
using PagedList.Mvc;

namespace FPTBookstore.Controllers
{
	public class BookController : Controller
	{
		BSDBContext db = new BSDBContext();
		// GET: Book
		public ActionResult Index()
		{
			return View();
		}

		//GET : /Book/TopDateBook : show 6 new books updated by update date
		//Parital View : TopDateBook
		public ActionResult TopDateBook()
		{
			var result = new BookProcess().NewDateBook(6);
			return PartialView(result);
		}

		//GET : /Book/Details/:id : display details of book information
		public ActionResult Details(int id)
		{
			var result = new AdminProcess().GetIdBook(id);

			return View(result);
		}

		//GET : /Book/Favorite : show 3 best-selling books by update date (top silde)
		//Parital View : FavoriteBook
		public ActionResult FavoriteBook()
		{
			var result = new BookProcess().NewDateBook(3);

			return PartialView(result);
		}

		//GET : /Book/DidYouSee : display 3 books descending by date
		//Parital View : DidYouSee
		public ActionResult DidYouSee()
		{
			var result = new BookProcess().TakeBook(3);

			return PartialView(result);
		}

		//GET : /Book/All : show all books in db
		public ActionResult ShowAllBook(int? page)
		{
			//create the product variable on the page
			int pageSize = 10;

			//create the page number variable
			int pageNumber = (page ?? 1);

			var result = new BookProcess().ShowAllBook().ToPagedList(pageNumber, pageSize);

			return View(result);
		}

	}
}