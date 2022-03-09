namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingForeignKeyOrderedMealsAndOrderedDrinks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderedMeals", "MealId", "dbo.Meal");
            //DropForeignKey("dbo.OrderedMeals", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderedDrinks", "DrinkId", "dbo.Drink");
            //DropForeignKey("dbo.OrderedDrinks", "OrderId", "dbo.Order");

            //AddForeignKey("dbo.OrderedMeals", "MealId", "dbo.MealHelper");
            AddForeignKey("dbo.OrderedMeals", "OrderedMealId", "dbo.MealHelper");
            AddForeignKey("dbo.OrderedDrinks", "OrderedDrinkId", "dbo.DrinkHelper");
            //AddForeignKey("dbo.OrderedDrinks", "DrinkId", "dbo.DrinkHelper");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedMeals", "OrderedMealId", "dbo.MealHelper");
            DropForeignKey("dbo.OrderedDrinks", "OrderedDrinkId", "dbo.DrinkHelper");
            AddForeignKey("dbo.OrderedMeals", "MealId", "dbo.Meal");
            AddForeignKey("dbo.OrderedDrinks", "DrinkId", "dbo.Drink");
        }
    }
}
