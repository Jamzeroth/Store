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
    public class DistribuidorController : Controller
    {
        private StoreEntities1 db = new StoreEntities1();

        // GET: Distribuidor
        public ActionResult Index()
        {
            return View(db.Distribuidor.ToList());
        }

        // GET: Distribuidor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidor distribuidor = db.Distribuidor.Find(id);
            if (distribuidor == null)
            {
                return HttpNotFound();
            }
            return View(distribuidor);
        }

        // GET: Distribuidor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distribuidor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dis,nombre_dis,direccion_dis,telefono_dis,web_dis")] Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                db.Distribuidor.Add(distribuidor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distribuidor);
        }

        // GET: Distribuidor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidor distribuidor = db.Distribuidor.Find(id);
            if (distribuidor == null)
            {
                return HttpNotFound();
            }
            return View(distribuidor);
        }

        // POST: Distribuidor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dis,nombre_dis,direccion_dis,telefono_dis,web_dis")] Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distribuidor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distribuidor);
        }

        // GET: Distribuidor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidor distribuidor = db.Distribuidor.Find(id);
            if (distribuidor == null)
            {
                return HttpNotFound();
            }
            return View(distribuidor);
        }

        // POST: Distribuidor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distribuidor distribuidor = db.Distribuidor.Find(id);
            db.Distribuidor.Remove(distribuidor);
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
