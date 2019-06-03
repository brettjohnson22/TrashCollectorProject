using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickUp
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public Address Address { get; set; }

        public double Charge { get; set; }

        public bool IsComplete { get; set; }

    }
}