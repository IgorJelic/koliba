namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDbAgain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DrinkHelper", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.MealHelper", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Drink", "Name", c => c.String());
            AlterColumn("dbo.Meal", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meal", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Drink", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.MealHelper", "Name", c => c.String());
            AlterColumn("dbo.DrinkHelper", "Name", c => c.String());
        }
    }
}
