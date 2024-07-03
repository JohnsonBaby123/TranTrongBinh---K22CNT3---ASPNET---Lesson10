using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Baitap10.Models;

namespace Baitap10.Controllers
{
    public class TtbAccountsController : Controller
    {
        

        // GET: TtbAccounts
        public ActionResult Index()
        {
            return View(db.TtbAccounts.ToList());
        }

        // GET: TtbAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TtbAccount TtbAccount = db.TtbAccounts.Find(id);
            if (TtbAccount == null)
            {
                return HttpNotFound();
            }
            return View(TtbAccount);
        }

        // GET: TtbAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TtbAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TtbUerName,TtbPassword,TtbFullName,TtbEmail,TtbPhone,TtbActive")] TtbAccount TtbAccount)
        {
            if (ModelState.IsValid)
            {
                db.TtbAccounts.Add(TtbAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(TtbAccount);
        }

        // GET: TtbAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TtbAccount TtbAccount = db.TtbAccounts.Find(id);
            if (TtbAccount == null)
            {
                return HttpNotFound();
            }
            return View(TtbAccount);
        }

        // POST: TtbAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TtbUerName,TtbPassword,TtbFullName,TtbEmail,TtbPhone,TtbActive")] TtbAccount TtbAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(TtbAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(TtbAccount);
        }

        // GET: TtbAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TtbAccount TtbAccount = db.TtbAccounts.Find(id);
            if (TtbAccount == null)
            {
                return HttpNotFound();
            }
            return View(TtbAccount);
        }

        // POST: TtbAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TtbAccount TtbAccount = db.TtbAccounts.Find(id);
            db.TtbAccounts.Remove(TtbAccount);
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

        public ActionResult Ttblogin()
        {
            var TtbModel = new TtbAccount();
            return View(TtbModel);
        }
        [HttpPost]
        public ActionResult Ttblogin(TtbAccount Ttb)
        {
            var TtbCheck = db.TtbAccounts.Where(x=>x.TtbUserName.Equals(TtbAccount.TtbUserName) && x>TtbPassword.Equals(TtbAccount.TtbPassword)).Firstdefault()
            if(TtbCheck =! null)
            {
                Session["TtbAccount"] = TtbCheck;
                return Redirect("/");
            }
                return View(TtbAccount);
        }
    }
}
