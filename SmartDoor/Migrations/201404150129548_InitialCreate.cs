namespace SmartDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AndroidDeviceModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SmartDoorDeviceId = c.String(),
                        UserId = c.String(),
                        Privilege = c.String(),
                        RoomId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AndroidDeviceModels");
        }
    }
}
