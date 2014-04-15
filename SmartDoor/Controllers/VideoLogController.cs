using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartDoor.Models;

namespace SmartDoor.Controllers
{
    public class VideoLogController : Controller
    {
        //
        // GET: /VideoLog/
        public ActionResult Index(VideoLogModel model)
        {
            return PartialView(model);
        }

        public ActionResult WebRtc(VideoLogModel model)
        {
            return View(model);
        }

        //
        // GET: /VideoLog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /VideoLog/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VideoLog/Create
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

        //
        // GET: /VideoLog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /VideoLog/Edit/5
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

        //
        // GET: /VideoLog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /VideoLog/Delete/5
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
