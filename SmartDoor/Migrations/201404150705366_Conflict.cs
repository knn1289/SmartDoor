namespace SmartDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conflict : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AndroidDeviceModels", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AndroidDeviceModels", "Active");
        }
    }
}
