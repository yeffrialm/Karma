using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Karma.Models;

namespace Karma.Controllers
{
    public class DetallesOrdenesController : Controller
    {
        private KarmaEntities db = new KarmaEntities();

        [Authorize(Users = "yeffri13@gmail.com")]

        // GET: DetallesOrdenes
        public ActionResult Index()
        {
            var detallesOrdenes = db.DetallesOrdenes.Include(d => d.Ordenes).Include(d => d.Producto);
            return View(detallesOrdenes.ToList());
        }

        // GET: DetallesOrdenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallesOrdenes detallesOrdenes = db.DetallesOrdenes.Find(id);
            if (detallesOrdenes == null)
            {
                return HttpNotFound();
            }
            return View(detallesOrdenes);
        }

        // GET: DetallesOrdenes/Create
        public ActionResult Create()
        {
            ViewBag.OrdenesID = new SelectList(db.Ordenes, "OrdenesID", "ClienteID");
            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "NombreProducto");
            return View();
        }

        // POST: DetallesOrdenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdenesID,ProductoID,PrecioUnidad,Cantidad")] DetallesOrdenes detallesOrdenes)
        {
            if (ModelState.IsValid)
            {
                db.DetallesOrdenes.Add(detallesOrdenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrdenesID = new SelectList(db.Ordenes, "OrdenesID", "ClienteID", detallesOrdenes.OrdenesID);
            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "NombreProducto", detallesOrdenes.ProductoID);
            return View(detallesOrdenes);
        }

        // GET: DetallesOrdenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallesOrdenes detallesOrdenes = db.DetallesOrdenes.Find(id);
            if (detallesOrdenes == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrdenesID = new SelectList(db.Ordenes, "OrdenesID", "ClienteID", detallesOrdenes.OrdenesID);
            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "NombreProducto", detallesOrdenes.ProductoID);
            return View(detallesOrdenes);
        }

        // POST: DetallesOrdenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrdenesID,ProductoID,PrecioUnidad,Cantidad")] DetallesOrdenes detallesOrdenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallesOrdenes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrdenesID = new SelectList(db.Ordenes, "OrdenesID", "ClienteID", detallesOrdenes.OrdenesID);
            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "NombreProducto", detallesOrdenes.ProductoID);
            return View(detallesOrdenes);
        }

        // GET: DetallesOrdenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallesOrdenes detallesOrdenes = db.DetallesOrdenes.Find(id);
            if (detallesOrdenes == null)
            {
                return HttpNotFound();
            }
            return View(detallesOrdenes);
        }

        // POST: DetallesOrdenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetallesOrdenes detallesOrdenes = db.DetallesOrdenes.Find(id);
            db.DetallesOrdenes.Remove(detallesOrdenes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
