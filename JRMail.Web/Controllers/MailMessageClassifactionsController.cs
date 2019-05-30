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
    public class MailMessageClassifactionsController : Controller
    {
        private ModelJRMail db = new ModelJRMail();

        // GET: MailMessageClassifactions
        public ActionResult Index()
        {
            var mailMessageClassifaction = db.MailMessageClassifaction.Include(m => m.MailClassification).Include(m => m.MailMessage);
            return View(mailMessageClassifaction.ToList());
        }

        // GET: MailMessageClassifactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailMessageClassifaction mailMessageClassifaction = db.MailMessageClassifaction.Find(id);
            if (mailMessageClassifaction == null)
            {
                return HttpNotFound();
            }
            return View(mailMessageClassifaction);
        }

        // GET: MailMessageClassifactions/Create
        public ActionResult Create()
        {
            ViewBag.MailClassificationId = new SelectList(db.MailClassification, "MailClassificationId", "UserName");
            ViewBag.MailMessageId = new SelectList(db.MailMessage, "MailMessageId", "UserName");
            return View();
        }

        // POST: MailMessageClassifactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MailMessageClassifactionId,MailMessageId,MailClassificationId")] MailMessageClassifaction mailMessageClassifaction)
        {
            if (ModelState.IsValid)
            {
                db.MailMessageClassifaction.Add(mailMessageClassifaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MailClassificationId = new SelectList(db.MailClassification, "MailClassificationId", "UserName", mailMessageClassifaction.MailClassificationId);
            ViewBag.MailMessageId = new SelectList(db.MailMessage, "MailMessageId", "UserName", mailMessageClassifaction.MailMessageId);
            return View(mailMessageClassifaction);
        }

        // GET: MailMessageClassifactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailMessageClassifaction mailMessageClassifaction = db.MailMessageClassifaction.Find(id);
            if (mailMessageClassifaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.MailClassificationId = new SelectList(db.MailClassification, "MailClassificationId", "UserName", mailMessageClassifaction.MailClassificationId);
            ViewBag.MailMessageId = new SelectList(db.MailMessage, "MailMessageId", "UserName", mailMessageClassifaction.MailMessageId);
            return View(mailMessageClassifaction);
        }

        // POST: MailMessageClassifactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MailMessageClassifactionId,MailMessageId,MailClassificationId")] MailMessageClassifaction mailMessageClassifaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailMessageClassifaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MailClassificationId = new SelectList(db.MailClassification, "MailClassificationId", "UserName", mailMessageClassifaction.MailClassificationId);
            ViewBag.MailMessageId = new SelectList(db.MailMessage, "MailMessageId", "UserName", mailMessageClassifaction.MailMessageId);
            return View(mailMessageClassifaction);
        }

        // GET: MailMessageClassifactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailMessageClassifaction mailMessageClassifaction = db.MailMessageClassifaction.Find(id);
            if (mailMessageClassifaction == null)
            {
                return HttpNotFound();
            }
            return View(mailMessageClassifaction);
        }

        // POST: MailMessageClassifactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailMessageClassifaction mailMessageClassifaction = db.MailMessageClassifaction.Find(id);
            db.MailMessageClassifaction.Remove(mailMessageClassifaction);
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
