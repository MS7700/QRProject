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
    public class Rel_Transaccion_ProductoController : Controller
    {
        private DB_QR_1Entities2 db = new DB_QR_1Entities2();

        // GET: Rel_Transaccion_Producto
        public ActionResult Index()
        {
            var rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Include(r => r.Producto).Include(r => r.Transaccion);
            return View(rel_Transaccion_Producto.ToList());
        }

        // GET: Rel_Transaccion_Producto/Details/5
        public ActionResult Details(int? id_t, int? id_p)
        {
            if (id_t == null || id_p == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Find(id);
            Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto
                .Where(p => p.ID_Producto == id_p && p.ID_Transaccion == id_t)
                .First();
            if (rel_Transaccion_Producto == null)
            {
                return HttpNotFound();
            }
            return View(rel_Transaccion_Producto);
        }

        // GET: Rel_Transaccion_Producto/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.ID_Producto = new SelectList(db.Producto, "ID_Producto", "Nombre");
            ViewBag.ID_Transaccion = new SelectList(db.Transaccion, "ID_Transaccion", "ID_Transaccion");
            return View();
        }

        // POST: Rel_Transaccion_Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "ID_Transaccion,ID_Producto,Cantidad_Producto")] Rel_Transaccion_Producto rel_Transaccion_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Rel_Transaccion_Producto.Add(rel_Transaccion_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Producto = new SelectList(db.Producto, "ID_Producto", "Nombre", rel_Transaccion_Producto.ID_Producto);
            ViewBag.ID_Transaccion = new SelectList(db.Transaccion, "ID_Transaccion", "ID_Transaccion", rel_Transaccion_Producto.ID_Transaccion);
            return View(rel_Transaccion_Producto);
        }

        // GET: Rel_Transaccion_Producto/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id_t, int? id_p)
        {
            if (id_t == null || id_p == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Find(id);
            Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto
                .Where(p => p.ID_Producto == id_p && p.ID_Transaccion == id_t)
                .First();
            if (rel_Transaccion_Producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Producto = new SelectList(db.Producto, "ID_Producto", "Nombre", rel_Transaccion_Producto.ID_Producto);
            ViewBag.ID_Transaccion = new SelectList(db.Transaccion, "ID_Transaccion", "ID_Transaccion", rel_Transaccion_Producto.ID_Transaccion);
            return View(rel_Transaccion_Producto);
        }

        // POST: Rel_Transaccion_Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "ID_Transaccion,ID_Producto,Cantidad_Producto")] Rel_Transaccion_Producto rel_Transaccion_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rel_Transaccion_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Producto = new SelectList(db.Producto, "ID_Producto", "Nombre", rel_Transaccion_Producto.ID_Producto);
            ViewBag.ID_Transaccion = new SelectList(db.Transaccion, "ID_Transaccion", "ID_Transaccion", rel_Transaccion_Producto.ID_Transaccion);
            return View(rel_Transaccion_Producto);
        }

        // GET: Rel_Transaccion_Producto/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id_t, int? id_p)
        {
            if (id_t == null || id_p == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Find(id);
            Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Where(p => p.ID_Producto == id_p && p.ID_Transaccion == id_t).First();
            if (rel_Transaccion_Producto == null)
            {
                return HttpNotFound();
            }
            return View(rel_Transaccion_Producto);
        }

        // POST: Rel_Transaccion_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(int? id_t, int? id_p)
        {
            Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Where(p => p.ID_Producto == id_p && p.ID_Transaccion == id_t).First();
            db.Rel_Transaccion_Producto.Remove(rel_Transaccion_Producto);
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
