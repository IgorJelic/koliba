namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrator",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drink",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        HomeDelivery = c.Int(name: "Home Delivery", nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false),
                        FirstName = c.String(name: "First Name", maxLength: 20),
                        LastName = c.String(name: "Last Name", maxLength: 30),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salesman",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderedDrinks",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        DrinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.DrinkId })
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Drink", t => t.DrinkId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.DrinkId);
            
            CreateTable(
                "dbo.OrderedMeals",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.MealId })
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedMeals", "MealId", "dbo.Meal");
            DropForeignKey("dbo.OrderedMeals", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderedDrinks", "DrinkId", "dbo.Drink");
            DropForeignKey("dbo.OrderedDrinks", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "Customer_Id", "dbo.User");
            DropIndex("dbo.OrderedMeals", new[] { "MealId" });
            DropIndex("dbo.OrderedMeals", new[] { "OrderId" });
            DropIndex("dbo.OrderedDrinks", new[] { "DrinkId" });
            DropIndex("dbo.OrderedDrinks", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "Customer_Id" });
            DropTable("dbo.OrderedMeals");
            DropTable("dbo.OrderedDrinks");
            DropTable("dbo.Salesman");
            DropTable("dbo.Meal");
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.Drink");
            DropTable("dbo.Administrator");
        }
    }
}
