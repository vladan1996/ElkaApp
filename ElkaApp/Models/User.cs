using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElkaApp.Models
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Fullname { get; set; }
        public DateTime Brithdate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public string FilePath { get; set; }
        public string Role { get; set; }
    }
}