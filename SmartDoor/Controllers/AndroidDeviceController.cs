using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SmartDoor.Models;

namespace SmartDoor.Controllers
{
    public class AndroidDeviceController : Controller
    {
        private readonly AndroidDeviceDbContext _db = new AndroidDeviceDbContext();
        private readonly DoorDeviceDbContext _dbDoorDeviceDbContext = new DoorDeviceDbContext();

        // GET: /AndroidDevice/
        public ActionResult Index()
        {
            return PartialView(_db.AndroidDevices.ToList());
        }

        // GET: /AndroidDevice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AndroidDeviceModel androiddevicemodel = _db.AndroidDevices.Find(id);
            if (androiddevicemodel == null)
            {
                return HttpNotFound();
            }
            return View(androiddevicemodel);
        }

        // GET: /AndroidDevice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AndroidDevice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,SmartDoorDeviceId,UserId,Privilege,RoomId")] AndroidDeviceModel androiddevicemodel)
        {
            if (ModelState.IsValid)
            {
                androiddevicemodel.UserId = User.Identity.GetUserId();
                if (androiddevicemodel.SmartDoorDeviceId != null)
                {
                    var doorDeviceId = Convert.ToInt32(androiddevicemodel.SmartDoorDeviceId);
                    var door = _dbDoorDeviceDbContext.DoorDevices.First(x => x.Id == doorDeviceId);
                    door.Active = true;

                    androiddevicemodel.Active = true;
                    _db.AndroidDevices.Add(androiddevicemodel);
                    _db.SaveChanges();

                    door.AndroidDeviceId = androiddevicemodel.Id.ToString(CultureInfo.InvariantCulture);
                    _dbDoorDeviceDbContext.Entry(door).State = EntityState.Modified;
                    _dbDoorDeviceDbContext.SaveChanges();

                }
                else
                {
                    _db.AndroidDevices.Add(androiddevicemodel);
                    _db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(androiddevicemodel);
        }

        // GET: /AndroidDevice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AndroidDeviceModel androiddevicemodel = _db.AndroidDevices.Find(id);
            if (androiddevicemodel == null)
            {
                return HttpNotFound();
            }
            return View(androiddevicemodel);
        }

        // POST: /AndroidDevice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,SmartDoorDeviceId,UserId,Privilege,RoomId")] AndroidDeviceModel androiddevicemodel)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(androiddevicemodel).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(androiddevicemodel);
        }

        // GET: /AndroidDevice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AndroidDeviceModel androiddevicemodel = _db.AndroidDevices.Find(id);
            if (androiddevicemodel == null)
            {
                return HttpNotFound();
            }
            return View(androiddevicemodel);
        }

        // POST: /AndroidDevice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AndroidDeviceModel androiddevicemodel = _db.AndroidDevices.Find(id);
            _db.AndroidDevices.Remove(androiddevicemodel);
            _db.SaveChanges();
            return RedirectToAction("Home", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
