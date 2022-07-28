using ElkaApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElkaApp.Controllers
{
    public class JobController : BaseController
    {
        //Pamtim userId u job Controller

        private ApplicationDbContext _context;


        public JobController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();

            var jobs = _context.Jobs.ToList();
            return View(jobs);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public JsonResult Create(Job obj)
        {
            BLL.CreateJob(obj);
            return Json(new { success = true, message = "New Job added sucessfully!" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public JsonResult JobApply(Guid jobID)
        {
            var userID = User.Identity.GetUserId();
            var data = BLL.JobApplication(userID, jobID);
            return Json(new { success = true, message = "You have applied for the specified job!"}, JsonRequestBehavior.AllowGet);
        }
    }
}