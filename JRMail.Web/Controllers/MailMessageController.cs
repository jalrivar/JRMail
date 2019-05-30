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
    public class MailMessageController : Controller
    {
        private ModelJRMail db = new ModelJRMail();

        [Authorize]
        // GET: MailMessage
        public ActionResult Index()
        {
            var mailMessage = db.MailMessage.Include(m => m.MailBox).Include(m => m.MailMessageStatus);
            return View(mailMessage.ToList());
        }

        [Authorize]
        // GET: MailMessage/Details/5
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

        [Authorize]
        // GET: MailMessage/Create
        public ActionResult Create()
        {
            ViewBag.MailBoxId = new SelectList(db.MailBox, "MailBoxId", "MailBoxName");
            ViewBag.MailMessageStatusId = new SelectList(db.MailMessageStatus, "MailMessageStatusId", "MailMessageStatusName");

            var model = new Models.MailMessageViewModel();
            model.UserName = User.Identity.Name;
            model.From = User.Identity.Name;
            model.Date = DateTime.Now;

            return View(model);
        }

        [Authorize]
        // POST: MailMessage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MailMessageId,MailBoxId,MailMessageStatusId,UserName,To,CC,BCC,From,Subject,Body,Date,Readed")] MailMessage mailMessage)
        {
            if (ModelState.IsValid)
            {
                db.MailMessage.Add(mailMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MailBoxId = new SelectList(db.MailBox, "MailBoxId", "MailBoxName", mailMessage.MailBoxId);
            ViewBag.MailMessageStatusId = new SelectList(db.MailMessageStatus, "MailMessageStatusId", "MailMessageStatusName", mailMessage.MailMessageStatusId);
            return View(mailMessage);
        }

        [Authorize]
        // GET: MailMessage/Delete/5
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

        [Authorize]
        // POST: MailMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailMessage mailMessage = db.MailMessage.Find(id);
            db.MailMessage.Remove(mailMessage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
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
