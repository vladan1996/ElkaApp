using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ElkaApp.Controllers
{
    public class BaseController : Controller
    {
        protected PanelLogic BLL;

        public BaseController()
        {
            BLL = new PanelLogic();
        }
    }
}