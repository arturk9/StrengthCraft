namespace StrengthCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRegistrationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "RegistrationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "RegistrationDate");
        }
    }
}
