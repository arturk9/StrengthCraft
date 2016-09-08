namespace StrengthCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingAttendeeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "IsVerified", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "IsVerified");
        }
    }
}
