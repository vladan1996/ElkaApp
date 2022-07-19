using ElkaApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElkaApp.Controllers
{
    public class CompanyController : BaseController
    {

        // GET: Company
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveCompany(Company model, HttpPostedFileBase FilePath)
        {

            string fileName = Path.GetFileNameWithoutExtension(FilePath.FileName);
            string extension = Path.GetExtension(FilePath.FileName);

            fileName = fileName + extension;

            var filePath = Path.Combine(Server.MapPath("~/Image/"), fileName);
            model.FilePath = filePath;
           

            BLL.AddCompany(model);
            return RedirectToAction("Index");
        }
    }

}