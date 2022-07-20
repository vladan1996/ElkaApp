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


        [Authorize]
        [HttpPost]
        public JsonResult Create(Job obj)
        {           
                obj.ID = Guid.NewGuid();
                _context.Jobs.Add(obj);
                _context.SaveChanges();
                return Json(new { success = true, message = "New Job added sucessfully!" }, JsonRequestBehavior.AllowGet); 
        }
    }
}