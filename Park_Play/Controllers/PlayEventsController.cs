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

        public ActionResult ParkEvent(int id)
        {
            ParkEventViewModel parkEventView = new ParkEventViewModel() { Park = null, Sport = new Sport() { SportId = 1, sportName = "Soccer" } };
            Park park = context.Parks.Where(p => p.ParkId == id).FirstOrDefault();
            parkEventView.Park = park;
            List<ParkSport> parkSport = context.ParkSports.Where(p => p.ParkId == park.ParkId).ToList();
            List<Sport> sportList = new List<Sport>();
            foreach(ParkSport model in parkSport)
            {
                var sport = context.Sports.Where(s => s.SportId == model.SportId).FirstOrDefault();
                sportList.Add(sport);
            }
            ViewBag.Results = sportList;
            parkEventView.SportsList = sportList;
            return View(parkEventView);
        }

        [HttpPost]
        public ActionResult ParkEvent(ParkEventViewModel parkEventView)
        {
            string id = User.Identity.GetUserId();
            User user = context.Users.Where(u => u.ApplicationId == id).FirstOrDefault();
            PlayEvent playEvent = new PlayEvent()
            {
                ParkId = parkEventView.Park.ParkId,
                //Park = parkEventView.Park,
                SportId = parkEventView.Sport.SportId,
                //Sport = parkEventView.Sport,
                PlayDate = parkEventView.PlayDate,
                StartTime = parkEventView.StartTime,
                EndTime = parkEventView.EndTime,
                skillLevel = parkEventView.skillLevel,
                numberOfPlayers = parkEventView.numberOfPlayers
            };
            //var parkObject = context.Parks.Where(p => p.ParkId == playEvent.ParkId).Single();
            //playEvent.Park.streetAddress = parkObject.streetAddress;
            //playEvent.Park.city = parkObject.city;
            //playEvent.Park.stateCode = parkObject.stateCode;
            //playEvent.Park.parkName = parkObject.parkName;
            //var sportObject = context.Sports.Where(s => s.SportId == playEvent.SportId).Single();
            //playEvent.Sport.sportName = sportObject.sportName;
            context.PlayEvents.Add(playEvent);
            context.SaveChanges();
            return RedirectToAction("Index", "Home", user);
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
            return RedirectToAction("Index", "Home", user);
        }

        public ActionResult LeavePlayEvent(int id)
        {
            UserPlayEvent userPlayEvent = context.UserPlayEvents.Where(p => p.UserPlayEventId == id).FirstOrDefault();
            string Userid = User.Identity.GetUserId();
            User user = context.Users.Where(u => u.ApplicationId == Userid).FirstOrDefault();
            context.UserPlayEvents.Remove(userPlayEvent);
            context.SaveChanges();
            return RedirectToAction("Index", "Home", user);
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
