using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karma.Controllers
{   
   
    public class CheckoutController : Controller
    {
        [Authorize]
        // GET: Checkout
        public ActionResult Checkout()
        {
            return View();
        }
    }
}