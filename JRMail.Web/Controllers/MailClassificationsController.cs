using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JRMail.DAL;

namespace JRMail.Web.Controllers
{
    public class MailClassificationsController : Controller
    {
        private ModelJRMail db = new ModelJRMail();

        // GET: MailClassifications
        public ActionResult Index()
        {
            return View(db.MailClassification.ToList());
        }

        // GET: MailClassifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailClassification mailClassification = db.MailClassification.Find(id);
            if (mailClassification == null)
            {
                return HttpNotFound();
            }
            return View(mailClassification);
        }

        // GET: MailClassifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MailClassifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MailClassificationId,UserName,MailClassificationName")] MailClassification mailClassification)
        {
            if (ModelState.IsValid)
            {
                db.MailClassification.Add(mailClassification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mailClassification);
        }

        // GET: MailClassifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailClassification mailClassification = db.MailClassification.Find(id);
            if (mailClassification == null)
            {
                return HttpNotFound();
            }
            return View(mailClassification);
        }

        // POST: MailClassifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MailClassificationId,UserName,MailClassificationName")] MailClassification mailClassification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailClassification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mailClassification);
        }

        // GET: MailClassifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailClassification mailClassification = db.MailClassification.Find(id);
            if (mailClassification == null)
            {
                return HttpNotFound();
            }
            return View(mailClassification);
        }

        // POST: MailClassifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailClassification mailClassification = db.MailClassification.Find(id);
            db.MailClassification.Remove(mailClassification);
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
