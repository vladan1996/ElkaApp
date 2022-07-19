using ElkaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElkaApp.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

       //public ActionResult SaveCompany(Company model)
       // {

       // }
    }
}