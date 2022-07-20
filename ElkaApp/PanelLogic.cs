using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ElkaApp.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ElkaApp.Controllers;

//[assembly: OwinStartup(typeof(ElkaApp.Startup))];
namespace ElkaApp
{
    public partial class PanelLogic: IDisposable
    {
        protected Models.ApplicationDbContext DB;
        private ApplicationUserManager _userManager;

        public PanelLogic()
        {
            DB = new Models.ApplicationDbContext();
        }

        public PanelLogic(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //     set
        //    {
        //        _userManager = value;
        //    }
        //}
        


        public void Dispose()
        {
            if (DB != null)
                DB.Dispose();
        }
 

        public void AddCompany(Company company)
        {
            
            //var user = new Models.User;


            Company obj = new Company()
            {
                ID = Guid.NewGuid(),
                Name = company.Name,
                Street = company.Street,
                City = company.City,
                Phone = company.Phone,
                Email = company.Email,
                FilePath = company.FilePath
            };

            DB.Companies.Add(obj);
            DB.SaveChanges();
        }



        public void UpdateUser(User user)
        {
            var obj = DB.Users.FirstOrDefault(x => x.UserID == user.ID);

            obj.Fullname = user.Fullname;
            obj.Birthdate = user.Birthdate;
            obj.Street = user.Street;
            obj.City = user.City;
            obj.Phone = user.Phone;
            obj.Email = user.Email != null ? user.Email : obj.Email;
            obj.Profession = user.Profession;
            obj.FilePath = user.FilePath;

           var id = user.ID.ToString();


            DB.SaveChanges();
          //  var aspUser = _userManager.FindById(id);  //.Users.First(x => x.Id == id);
          //     aspUser.Email = user.Email;
          
            //var us = UserManager.FindById(id);
            
           

            //return obj;

        }

        public User GetUser(Guid id)
        {
            var obj = DB.Users.FirstOrDefault(x => x.UserID == id);
            return obj;
        }

        public Guid RegisterNewUser(string ID, RegisterViewModel model)
        {
            var user = new Models.User
            {
                ID = Guid.NewGuid(),
                UserID = Guid.Parse(ID),
                Fullname = model.Name + " " + model.Surname,
                Email = model.Email
            };
            DB.Users.Add(user);
            DB.SaveChanges();
            return user.ID;
        }

        public User getUserByAdmin(Guid id)
        {
            var obj = DB.Users.FirstOrDefault(x => x.UserID == id);
            return obj;
        }

        public void UpdateUserByAdmin(User user)
        {
            var obj = DB.Users.FirstOrDefault(x => x.UserID == user.ID);

            
            obj.Fullname = user.Fullname;
            obj.Phone = user.Phone;
            obj.City = user.City;
            obj.Email = user.Email != null ? user.Email : obj.Email;

            var id = user.ID.ToString();


            DB.SaveChanges();

        }

    }

}

