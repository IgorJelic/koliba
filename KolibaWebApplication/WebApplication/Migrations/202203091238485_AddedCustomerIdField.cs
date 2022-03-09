namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerIdField : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Order", name: "Customer_Id", newName: "CustomerId");
            RenameIndex(table: "dbo.Order", name: "IX_Customer_Id", newName: "IX_CustomerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Order", name: "IX_CustomerId", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.Order", name: "CustomerId", newName: "Customer_Id");
        }
    }
}
