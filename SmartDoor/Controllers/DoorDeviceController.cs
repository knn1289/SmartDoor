using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SmartDoor.Models;

namespace SmartDoor.Controllers
{
    public class DoorDeviceController : Controller
    {
        private readonly DoorDeviceDbContext _db = new DoorDeviceDbContext();

        // GET: /DoorDevice/
        public ActionResult Index()
        {
            return PartialView(_db.DoorDevices.ToList());
        }

        // GET: /DoorDevice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoorDeviceModel doordevicemodel = _db.DoorDevices.Find(id);
            if (doordevicemodel == null)
            {
                return HttpNotFound();
            }
            return View(doordevicemodel);
        }

        // GET: /DoorDevice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DoorDevice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,AndroidDeviceId,UserId,Privilege,RoomId")] DoorDeviceModel doordevicemodel)
        {
            if (ModelState.IsValid)
            {
                doordevicemodel.UserId = User.Identity.GetUserId();
                _db.DoorDevices.Add(doordevicemodel);
                _db.SaveChanges();
                return RedirectToAction("Home", "Home");
            }

            return View(doordevicemodel);
        }

        // GET: /DoorDevice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoorDeviceModel doordevicemodel = _db.DoorDevices.Find(id);
            if (doordevicemodel == null)
            {
                return HttpNotFound();
            }
            return View(doordevicemodel);
        }

        // POST: /DoorDevice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,AndroidDeviceId,UserId,Privilege,RoomId")] DoorDeviceModel doordevicemodel)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(doordevicemodel).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Home", "Home");
            }
            return View(doordevicemodel);
        }

        // GET: /DoorDevice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoorDeviceModel doordevicemodel = _db.DoorDevices.Find(id);
            if (doordevicemodel == null)
            {
                return HttpNotFound();
            }
            return View(doordevicemodel);
        }

        // POST: /DoorDevice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoorDeviceModel doordevicemodel = _db.DoorDevices.Find(id);
            _db.DoorDevices.Remove(doordevicemodel);
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

        public static Dictionary<int, string> GetAllDoorDevices(string userId)
        {
            var database = new DoorDeviceDbContext();
            var allDoors = database.DoorDevices.Where(x => x.UserId.Equals(userId));
            var list = allDoors.ToDictionary(at => at.Id, at => at.Name);
            database.Dispose();
            return list;
        }

        //public static Dictionary<int, string> GetPhysicians()
        //{
        //    var service = new PhysicianService();
        //    var goals = service.GetAll().Where(x => x.IsActive);
        //    var dictionary = goals.ToDictionary(goal => goal.Id, goal => goal.Person.FirstName + " " + goal.Person.LastName);
        //    return dictionary;
        //}
    }
}
