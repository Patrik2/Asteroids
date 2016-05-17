namespace Asteroids.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Asteroids", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asteroids", "Name", c => c.String());
        }
    }
}
