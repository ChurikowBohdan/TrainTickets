namespace TrainTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Route", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Route", "Number");
        }
    }
}
