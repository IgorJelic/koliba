namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDeliveredFieldToOrders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Delivered", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Delivered");
        }
    }
}
