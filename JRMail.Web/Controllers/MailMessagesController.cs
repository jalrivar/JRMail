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
    public class MailMessagesController : Controller
    {
        private ModelJRMail db = new ModelJRMail();

        // GET: MailMessages
        public ActionResult Index()
        {
            var mailMessage = db.MailMessage.Include(m => m.MailBox);
            return View(mailMessage.ToList());
        }

        // GET: MailMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailMessage mailMessage = db.MailMessage.Find(id);
            if (mailMessage == null)
            {
                return HttpNotFound();
            }
            return View(mailMessage);
        }

        // GET: MailMessages/Create
        public ActionResult Create()
        {
            ViewBag.MailBoxId = new SelectList(db.MailBox, "MailBoxId", "MailBoxName");
            return View();
        }

        // POST: MailMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MailMessageId,MailBoxId,UserName,To,CC,BCC,From,Subject,Body,Date,MailStatus")] MailMessage mailMessage)
        {
            if (ModelState.IsValid)
            {
                db.MailMessage.Add(mailMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MailBoxId = new SelectList(db.MailBox, "MailBoxId", "MailBoxName", mailMessage.MailBoxId);
            return View(mailMessage);
        }

        // GET: MailMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailMessage mailMessage = db.MailMessage.Find(id);
            if (mailMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.MailBoxId = new SelectList(db.MailBox, "MailBoxId", "MailBoxName", mailMessage.MailBoxId);
            return View(mailMessage);
        }

        // POST: MailMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MailMessageId,MailBoxId,UserName,To,CC,BCC,From,Subject,Body,Date,MailStatus")] MailMessage mailMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MailBoxId = new SelectList(db.MailBox, "MailBoxId", "MailBoxName", mailMessage.MailBoxId);
            return View(mailMessage);
        }

        // GET: MailMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailMessage mailMessage = db.MailMessage.Find(id);
            if (mailMessage == null)
            {
                return HttpNotFound();
            }
            return View(mailMessage);
        }

        // POST: MailMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailMessage mailMessage = db.MailMessage.Find(id);
            db.MailMessage.Remove(mailMessage);
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
