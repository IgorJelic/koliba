namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingOrderConfigurationStuff : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Order", name: "Delivered", newName: "IsDelivered");
            RenameColumn(table: "dbo.OrderedDrinks", name: "DrinkId", newName: "OrderedDrinkId");
            RenameColumn(table: "dbo.OrderedMeals", name: "MealId", newName: "OrderedMealId");
            RenameIndex(table: "dbo.OrderedDrinks", name: "IX_DrinkId", newName: "IX_OrderedDrinkId");
            RenameIndex(table: "dbo.OrderedMeals", name: "IX_MealId", newName: "IX_OrderedMealId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OrderedMeals", name: "IX_OrderedMealId", newName: "IX_MealId");
            RenameIndex(table: "dbo.OrderedDrinks", name: "IX_OrderedDrinkId", newName: "IX_DrinkId");
            RenameColumn(table: "dbo.OrderedMeals", name: "OrderedMealId", newName: "MealId");
            RenameColumn(table: "dbo.OrderedDrinks", name: "OrderedDrinkId", newName: "DrinkId");
            RenameColumn(table: "dbo.Order", name: "IsDelivered", newName: "Delivered");
        }
    }
}
