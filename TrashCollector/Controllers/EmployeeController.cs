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

        public ActionResult FindTodaysPickups()
        {
            double standarCharge = 15;
            DayOfWeek today = DateTime.Today.DayOfWeek;
            var todaysCustomers = db.Customers.Where(c => c.PickUpDayID == today && !c.weeklyDbAdd);
            foreach (Customer customer in todaysCustomers)
            {
                PickUp pickup = new PickUp()
                {
                    DateOfPickup = DateTime.Today,
                    CustomerId = customer.Id,
                    AddressId = customer.AddressId,
                    Charge = standarCharge,
                };
                customer.weeklyDbAdd = true;
                db.PickUps.Add(pickup);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}