using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (this.User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "Customers");
            }
            else if (this.User.IsInRole("Employee"))
            {
                return RedirectToAction("LoginRoutine", "Employee");
            }
            else
            {
                return View();
            }
        }
    }
}