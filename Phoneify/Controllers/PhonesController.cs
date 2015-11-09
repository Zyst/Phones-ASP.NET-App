using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Phoneify.Models;

namespace Phoneify.Controllers
{
    public class PhonesController : Controller
    {
        private PhoneifyDB db = new PhoneifyDB();

        // TODO: Create a new view for administrators to view every Phone

        // GET: Phones
        [Authorize]
        public ActionResult Index()
        {
            // return View(db.Phones.ToList()); // This one returns everything

            return View(Phone.PhonesByUser(User.Identity.Name)); // Only return the appropriate users
        }

        // GET: Phones/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            if (Phone.DoesUserMatchOrAdmin(phone, User.Identity.Name))
            {
                return View(phone);
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            
        }

        // GET: Phones/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Phones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "PhoneId,Username,PhoneType,PhoneNumber")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                phone.Username = User.Identity.Name;

                db.Phones.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phone);
        }

        // GET: Phones/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            if (Phone.DoesUserMatchOrAdmin(phone, User.Identity.Name))
            {
                return View(phone);
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }

        // POST: Phones/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneId,PhoneType,PhoneNumber")] Phone phone)
        {
            Phone originalPhone = db.Phones.Find(phone.PhoneId);

            if (!Phone.DoesUserMatchOrAdmin(originalPhone, User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            if (ModelState.IsValid)
            {
                phone.Username = originalPhone.Username;
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phone);
        }

        // GET: Phones/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            if (Phone.DoesUserMatchOrAdmin(phone, User.Identity.Name))
            {
                return View(phone);
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = db.Phones.Find(id);
            if (Phone.DoesUserMatchOrAdmin(phone, User.Identity.Name))
            {
                db.Phones.Remove(phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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
