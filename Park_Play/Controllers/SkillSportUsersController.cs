using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park_Play.Controllers
{
    public class SkillSportUsersController : Controller
    {
        // GET: SkillSportUsers
        public ActionResult Index()
        {
            return View();
        }

        // GET: SkillSportUsers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SkillSportUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillSportUsers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SkillSportUsers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SkillSportUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SkillSportUsers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SkillSportUsers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
