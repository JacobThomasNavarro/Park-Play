using Microsoft.AspNet.Identity;
using Park_Play.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park_Play.Controllers
{
    public class SkillSportUsersController : Controller
    {
        ApplicationDbContext context;

        public SkillSportUsersController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(context.SkillSportUsers.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            SkillSportUser skillSportUser = context.SkillSportUsers.Where(u => u.SkillSportUserId == id).FirstOrDefault();
            return View(skillSportUser);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            SkillSportUser skillSportUser = new SkillSportUser();
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(SkillSportUser skillSportUser)
        {
            try
            {
                context.SkillSportUsers.Add(skillSportUser);
                context.SaveChanges();

                string id = User.Identity.GetUserId();
                var user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
                skillSportUser.SkillSportUserId = user.UserId;
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
           SkillSportUser skillSportUser = context.SkillSportUsers.Where(u => u.SkillSportUserId == id).FirstOrDefault();
            return View(skillSportUser);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SkillSportUser skillSportUser)
        {
            try
            {
                // TODO: Add update logic here
                SkillSportUser editedSkillSportUser = context.SkillSportUsers.Where(c => c.SkillSportUserId == id).FirstOrDefault();
                editedSkillSportUser.skillLevel = skillSportUser.skillLevel;
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
            SkillSportUser skillSportUser = context.SkillSportUsers.Where(u => u.SkillSportUserId == id).FirstOrDefault();
            return View(skillSportUser);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SkillSportUser skillSportUser)
        {
            try
            {
                // TODO: Add delete logic here
                SkillSportUser skillSportUserToDelete = context.SkillSportUsers.Where(u => u.SkillSportUserId == id).FirstOrDefault();
                context.SkillSportUsers.Remove(skillSportUserToDelete);
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
