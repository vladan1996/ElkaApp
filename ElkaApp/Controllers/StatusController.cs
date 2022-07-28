using ElkaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElkaApp.Controllers
{
    public class StatusController : BaseController
    {
        private ApplicationDbContext _context;


        public StatusController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var data = BLL.GetJobStatusDate();
            return View(data);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var applicantData = BLL.GetApplicant(id);
            return View(applicantData);

        }

    }
}