using Microsoft.AspNet.Identity;
using Park_Play.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park_Play.Controllers
{
    public class SportsController : Controller
    {
        ApplicationDbContext context;

        public SportsController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Sports
        public ActionResult Index()
        {
            return View(context.Sports.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            Sport sport = context.Sports.Where(u => u.SportId == id).FirstOrDefault();
            return View(sport);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            Sport sport = new Sport();
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Sport sport)
        {
            try
            {
                context.Sports.Add(sport);
                context.SaveChanges();

                string id = User.Identity.GetUserId();
                var user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
                sport.SportId = user.UserId;
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
            Sport sport = context.Sports.Where(u => u.SportId == id).FirstOrDefault();
            return View(sport);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Sport sport)
        {
            try
            {
                // TODO: Add update logic here
                Sport editedSport = context.Sports.Where(c => c.SportId == id).FirstOrDefault();
                editedSport.sportName = sport.sportName;
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
            Sport sport = context.Sports.Where(u => u.SportId == id).FirstOrDefault();
            return View(sport);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Sport sport)
        {
            try
            {
                // TODO: Add delete logic here
                Sport sportToDelete = context.Sports.Where(u => u.SportId == id).FirstOrDefault();
                context.Sports.Remove(sportToDelete);
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
