using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JRMail.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace JRMail.Web.Controllers
{
    public class MailMessageController : Controller
    {
        private ModelJRMail db = new ModelJRMail();
        private ApplicationUserManager _userManager;

        [Authorize]
        // GET: MailMessage
        public ActionResult Index()
        {
            var mailMessage = db.MailMessage.Where(x => x.To == User.Identity.Name).Include(m => m.MailBox).Include(m => m.MailMessageStatus).OrderByDescending(x => x.Date);
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

            if (ModelState.IsValid)
            {
                mailMessage.Readed = true;
                db.Entry(mailMessage).State = EntityState.Modified;
                db.SaveChanges();
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

                //5. Creación y envío de correo a otro usuario registrado.
                //var user = UserManager.FindByName(mailMessage.To);
                //if (user == null)
                //{
                //    ViewBag.MailBoxId = new SelectList(db.MailBox, "MailBoxId", "MailBoxName", mailMessage.MailBoxId);
                //    ViewBag.MailMessageStatusId = new SelectList(db.MailMessageStatus, "MailMessageStatusId", "MailMessageStatusName", mailMessage.MailMessageStatusId);
                //    return View(new Models.MailMessageViewModel(mailMessage));
                //}

                db.MailMessage.Add(mailMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MailBoxId = new SelectList(db.MailBox, "MailBoxId", "MailBoxName", mailMessage.MailBoxId);
            ViewBag.MailMessageStatusId = new SelectList(db.MailMessageStatus, "MailMessageStatusId", "MailMessageStatusName", mailMessage.MailMessageStatusId);
            return View(mailMessage);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
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
