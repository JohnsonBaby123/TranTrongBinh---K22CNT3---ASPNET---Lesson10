using Baitap10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baitap10.Controllers
{
    public class TtbHomeController : Controller
    {
        public ActionResult TtbIndex()
        {
            if (Session["TtbAccount"] != null)
            {
                var TtbAccount = Session["TtbAccount"] as TtbAccount;
                ViewBag.FullName = TtbAccount.TtbFullName;
            }
            return View();
        }

        public ActionResult TtbAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TtbContact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}