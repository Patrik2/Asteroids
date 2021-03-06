namespace Asteroids.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Asteroids", "Profit", c => c.Double(nullable: false));
            AlterColumn("dbo.Asteroids", "Value", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asteroids", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Asteroids", "Profit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
