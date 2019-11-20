using Microsoft.AspNet.Identity;
using Park_Play.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park_Play.Controllers
{
    public class PlayEventsController : Controller
    {
        ApplicationDbContext context;

        public PlayEventsController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(context.PlayEvents.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            PlayEvent playEvent = context.PlayEvents.Where(u => u.PlayEventId == id).FirstOrDefault();
            return View(playEvent);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            PlayEvent playEvent = new PlayEvent();
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(PlayEvent playEvent)
        {
            try
            {
                context.PlayEvents.Add(playEvent);
                context.SaveChanges();

                string id = User.Identity.GetUserId();
                var user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
                playEvent.PlayEventId = user.UserId;
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
            PlayEvent playEvent = context.PlayEvents.Where(u => u.PlayEventId == id).FirstOrDefault();
            return View(playEvent);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PlayEvent playEvent)
        {
            try
            {
                // TODO: Add update logic here
                PlayEvent editedPlayEvent = context.PlayEvents.Where(c => c.PlayEventId == id).FirstOrDefault();
                editedPlayEvent.skillLevel = playEvent.skillLevel;
                editedPlayEvent.StartTime = playEvent.StartTime;
                editedPlayEvent.numberOfPlayers = playEvent.numberOfPlayers;
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
            PlayEvent playEvent = context.PlayEvents.Where(u => u.PlayEventId == id).FirstOrDefault();
            return View(playEvent);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PlayEvent playEvent)
        {
            try
            {
                // TODO: Add delete logic here
                PlayEvent playEventToDelete = context.PlayEvents.Where(u => u.PlayEventId == id).FirstOrDefault();
                context.PlayEvents.Remove(playEventToDelete);
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
