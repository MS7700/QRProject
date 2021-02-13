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
    public class Estado_QRController : Controller
    {
        private DB_QR_1Entities2 db = new DB_QR_1Entities2();

        // GET: Estado_QR
        public ActionResult Index()
        {
            return View(db.Estado_QR.ToList());
        }

        // GET: Estado_QR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_QR estado_QR = db.Estado_QR.Find(id);
            if (estado_QR == null)
            {
                return HttpNotFound();
            }
            return View(estado_QR);
        }

        // GET: Estado_QR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado_QR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Estado_QR,Descripcion")] Estado_QR estado_QR)
        {
            if (ModelState.IsValid)
            {
                db.Estado_QR.Add(estado_QR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_QR);
        }

        // GET: Estado_QR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_QR estado_QR = db.Estado_QR.Find(id);
            if (estado_QR == null)
            {
                return HttpNotFound();
            }
            return View(estado_QR);
        }

        // POST: Estado_QR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Estado_QR,Descripcion")] Estado_QR estado_QR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_QR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_QR);
        }

        // GET: Estado_QR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_QR estado_QR = db.Estado_QR.Find(id);
            if (estado_QR == null)
            {
                return HttpNotFound();
            }
            return View(estado_QR);
        }

        // POST: Estado_QR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_QR estado_QR = db.Estado_QR.Find(id);
            db.Estado_QR.Remove(estado_QR);
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
