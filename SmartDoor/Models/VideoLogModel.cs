using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartDoor.Models
{
    public class VideoLogModel
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int DoorDeviceId { get; set; }
        public int UserId { get; set; }
    }

    public class VideoLogDbContext : DbContext
    {
        public VideoLogDbContext() : base("DefaultConnection") { }
        public DbSet<VideoLogModel> VideoLogs { get; set; }
    }
}