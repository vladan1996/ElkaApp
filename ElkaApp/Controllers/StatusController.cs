using ElkaApp.Models;
using ElkaApp.Models.DTO;
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
            ViewBag.Status = BLL.GetStatuses();
            return View(applicantData);
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetStatuses()
        {
           var statusData = BLL.GetStatuses();
            //    ViewBag.Status = BLL.GetStatuses();
            return Json(statusData, JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        [HttpPost]
        public ActionResult UpdateJobStatus(UpdateStatusDTO data)
        {
            try
            {
                var applicantData = BLL.UpdateJobStatus(data);
                //  ViewBag.Status = BLL.GetStatuses();
                //return View(applicantData);
                return Json(new { applicantData, message="Job option changed!", success = true },JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) {
               
                return View(TempData["error"] = "Something went wrong!");
            }
        }



    }
}