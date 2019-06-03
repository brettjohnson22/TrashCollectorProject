using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

    }
}