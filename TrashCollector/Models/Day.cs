﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Day
    {
        [Key]
        public DayOfWeek Value { get; set; }
        public string Name { get; set; }
    }
}