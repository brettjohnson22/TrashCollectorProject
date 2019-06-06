using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            var pickups = db.PickUps.Include("Address").Include("Customer").Where(p => p.DateOfPickup == DateTime.Today);
            return View(pickups);
        }
        public ActionResult Customers()
        {
            var id = User.Identity.GetUserId();
            var loggedIn = db.Employees.Single(e => e.ApplicationId == id);
            var customers = db.Customers.Where(c => c.Address.ZipCode == loggedIn.Address.ZipCode);
            return View(customers);
        }
    }
}