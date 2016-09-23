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
    public class ClientCardsController : Controller
    {
        private ServiceContext db = new ServiceContext();

        // GET: ClientCards
        public ActionResult Index()
        {
            return View(db.ClientCardsi.ToList());
        }

        // GET: ClientCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCard clientCard = db.ClientCardsi.Find(id);
            if (clientCard == null)
            {
                return HttpNotFound();
            }
            return View(clientCard);
        }

        // GET: ClientCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,FirstName,LastName,DateOfBirth,Address,Phone,Email")] ClientCard clientCard)
        {
            if (ModelState.IsValid)
            {
                db.ClientCardsi.Add(clientCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientCard);
        }

        // GET: ClientCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCard clientCard = db.ClientCardsi.Find(id);
            if (clientCard == null)
            {
                return HttpNotFound();
            }
            return View(clientCard);
        }

        // POST: ClientCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,FirstName,LastName,DateOfBirth,Address,Phone,Email")] ClientCard clientCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientCard);
        }

        // GET: ClientCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCard clientCard = db.ClientCardsi.Find(id);
            if (clientCard == null)
            {
                return HttpNotFound();
            }
            return View(clientCard);
        }

        // POST: ClientCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientCard clientCard = db.ClientCardsi.Find(id);
            db.ClientCardsi.Remove(clientCard);
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
