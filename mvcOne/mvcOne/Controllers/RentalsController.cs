using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcOne.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult Index()
        {
            return View();
        }
    }
}