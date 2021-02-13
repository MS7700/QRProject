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
    public class Tipo_ProductoController : Controller
    {
        private DB_QR_1Entities2 db = new DB_QR_1Entities2();

        // GET: Tipo_Producto
        public ActionResult Index()
        {
            return View(db.Tipo_Producto.ToList());
        }

        // GET: Tipo_Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Producto tipo_Producto = db.Tipo_Producto.Find(id);
            if (tipo_Producto == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Producto);
        }

        // GET: Tipo_Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Tipo_Producto,Descripcion")] Tipo_Producto tipo_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Producto.Add(tipo_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Producto);
        }

        // GET: Tipo_Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Producto tipo_Producto = db.Tipo_Producto.Find(id);
            if (tipo_Producto == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Producto);
        }

        // POST: Tipo_Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Tipo_Producto,Descripcion")] Tipo_Producto tipo_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Producto);
        }

        // GET: Tipo_Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Producto tipo_Producto = db.Tipo_Producto.Find(id);
            if (tipo_Producto == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Producto);
        }

        // POST: Tipo_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Producto tipo_Producto = db.Tipo_Producto.Find(id);
            db.Tipo_Producto.Remove(tipo_Producto);
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
