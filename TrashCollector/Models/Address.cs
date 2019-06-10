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
        [Display(Name = "Address Line One")]
        public string LineOne { get; set; }
        [Display(Name = "Address Line Two")]
        public string LineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}