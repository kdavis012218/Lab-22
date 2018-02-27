using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab_22.Models;

namespace lab_22.Controllers
{
    public class Coffee_Shop_DBController : Controller
    {
        private Coffee_Shop_DBEntities db = new Coffee_Shop_DBEntities();

        // GET: Coffee_Shop_DB
        public ActionResult Index()
        {
            return View(db.Coffee_Shop_DBs.ToList());
        }

        // GET: Coffee_Shop_DB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee_Shop_DB coffee_Shop_DB = db.Coffee_Shop_DBs.Find(id);
            if (coffee_Shop_DB == null)
            {
                return HttpNotFound();
            }
            return View(coffee_Shop_DB);
        }

        // GET: Coffee_Shop_DB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coffee_Shop_DB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Quantity,Price,Items")] Coffee_Shop_DB coffee_Shop_DB)
        {
            if (ModelState.IsValid)
            {
                db.Coffee_Shop_DBs.Add(coffee_Shop_DB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffee_Shop_DB);
        }

        // GET: Coffee_Shop_DB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee_Shop_DB coffee_Shop_DB = db.Coffee_Shop_DBs.Find(id);
            if (coffee_Shop_DB == null)
            {
                return HttpNotFound();
            }
            return View(coffee_Shop_DB);
        }

        // POST: Coffee_Shop_DB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Quantity,Price,Items")] Coffee_Shop_DB coffee_Shop_DB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffee_Shop_DB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffee_Shop_DB);
        }

        // GET: Coffee_Shop_DB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee_Shop_DB coffee_Shop_DB = db.Coffee_Shop_DBs.Find(id);
            if (coffee_Shop_DB == null)
            {
                return HttpNotFound();
            }
            return View(coffee_Shop_DB);
        }

        // POST: Coffee_Shop_DB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coffee_Shop_DB coffee_Shop_DB = db.Coffee_Shop_DBs.Find(id);
            db.Coffee_Shop_DBs.Remove(coffee_Shop_DB);
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
