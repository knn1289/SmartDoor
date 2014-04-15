using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartDoor.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace SmartDoor.Helpers
{
    //public static class ListHelper : Controller
    //{
    //    private AndroidDeviceDBContext androidDeviceDB = new AndroidDeviceDBContext();
    //    private DoorDeviceDBContext doorDeviceDB = new DoorDeviceDBContext();

    //    public static Dictionary<int, string> GetDoorIds()
    //    {
    //        var currentUserId = User.Identity.GetUserId();

    //        var doorIds = doorDeviceDB.DoorDevices.Where(x => String.Compare(x.UserId, currentUserId) == 0);
    //        //AndroidDeviceModel androiddevicemodel = androidDeviceDB.AndroidDevices.Find(id);
    //        return doorIds.ToDictionary(door => door.Id, door => door.Name);
    //    }
    //}
}