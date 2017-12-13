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
    public class DetallePedidoController : Controller
    {
        private StoreEntities1 db = new StoreEntities1();

        // GET: DetallePedido
        public ActionResult Index()
        {
            var detallePedido = db.DetallePedido.Include(d => d.Articulo).Include(d => d.Pedido);
            return View(detallePedido.ToList());
        }

        // GET: DetallePedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = db.DetallePedido.Find(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            return View(detallePedido);
        }

        // GET: DetallePedido/Create
        public ActionResult Create()
        {
            ViewBag.id_art = new SelectList(db.Articulo, "id_art", "nombre_art");
            ViewBag.id_ped = new SelectList(db.Pedido, "id_ped", "id_ped");
            return View();
        }

        // POST: DetallePedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dped,id_ped,id_art,cantidad_dped")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                db.DetallePedido.Add(detallePedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_art = new SelectList(db.Articulo, "id_art", "nombre_art", detallePedido.id_art);
            ViewBag.id_ped = new SelectList(db.Pedido, "id_ped", "id_ped", detallePedido.id_ped);
            return View(detallePedido);
        }

        // GET: DetallePedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = db.DetallePedido.Find(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_art = new SelectList(db.Articulo, "id_art", "nombre_art", detallePedido.id_art);
            ViewBag.id_ped = new SelectList(db.Pedido, "id_ped", "id_ped", detallePedido.id_ped);
            return View(detallePedido);
        }

        // POST: DetallePedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dped,id_ped,id_art,cantidad_dped")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallePedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_art = new SelectList(db.Articulo, "id_art", "nombre_art", detallePedido.id_art);
            ViewBag.id_ped = new SelectList(db.Pedido, "id_ped", "id_ped", detallePedido.id_ped);
            return View(detallePedido);
        }

        // GET: DetallePedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = db.DetallePedido.Find(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            return View(detallePedido);
        }

        // POST: DetallePedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetallePedido detallePedido = db.DetallePedido.Find(id);
            db.DetallePedido.Remove(detallePedido);
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
