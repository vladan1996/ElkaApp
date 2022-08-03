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
using ElkaApp.Models.DTO;

//[assembly: OwinStartup(typeof(ElkaApp.Startup))];
namespace ElkaApp
{
    public partial class PanelLogic : IDisposable
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
            if (user.FilePath != null)
            {
                obj.FilePath = user.FilePath;
            }

            //var id = user.ID.ToString();


            DB.SaveChanges();

        }

        public User GetUser(Guid id)
        {
            var obj = DB.Users.FirstOrDefault(x => x.UserID == id);
            return obj;
        }

        public List<User> GetAllUsers()
        {
            var obj = DB.Users.ToList();

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

        public void CreateJob(Job obj)
        {
            obj.ID = Guid.NewGuid();
            DB.Jobs.Add(obj);
            DB.SaveChanges();
            

        }

        public bool JobApplication (string userID, Guid jobID)
        {
            var id = Guid.Parse(userID);
            var user = DB.Users.FirstOrDefault(x => x.UserID == id);
            var status = DB.Statuses.FirstOrDefault(x => x.StatusName == "Rejected");

            var jobStatus = new Models.JobStatus
            {
                ID = Guid.NewGuid(),
                UserID = user.ID,
                JobID = jobID,
                StatusID = status.ID,
            };

            DB.JobStatuses.Add(jobStatus);
            DB.SaveChanges();

            return true;
        }

        public List<JobStatus> GetJobStatusDate()
        {
            var data = DB.JobStatuses.ToList();
            return data;
        }

        public JobStatus GetApplicant(Guid id)
        {
            var applicant = DB.JobStatuses.Single(x => x.ID == id);

            return applicant;
        }
        public User getUserByAdmin(Guid id)
        {
            var obj = DB.Users.FirstOrDefault(x => x.UserID == id);
            if(obj.FilePath == null)
            {
                obj.FilePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/1024px-No_image_available.svg.png";
            }
            return obj;
        }

        public void UpdateUserDataByAdmin(User user)
        {
            var obj = DB.Users.FirstOrDefault(x => x.UserID == user.ID);

         
            obj.Fullname = user.Fullname;
            obj.Phone = user.Phone;
            obj.City = user.City;
            obj.Email = user.Email != null ? user.Email : obj.Email;

            var id = user.ID.ToString();


            DB.SaveChanges();

        }

        public void DeleteUser(Guid id)
        {
            var user = DB.Users.FirstOrDefault(x => x.UserID == id);
            DB.Users.Remove(user);
            DB.SaveChanges();

        }

        public List<Status>GetStatuses()
        {
            var data = DB.Statuses.ToList();
            return data;
        }

        public bool UpdateJobStatus(UpdateStatusDTO data) {

            if (data.JobStausId != null && data.OldStatusId != null && data.NewStatusId != null) {
                var jobStatus = DB.JobStatuses.FirstOrDefault(x => x.ID == data.JobStausId && x.StatusID == data.OldStatusId);

                jobStatus.StatusID = data.NewStatusId;

                DB.SaveChanges();

                return true;
            }
            
            return false;
        }
    }

}

