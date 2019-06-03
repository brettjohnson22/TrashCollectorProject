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
        public string PickupDay { get; set; }
        public DateTime? SuspendStart { get; set; }
        public DateTime? EndStart { get; set; }
        public double AmountOwed { get; set; }
        

        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }
}