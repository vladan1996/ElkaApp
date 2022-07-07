using ElkaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElkaApp.Controllers
{
    public class JobController : Controller
    {

        private ApplicationDbContext _context;

        public JobController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Job 
        [Authorize]
        public ActionResult Index()
        {
            var jobs = _context.Jobs.ToList();
            return View(jobs);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Create(Job job)
        {
          
            job.ID = Guid.NewGuid();
            _context.Jobs.Add(job);
            _context.SaveChanges();
            ViewBag.Message = "The job has been added!";

            return RedirectToAction("Index" , "Job");
            
        }

    }
}