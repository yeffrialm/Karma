﻿using System;
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
    public class OrdenesController : Controller
    {
        private KarmaEntities db = new KarmaEntities();

        [Authorize(Users = "yeffri13@gmail.com")]

        // GET: Ordenes
        public ActionResult Index()
        {
            var ordenes = db.Ordenes.Include(o => o.Carrier).Include(o => o.Cliente);
            return View(ordenes.ToList());
        }

        // GET: Ordenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordenes ordenes = db.Ordenes.Find(id);
            if (ordenes == null)
            {
                return HttpNotFound();
            }
            return View(ordenes);
        }

        // GET: Ordenes/Create
        public ActionResult Create()
        {
            ViewBag.ViaEnvio = new SelectList(db.Carrier, "CarrierID", "NombreCarrier");
            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "Empresa");
            return View();
        }

        // POST: Ordenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdenesID,ClienteID,FechaOrdenes,FechaRequeida,FechaEnvio,ViaEnvio,Flete,NombreEnvio,DireccionEnvio,ProvinciaEnvio,MunicipioEnvio,CodigoPostalEnvio,PaisEnvio")] Ordenes ordenes)
        {
            if (ModelState.IsValid)
            {
                db.Ordenes.Add(ordenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ViaEnvio = new SelectList(db.Carrier, "CarrierID", "NombreCarrier", ordenes.ViaEnvio);
            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "Empresa", ordenes.ClienteID);
            return View(ordenes);
        }

        // GET: Ordenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordenes ordenes = db.Ordenes.Find(id);
            if (ordenes == null)
            {
                return HttpNotFound();
            }
            ViewBag.ViaEnvio = new SelectList(db.Carrier, "CarrierID", "NombreCarrier", ordenes.ViaEnvio);
            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "Empresa", ordenes.ClienteID);
            return View(ordenes);
        }

        // POST: Ordenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrdenesID,ClienteID,FechaOrdenes,FechaRequeida,FechaEnvio,ViaEnvio,Flete,NombreEnvio,DireccionEnvio,ProvinciaEnvio,MunicipioEnvio,CodigoPostalEnvio,PaisEnvio")] Ordenes ordenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ViaEnvio = new SelectList(db.Carrier, "CarrierID", "NombreCarrier", ordenes.ViaEnvio);
            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "Empresa", ordenes.ClienteID);
            return View(ordenes);
        }

        // GET: Ordenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordenes ordenes = db.Ordenes.Find(id);
            if (ordenes == null)
            {
                return HttpNotFound();
            }
            return View(ordenes);
        }

        // POST: Ordenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordenes ordenes = db.Ordenes.Find(id);
            db.Ordenes.Remove(ordenes);
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
