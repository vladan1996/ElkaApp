using ElkaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElkaApp.Controllers
{
    public class UserController : Controller
    {

        PanelLogic p = new PanelLogic();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public void UpdateData( User user) {
         
            p.UpdateUser(user);

               // return data;

        }

    }
}