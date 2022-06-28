using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElkaApp.Models
{
    public class Job
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }   
        public string Locoation { get; set; }   
        public string Description { get; set; }   
        [Required]
        public DateTime StartDate { get; set; }   
      
    }
}