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

        [ForeignKey("PickUpDay")]
        [Display(Name = "Weekly Pickup Day")]
        public DayOfWeek PickUpDayID { get; set; }
        public Day PickUpDay { get; set; }

        public bool weeklyDbAdd { get; set; }

        [Display(Name = "Suspend Start Date")]
        [DataType(DataType.Date)]
        public DateTime? SuspendStart { get; set; }

        [Display(Name = "Suspend End Date")]
        [DataType(DataType.Date)]
        public DateTime? SuspendEnd { get; set; }

        [Display(Name = "Schedule A Suspension")]
        public bool SuspensionSceduled { get; set; }

        public bool ActiveSuspension { get; set; }

        [Display(Name = "Current Balance")]
        public double AmountOwed { get; set; }
        

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IdentityRole Identity { get; set; }

        public IEnumerable<Day> Days { get; set; }

        public Customer()
        {

        }
    }
}