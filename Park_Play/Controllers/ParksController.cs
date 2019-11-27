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
    public class ParksController : Controller
    {
        ApplicationDbContext context;

        public ParksController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(context.Parks.ToList());
        }

        public ActionResult ParkSportView(int id)
        {
            ParkSportViewModel parkSportView = new ParkSportViewModel() {ParkName = "", SportsList = new List<Sport>()};
            Park park = context.Parks.Where(p => p.ParkId == id).FirstOrDefault();
            parkSportView.ParkName = park.parkName;
            List<ParkSport> parkSport = context.ParkSports.Where(p => p.ParkId == park.ParkId).ToList();
            List<Sport> sportList = new List<Sport>();
            foreach (ParkSport model in parkSport)
            {
                var sport = context.Sports.Where(s => s.SportId == model.SportId).FirstOrDefault();
                sportList.Add(sport);
            }
            foreach (Sport model in sportList)
            {
                parkSportView.SportsList.Add(model);
            }
            return View(parkSportView);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            Park park = context.Parks.Where(p => p.ParkId == id).FirstOrDefault();
            return View(park);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            Park parks = new Park();
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(Park park)
        {
            try
            {
                // TODO: Add insert logic here
                context.Parks.Add(park);
                string requesturl = "https://maps.googleapis.com/maps/api/geocode/json?address=";
                string userAddress = System.Web.HttpUtility.UrlEncode(
                    park.streetAddress + " " +
                    park.city + " " +
                    park.stateCode);

                string apiKey = "&key="+APIKeys.GoogleMaps;


                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(requesturl + userAddress + apiKey);
                JObject map = JObject.Parse(response);
                park.lat = (float)map["results"][0]["geometry"]["location"]["lat"];
                park.lng = (float)map["results"][0]["geometry"]["location"]["lng"];
                context.SaveChanges();
                return RedirectToAction("Details", "Parks", park);
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            Park park = context.Parks.Where(u => u.ParkId == id).FirstOrDefault();
            return View(park);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Park park)
        {
            try
            {
                // TODO: Add update logic here
                Park editedPark = context.Parks.Where(c => c.ParkId == id).FirstOrDefault();
                editedPark.parkName = park.parkName;
                editedPark.streetAddress = park.streetAddress;
                editedPark.city = park.city;
                editedPark.stateCode= park.stateCode;
                editedPark.zipCode = park.zipCode;
                editedPark.contactNumber = park.contactNumber;
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
            Park park = context.Parks.Where(u => u.ParkId == id).FirstOrDefault();
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Park park)
        {
            try
            {
                // TODO: Add delete logic here
                Park parkToDelete = context.Parks.Where(u => u.ParkId == id).FirstOrDefault();
                context.Parks.Remove(parkToDelete);
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
