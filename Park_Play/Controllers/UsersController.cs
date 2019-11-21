using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using Park_Play.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Park_Play.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext context;

        public UsersController()
        {
            context = new ApplicationDbContext();
        }


        public ActionResult GetSportSkillLvl()
        {
            var sports = context.Sports.AsNoTracking().ToList();
            var skillLevels = new List<SkillSportUser>();
            foreach (var sport in sports)
            {
                skillLevels.Add(new SkillSportUser { SportId = sport.SportId, Sport = sport });
            }
            UserSportViewModel userSportViewModel = new UserSportViewModel()
            { 
                SportList = sports, 
                sportSkillLevels = skillLevels
            };
            
            return View(userSportViewModel);
        }

        [HttpPost]
        public ActionResult GetSportSkillLvl(UserSportViewModel viewModel)
        {
            string id = User.Identity.GetUserId();
            User user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
            for(int i = 0; i < viewModel.sportSkillLevels.Count; i++)
            {
                SkillSportUser skillSportUser = new SkillSportUser()
                {
                    skillLevel = viewModel.sportSkillLevels[i].skillLevel,
                    SportId = viewModel.sportSkillLevels[i].SportId,
                    UserId = user.UserId
                };
                context.SkillSportUsers.Add(skillSportUser);
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Home", user);



        }

        // GET: Users
        public ActionResult Index()
        {
            return View(context.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            User user = context.Users.Where(u => u.UserId == id).FirstOrDefault();
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            User user = new User();
            return View();
        }
          

        // POST: Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                //string id = User.Identity.GetUserId();
                //user.ApplicationId = id;

                string requesturl = "https://maps.googleapis.com/maps/api/geocode/json?address=";
                string userAddress = System.Web.HttpUtility.UrlEncode(
                    user.streetAddress + " " +
                    user.city + " " +
                    user.stateCode);

                string apiKey = "&key="+APIKeys.GoogleMaps;


                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(requesturl + userAddress + apiKey);
                JObject map = JObject.Parse(response);
                user.lat = (float)map["results"][0]["geometry"]["location"]["lat"];
                user.lng = (float)map["results"][0]["geometry"]["location"]["lng"];
                string id = User.Identity.GetUserId();
                user.ApplicationId = id;
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("GetSportSkillLvl", "Users", user);
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            User user = context.Users.Where(u => u.UserId == id).FirstOrDefault();
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                // TODO: Add update logic here
                User editedUser = context.Users.Where(c => c.UserId == id).FirstOrDefault();
                editedUser.firstName = user.firstName;
                editedUser.lastName = user.lastName;
                editedUser.streetAddress = user.streetAddress;
                editedUser.city = user.city;
                editedUser.stateCode = user.stateCode;
                editedUser.zipCode = user.zipCode;
                editedUser.profilePicture = user.profilePicture;
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            User user = context.Users.Where(u => u.UserId == id).FirstOrDefault();
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                // TODO: Add delete logic here
                User userToDelete = context.Users.Where(u => u.UserId == id).FirstOrDefault();
                context.Users.Remove(userToDelete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
