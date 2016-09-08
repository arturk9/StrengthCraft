namespace StrengthCraft.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class temp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendees", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Attendees", new[] { "Category_Id" });
            AlterColumn("dbo.Attendees", "AttendeeName", c => c.String());
            AlterColumn("dbo.Attendees", "AttendeeLastName", c => c.String());
            AlterColumn("dbo.Attendees", "EmailAddress", c => c.String());
            AlterColumn("dbo.Attendees", "YoutubeMovieUrl", c => c.String());
            AlterColumn("dbo.Attendees", "WorkoutDurationTime", c => c.String());
            AlterColumn("dbo.Attendees", "Category_Id", c => c.Byte());
            CreateIndex("dbo.Attendees", "Category_Id");
            AddForeignKey("dbo.Attendees", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendees", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Attendees", new[] { "Category_Id" });
            AlterColumn("dbo.Attendees", "Category_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Attendees", "WorkoutDurationTime", c => c.String(nullable: false));
            AlterColumn("dbo.Attendees", "YoutubeMovieUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Attendees", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Attendees", "AttendeeLastName", c => c.String(nullable: false));
            AlterColumn("dbo.Attendees", "AttendeeName", c => c.String(nullable: false));
            CreateIndex("dbo.Attendees", "Category_Id");
            AddForeignKey("dbo.Attendees", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
