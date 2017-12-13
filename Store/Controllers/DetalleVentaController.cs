using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public class DetalleVentaController : Controller
    {
        private StoreEntities1 db = new StoreEntities1();

        // GET: DetalleVenta
        public ActionResult Index()
        {
            var detalleVenta = db.DetalleVenta.Include(d => d.Articulo).Include(d => d.Venta);
            return View(detalleVenta.ToList());
        }

        // GET: DetalleVenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // GET: DetalleVenta/Create
        public ActionResult Create()
        {
            ViewBag.id_art = new SelectList(db.Articulo, "id_art", "nombre_art");
            ViewBag.id_ven = new SelectList(db.Venta, "id_ven", "numeracion_ven");
            return View();
        }

        // POST: DetalleVenta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dven,id_ven,id_art,cantidad_dven,precio_dven")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.DetalleVenta.Add(detalleVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_art = new SelectList(db.Articulo, "id_art", "nombre_art", detalleVenta.id_art);
            ViewBag.id_ven = new SelectList(db.Venta, "id_ven", "numeracion_ven", detalleVenta.id_ven);
            return View(detalleVenta);
        }

        // GET: DetalleVenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_art = new SelectList(db.Articulo, "id_art", "nombre_art", detalleVenta.id_art);
            ViewBag.id_ven = new SelectList(db.Venta, "id_ven", "numeracion_ven", detalleVenta.id_ven);
            return View(detalleVenta);
        }

        // POST: DetalleVenta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dven,id_ven,id_art,cantidad_dven,precio_dven")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_art = new SelectList(db.Articulo, "id_art", "nombre_art", detalleVenta.id_art);
            ViewBag.id_ven = new SelectList(db.Venta, "id_ven", "numeracion_ven", detalleVenta.id_ven);
            return View(detalleVenta);
        }

        // GET: DetalleVenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // POST: DetalleVenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            db.DetalleVenta.Remove(detalleVenta);
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
