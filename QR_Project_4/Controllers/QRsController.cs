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
    public class QRsController : Controller
    {
        private DB_QR_1Entities2 db = new DB_QR_1Entities2();

        // GET: QRs
        public ActionResult Index()
        {
            var qR = db.QR.Include(q => q.Cliente).Include(q => q.Departamento).Include(q => q.Estado_QR).Include(q => q.Tipo_QR);
            return View(qR.ToList());
        }

        // GET: QRs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QR qR = db.QR.Find(id);
            ViewBag.Cliente = db.Cliente.Find(qR.ID_Cliente);

            if (qR == null)
            {
                return HttpNotFound();
            }
            return View(qR);
        }

        // GET: QRs/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Cedula");
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre");
            ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion");
            ViewBag.ID_Tipo_QR = new SelectList(db.Tipo_QR, "ID_Tipo_QR", "Descripcion");
            return View();
        }

        // POST: QRs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_QR,ID_Cliente,ID_Departamento,ID_Tipo_QR,Fecha,Hora,ID_Estado_QR,Comentario")] QR qR)
        {
            if (ModelState.IsValid)
            {
                db.QR.Add(qR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Cedula", qR.ID_Cliente);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", qR.ID_Departamento);
            ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", qR.ID_Estado_QR);
            ViewBag.ID_Tipo_QR = new SelectList(db.Tipo_QR, "ID_Tipo_QR", "Descripcion", qR.ID_Tipo_QR);
            return View(qR);
        }

        // GET: QRs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QR qR = db.QR.Find(id);
            if (qR == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Cedula", qR.ID_Cliente);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", qR.ID_Departamento);
            ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", qR.ID_Estado_QR);
            ViewBag.ID_Tipo_QR = new SelectList(db.Tipo_QR, "ID_Tipo_QR", "Descripcion", qR.ID_Tipo_QR);
            return View(qR);
        }

        // POST: QRs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_QR,ID_Cliente,ID_Departamento,ID_Tipo_QR,Fecha,Hora,ID_Estado_QR,Comentario")] QR qR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Cedula", qR.ID_Cliente);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", qR.ID_Departamento);
            ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", qR.ID_Estado_QR);
            ViewBag.ID_Tipo_QR = new SelectList(db.Tipo_QR, "ID_Tipo_QR", "Descripcion", qR.ID_Tipo_QR);
            return View(qR);
        }

        // GET: QRs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QR qR = db.QR.Find(id);
            if (qR == null)
            {
                return HttpNotFound();
            }
            return View(qR);
        }

        // POST: QRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QR qR = db.QR.Find(id);
            db.QR.Remove(qR);
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
