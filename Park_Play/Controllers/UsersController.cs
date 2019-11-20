﻿using Newtonsoft.Json.Linq;
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
            User users = new User();
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                context.Users.Add(user);
                string requesturl = "https://maps.googleapis.com/maps/api/geocode/json?address=";
                string userAddress = System.Web.HttpUtility.UrlEncode(
                    user.streetAddress + " " +
                    user.city + " " +
                    user.stateCode + " " +
                    user.zipCode);

                string apiKey = APIKeys.GoogleMaps;


                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(requesturl + userAddress + apiKey);
                JObject map = JObject.Parse(response);
                user.lat = (float)map["results"][0]["geometry"]["location"]["lat"];
                user.lng = (float)map["results"][0]["geometry"]["location"]["lng"];
                context.SaveChanges();
                return RedirectToAction("Details", "Users", user);
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
