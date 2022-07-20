using ElkaApp.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElkaApp.Controllers
{
    public class UserController : BaseController
    {

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        PanelLogic p = new PanelLogic();
        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            // var user = CurrentUser.ID;
            //var model = BLL.FindUserById(user);
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task UpdateData(User user, HttpPostedFileBase picture)
        {
            var us = await UserManager.FindByIdAsync(user.ID.ToString());

            if (picture != null)
            {
                if (!Directory.Exists(Server.MapPath("~/Content/Image/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/Image"));
                }

                string fileName = Path.GetFileNameWithoutExtension(picture.FileName);
                string extension = Path.GetExtension(picture.FileName);
                fileName = fileName + extension;

                var filePath = Path.Combine(Server.MapPath("~/Content/Image/"), fileName);

                picture.SaveAs(filePath);

                user.FilePath = "/Content/Image/" + fileName;
            }

            BLL.UpdateUser(user);

            us.Email = user.Email;
            us.UserName = user.Email;
            //     UserManager.UpdateAsync()
            await UserManager.UpdateAsync(us);
            // return data;
        }


        public JsonResult GetData(Guid id)
        {
            return Json(BLL.GetUser(id), JsonRequestBehavior.AllowGet); //Json(BLL.GetUser(id));
        }


        public ActionResult ViewAllUsers ()
        {
            
            return View();
        }

        public ActionResult updateUserByAdmin()
        {
            return View();
        }
        
        public async Task updateUserByAdmin(User user)
        {
            var u = await UserManager.FindByIdAsync(user.ID.ToString());
            BLL.UpdateUserByAdmin(user);

            u.Email = user.Email;
            u.UserName = user.Email;
            //     UserManager.UpdateAsync()
            await UserManager.UpdateAsync(u);
        }

        public JsonResult GetDataByAdmin(Guid id)
        {
            return Json(BLL.getUserByAdmin(id), JsonRequestBehavior.AllowGet);
        }
    }
}