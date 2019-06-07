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
            var customers = MyCustomers();
            return View(customers);
        }
        public ActionResult LoginRoutine()
        {
            CreateSuspensions();
            EndSuspensions();
            FindTodaysPickups();
            return RedirectToAction("Index");
        }
        public void FindTodaysPickups()
        {
            double standarCharge = 15;
            DayOfWeek today = DateTime.Today.DayOfWeek;
            var todaysCustomers = db.Customers.Where(c => c.PickUpDayID == today && !c.weeklyDbAdd && !c.ActiveSuspension);
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
        }
        public ActionResult FilterSelect()
        {
            return View();
        }
        public void CreateSuspensions()
        {
            var todaysSuspensions = db.Customers.Where(c => c.SuspendStart == DateTime.Today);
            foreach(Customer customer in todaysSuspensions)
            {
                customer.ActiveSuspension = true;
            }
            db.SaveChanges();
        }
        public void EndSuspensions()
        {
            var todaysRestarts = db.Customers.Where(c => c.SuspendEnd == DateTime.Today);
            foreach (Customer customer in todaysRestarts)
            {
                customer.ActiveSuspension = true;
            }
            db.SaveChanges();
        }
        //public ActionResult DailyView()
        //{

        //}
        public IEnumerable<Customer> MyCustomers()
        {
            var id = User.Identity.GetUserId();
            var loggedIn = db.Employees.Include("Address").Single(e => e.ApplicationId == id);
            int loggedZip = loggedIn.Address.ZipCode;
            var customers = db.Customers.Include("Address").Where(c => c.Address.ZipCode == loggedZip);
            return customers;
        }

        public ActionResult DailyView(string dayToView)
        {
            var day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayToView);
            var customers = MyCustomers();
            var dailyCustomers = customers.Where(c => c.PickUpDayID == day);
            return View(dailyCustomers);
        }
    }
}