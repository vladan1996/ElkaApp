﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElkaApp.Models
{
    public class Status
    {
        [Key]
        public Guid ID { get; set; }

        public string StatusName { get; set; }

    }
}