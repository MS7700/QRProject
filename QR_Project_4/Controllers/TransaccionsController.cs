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
    public class TransaccionsController : Controller
    {
        private DB_QR_1Entities2 db = new DB_QR_1Entities2();

        // GET: Transaccions
        public ActionResult Index()
        {
            var transaccion = db.Transaccion.Include(t => t.Cliente).Include(t => t.Estado_Transaccion);
            return View(transaccion.ToList());
        }

        // GET: Transaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            ViewBag.Rel_Trans_Prod = db.Rel_Transaccion_Producto.Where(p => p.ID_Transaccion == id).Include(p => p.Producto);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transaccions/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Cedula");
            ViewBag.ID_Estado_Transaccion = new SelectList(db.Estado_Transaccion, "ID_Estado_Transaccion", "Descripcion");
            return View();
        }

        // POST: Transaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "ID_Transaccion,ID_Cliente,Fecha,ID_Estado_Transaccion,Monto")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Transaccion.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Cedula", transaccion.ID_Cliente);
            ViewBag.ID_Estado_Transaccion = new SelectList(db.Estado_Transaccion, "ID_Estado_Transaccion", "Descripcion", transaccion.ID_Estado_Transaccion);
            return View(transaccion);
        }

        // GET: Transaccions/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Cedula", transaccion.ID_Cliente);
            ViewBag.ID_Estado_Transaccion = new SelectList(db.Estado_Transaccion, "ID_Estado_Transaccion", "Descripcion", transaccion.ID_Estado_Transaccion);
            return View(transaccion);
        }

        // POST: Transaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "ID_Transaccion,ID_Cliente,Fecha,ID_Estado_Transaccion,Monto")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Cedula", transaccion.ID_Cliente);
            ViewBag.ID_Estado_Transaccion = new SelectList(db.Estado_Transaccion, "ID_Estado_Transaccion", "Descripcion", transaccion.ID_Estado_Transaccion);
            return View(transaccion);
        }

        // GET: Transaccions/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccions/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transaccion.Find(id);
            db.Transaccion.Remove(transaccion);
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
