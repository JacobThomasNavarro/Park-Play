using Microsoft.AspNet.Identity;
using Park_Play.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult ViewPlayEvents()
        {

            var playEvent = context.PlayEvents.Include(s => s.Sport).Include(p => p.Park).ToList();

            return View(playEvent);
        }

        public ActionResult JoinPlayEvent(int id)
        {
            PlayEvent playEvent = context.PlayEvents.Where(p => p.PlayEventId == id).FirstOrDefault();
            string Userid = User.Identity.GetUserId();
            User user = context.Users.Where(u => u.ApplicationId == Userid).FirstOrDefault();
            UserPlayEvent userPlayEvent = new UserPlayEvent()
            {
                UserId = user.UserId,
                PlayEventId = playEvent.PlayEventId
            };
            context.UserPlayEvents.Add(userPlayEvent);
            context.SaveChanges();
            return RedirectToAction("ViewPlayEvents", "PlayEvents");
        }

        public ActionResult PlayEventMembers(int id)
        {
            MembersViewModel membersView = new MembersViewModel() { PlayEvent = new PlayEvent(), UsersList = new List<User>() };
            PlayEvent playEvent = context.PlayEvents.Where(p => p.PlayEventId == id).FirstOrDefault();
            List<UserPlayEvent> userPlayEvents = context.UserPlayEvents.Where(u => u.PlayEventId == playEvent.PlayEventId).ToList();
            List<User> users = new List<User>();
            foreach (UserPlayEvent model in userPlayEvents)
            {
                var user = context.Users.Where(s => s.UserId == model.UserId).FirstOrDefault();
                users.Add(user);
            }
            foreach (User model in users)
            {
                membersView.UsersList.Add(model);
            }
            return View(membersView);
        }

        public ActionResult LeavePlayEvent(int id)
        {
            UserPlayEvent userPlayEvent = context.UserPlayEvents.Include(s => s.User).Include(p => p.PlayEvent).FirstOrDefault();
            context.UserPlayEvents.Remove(userPlayEvent);
            context.SaveChanges();
            return RedirectToAction("ViewPlayEvents", "PlayEvents");
        }

        public ActionResult RecommendedPlayEvents(int id)
        {
            SkillSportUser skillSport = context.SkillSportUsers.Include(u => u.User).Include(s => s.Sport).FirstOrDefault();
            PlayEvent playEvent = context.PlayEvents.Where(u => u.PlayEventId == id).FirstOrDefault();
            if(playEvent.skillLevel == skillSport.skillLevel)
            {
                context.PlayEvents.ToList();
            }
            return RedirectToAction("Index", "Home");
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
