namespace OrdersApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStoredProcedure : DbMigration
    {
        public override void Up()
        {
            SqlResource("OrdersApp.Domain.Resources.CreateProcedure.sql");
        }
        
        public override void Down()
        {

        }
    }
}
