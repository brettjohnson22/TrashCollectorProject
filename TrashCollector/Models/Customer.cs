using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DayOfWeek PickupDay { get; set; }
        public DateTime? SuspendStart { get; set; }
        public DateTime? EndStart { get; set; }
        public bool IsSuspended { get; set; }
        public double AmountOwed { get; set; }
        

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IdentityRole Identity { get; set; }

        public Customer()
        {

        }
    }
}