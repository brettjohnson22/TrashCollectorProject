using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = db.Customers.Include(c => c.Address);
            string id = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(c => c.ApplicationId == id).FirstOrDefault();
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            var days = db.Days.ToList();
            Customer customer = new Customer();
            customer.ApplicationId = User.Identity.GetUserId();
            customer.Address = new Address();
            customer.Days = days;
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,PickUpDayID,Address,ApplicationId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                string request = FormatGeocodeParamaters(customer);
                await SendGeocodeRequest(request, customer);
                db.Customers.Add(customer);
                db.Addresses.Add(customer.Address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var customerInDb = db.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.PickUpDay = customer.PickUpDay;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET:
        public ActionResult Suspend(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Suspend(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var customerInDb = db.Customers.Single(c => c.Id == customer.Id);
                customerInDb.SuspensionSceduled = customer.SuspensionSceduled;
                customerInDb.SuspendStart = customer.SuspendStart;
                customerInDb.SuspendEnd = customer.SuspendEnd;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string FormatGeocodeParamaters(Customer customer)
        {
            StringBuilder sb = new StringBuilder("https://maps.googleapis.com/maps/api/geocode/json?address=");
            sb.Append(customer.Address.LineOne + ",+");
            sb.Append(customer.Address.City + ",+");
            sb.Append(customer.Address.State + "&key=" + APIkey.SecretKey);
            sb.Replace(' ', '+');
            return sb.ToString();
        }

        public async Task SendGeocodeRequest(string request, Customer customer)
        {
            var uri = new System.Uri(request);
            string result;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    result = await httpClient.GetStringAsync(uri);
                    dynamic jsonData = JObject.Parse(result);
                    var lat = jsonData.results[0].geometry.location.lat;
                    var lng = jsonData.results[0].geometry.location.lng;
                    customer.Address.Latitude = lat;
                    customer.Address.Longitude = lng;
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
