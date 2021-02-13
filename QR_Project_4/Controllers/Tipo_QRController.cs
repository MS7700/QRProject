using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QR_Project_4.Models;

namespace QR_Project_4.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class Tipo_QRController : Controller
    {
        private DB_QR_1Entities2 db = new DB_QR_1Entities2();

        // GET: Tipo_QR
        public ActionResult Index()
        {
            return View(db.Tipo_QR.ToList());
        }

        // GET: Tipo_QR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_QR tipo_QR = db.Tipo_QR.Find(id);
            if (tipo_QR == null)
            {
                return HttpNotFound();
            }
            return View(tipo_QR);
        }

        // GET: Tipo_QR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_QR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Tipo_QR,Descripcion")] Tipo_QR tipo_QR)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_QR.Add(tipo_QR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_QR);
        }

        // GET: Tipo_QR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_QR tipo_QR = db.Tipo_QR.Find(id);
            if (tipo_QR == null)
            {
                return HttpNotFound();
            }
            return View(tipo_QR);
        }

        // POST: Tipo_QR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Tipo_QR,Descripcion")] Tipo_QR tipo_QR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_QR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_QR);
        }

        // GET: Tipo_QR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_QR tipo_QR = db.Tipo_QR.Find(id);
            if (tipo_QR == null)
            {
                return HttpNotFound();
            }
            return View(tipo_QR);
        }

        // POST: Tipo_QR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_QR tipo_QR = db.Tipo_QR.Find(id);
            db.Tipo_QR.Remove(tipo_QR);
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
