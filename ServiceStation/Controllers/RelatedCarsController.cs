using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiceStation.Domain.DAL;
using ServiceStation.Domain.Model;

namespace SarviceStation.Controllers
{
    public class RelatedCarsController : Controller
    {
        private ServiceContext db = new ServiceContext();

        // GET: RelatedCars
        public ActionResult Index()
        {
            return View(db.RelatedCarsi.ToList());
        }

        // GET: RelatedCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelatedCars relatedCars = db.RelatedCarsi.Find(id);
            if (relatedCars == null)
            {
                return HttpNotFound();
            }
            return View(relatedCars);
        }

        // GET: RelatedCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelatedCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,Make,Model,Year,VIN")] RelatedCars relatedCars)
        {
            if (ModelState.IsValid)
            {
                db.RelatedCarsi.Add(relatedCars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relatedCars);
        }

        // GET: RelatedCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelatedCars relatedCars = db.RelatedCarsi.Find(id);
            if (relatedCars == null)
            {
                return HttpNotFound();
            }
            return View(relatedCars);
        }

        // POST: RelatedCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,Make,Model,Year,VIN")] RelatedCars relatedCars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relatedCars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relatedCars);
        }

        // GET: RelatedCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelatedCars relatedCars = db.RelatedCarsi.Find(id);
            if (relatedCars == null)
            {
                return HttpNotFound();
            }
            return View(relatedCars);
        }

        // POST: RelatedCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RelatedCars relatedCars = db.RelatedCarsi.Find(id);
            db.RelatedCarsi.Remove(relatedCars);
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
