namespace StrengthCraft.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, CategoryName) VALUES (1, 'Rookie')");
            Sql("INSERT INTO Categories (Id, CategoryName) VALUES (2, 'Open')");
        }
        
        public override void Down()
        {
            Sql("DELTE FROM Categories WHERE Id IN (1, 2)");
        }
    }
}
