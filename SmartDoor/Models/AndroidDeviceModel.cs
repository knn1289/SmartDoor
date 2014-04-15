using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartDoor.Models
{
    public class AndroidDeviceModel
    {
        public int Id { get; set; }

        [Display(Name = "Android Name")]
        public string Name { get; set; }

        [Display(Name = "Door Device ID")]
        public string SmartDoorDeviceId { get; set; }

        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [Display(Name = "Privilege")]
        public string Privilege { get; set; } //This is the token. It is a key that defines who can enter the "room", and once inside what they can do.

        [Display(Name = "Room ID")]
        public string RoomId { get; set; } // Room ID identifies the "room" in which participants will meet and chat.
        public bool Active { get; set; }
    }

    public class AndroidDeviceDbContext : DbContext
    {
        public AndroidDeviceDbContext() : base("DefaultConnection") { }
        public DbSet<AndroidDeviceModel> AndroidDevices { get; set; }
    }
}