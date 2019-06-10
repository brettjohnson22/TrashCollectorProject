using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PickupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Pickup
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pickup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pickup/Create
        public ActionResult Create()
        {
            var pickUp = new PickUp();
            return View(pickUp);
        }

        // POST: Pickup/Create
        [HttpPost]
        public ActionResult Create(PickUp pickUp)
        {
            double priceOfPickup = 25;
            var userId = User.Identity.GetUserId();
            Customer customer = db.Customers.Single(c => c.ApplicationId == userId);
            pickUp.CustomerId = customer.Id;
            pickUp.AddressId = customer.AddressId;
            pickUp.Charge = priceOfPickup;
            db.PickUps.Add(pickUp);
            db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Pickup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pickup/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pickup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pickup/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Pickup/Edit/5
        //[HttpPost]
        public ActionResult CheckOff(int id)
        {
            //try
            //{
                var checkedOff = db.PickUps.Find(id);
            if (!checkedOff.IsComplete)
            {
                var customer = db.Customers.Single(c => c.Id == checkedOff.CustomerId);
                checkedOff.IsComplete = true;
                customer.AmountOwed += checkedOff.Charge;
                db.SaveChanges();
            }

                return RedirectToAction("Index", "Employee");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
