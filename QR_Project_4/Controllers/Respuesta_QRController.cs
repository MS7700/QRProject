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
    [Authorize]
    public class Respuesta_QRController : Controller
    {
        private DB_QR_1Entities2 db = new DB_QR_1Entities2();

        // GET: Respuesta_QR
        public ActionResult Index()
        {
            var respuesta_QR = db.Respuesta_QR.Include(r => r.Empleado).Include(r => r.QR);
            return View(respuesta_QR.ToList());
        }

        // GET: Respuesta_QR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_QR respuesta_QR = db.Respuesta_QR.Find(id);
            if (respuesta_QR == null)
            {
                return HttpNotFound();
            }
            return View(respuesta_QR);
        }

        // GET: Respuesta_QR/Create
        public ActionResult Create()
        {
            ViewBag.ID_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Nombre");
            ViewBag.ID_QR = new SelectList(db.QR, "ID_QR", "Comentario");
            return View();
        }

        // POST: Respuesta_QR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Respuesta_QR,ID_QR,ID_Empleado,Fecha,Detalle")] Respuesta_QR respuesta_QR)
        {
            if (ModelState.IsValid)
            {
                db.Respuesta_QR.Add(respuesta_QR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Nombre", respuesta_QR.ID_Empleado);
            ViewBag.ID_QR = new SelectList(db.QR, "ID_QR", "Comentario", respuesta_QR.ID_QR);
            return View(respuesta_QR);
        }

        // GET: Respuesta_QR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_QR respuesta_QR = db.Respuesta_QR.Find(id);
            if (respuesta_QR == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Nombre", respuesta_QR.ID_Empleado);
            ViewBag.ID_QR = new SelectList(db.QR, "ID_QR", "Comentario", respuesta_QR.ID_QR);
            return View(respuesta_QR);
        }

        // POST: Respuesta_QR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Respuesta_QR,ID_QR,ID_Empleado,Fecha,Detalle")] Respuesta_QR respuesta_QR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuesta_QR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Nombre", respuesta_QR.ID_Empleado);
            ViewBag.ID_QR = new SelectList(db.QR, "ID_QR", "Comentario", respuesta_QR.ID_QR);
            return View(respuesta_QR);
        }

        // GET: Respuesta_QR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_QR respuesta_QR = db.Respuesta_QR.Find(id);
            if (respuesta_QR == null)
            {
                return HttpNotFound();
            }
            return View(respuesta_QR);
        }

        // POST: Respuesta_QR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respuesta_QR respuesta_QR = db.Respuesta_QR.Find(id);
            db.Respuesta_QR.Remove(respuesta_QR);
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
