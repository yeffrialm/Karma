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
    public class SuplidorController : Controller
    {
        private KarmaEntities db = new KarmaEntities();

        [Authorize(Users = "yeffri13@gmail.com")]

        // GET: Suplidors
        public ActionResult Index()
        {
            return View(db.Suplidor.ToList());
        }

        // GET: Suplidors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suplidor suplidor = db.Suplidor.Find(id);
            if (suplidor == null)
            {
                return HttpNotFound();
            }
            return View(suplidor);
        }

        // GET: Suplidors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suplidors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuplidorID,NombreEmpresa,NombreContacto,ContactoCargo,Direccion,Provincia,Municipio,CodigoPostal,pais,Telefono,PaginaWeb")] Suplidor suplidor)
        {
            if (ModelState.IsValid)
            {
                db.Suplidor.Add(suplidor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suplidor);
        }

        // GET: Suplidors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suplidor suplidor = db.Suplidor.Find(id);
            if (suplidor == null)
            {
                return HttpNotFound();
            }
            return View(suplidor);
        }

        // POST: Suplidors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuplidorID,NombreEmpresa,NombreContacto,ContactoCargo,Direccion,Provincia,Municipio,CodigoPostal,pais,Telefono,PaginaWeb")] Suplidor suplidor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suplidor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suplidor);
        }

        // GET: Suplidors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suplidor suplidor = db.Suplidor.Find(id);
            if (suplidor == null)
            {
                return HttpNotFound();
            }
            return View(suplidor);
        }

        // POST: Suplidors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suplidor suplidor = db.Suplidor.Find(id);
            db.Suplidor.Remove(suplidor);
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
