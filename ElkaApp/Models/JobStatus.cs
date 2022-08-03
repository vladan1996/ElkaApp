using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElkaApp.Models
{
    public class JobStatus
    {
        [Key]
        public Guid ID { get; set; }


        public Guid UserID { get; set; }
        public Guid JobID { get; set; }
        public Guid StatusID { get; set; }
         
        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        [ForeignKey("StatusID")]
        public virtual Status Status { get; set; }
    }
}