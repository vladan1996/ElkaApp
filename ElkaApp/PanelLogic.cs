using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElkaApp.Models;

namespace ElkaApp
{
    public partial class PanelLogic : IDisposable
    {
        protected Models.ApplicationDbContext DB;

        public PanelLogic()
        {
            DB = new Models.ApplicationDbContext();
        }
        public void Dispose()
        {
            if (DB != null)
                DB.Dispose();
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

   

        public void UpdateUser(User user)
        {
            //  var findId = DB.Users.FirstOrDefault(x => x.UserID == id);

            var obj = DB.Users.FirstOrDefault(x => x.UserID == user.ID);
            //obj.Fullname

            obj.Fullname = user.Fullname;
            obj.Brithdate = user.Brithdate;
            obj.Street = user.Street;
            obj.City = user.City;
            obj.Phone = user.Phone;
            obj.Email = user.Email;
            obj.Profession = user.Profession;


                DB.SaveChanges();

            //return obj;

        }

    }




}
