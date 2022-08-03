using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElkaApp.Models.DTO
{
    public class UpdateStatusDTO
    {
        public Guid JobStausId { get; set; }

        public Guid NewStatusId { get; set; }

        public Guid OldStatusId { get; set; }

    }
}