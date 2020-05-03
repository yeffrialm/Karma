using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karma.Models;

namespace Karma.Controllers
{
    public class SingleController : Controller
    {
        // GET: Single
        private KarmaEntities Ce = new KarmaEntities();
        public ActionResult Single()
        {
            return View(Ce.Producto.ToList().OrderBy(x => x.NombreProducto));
        }
    }
}