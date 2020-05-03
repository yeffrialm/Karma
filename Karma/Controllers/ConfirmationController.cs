using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karma.Controllers
{
    public class ConfirmationController : Controller
    {
        // GET: Confirmation
        [Authorize]
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}