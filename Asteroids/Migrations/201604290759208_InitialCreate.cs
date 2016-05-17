namespace Asteroids.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asteroids",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Profit = c.Double(nullable: false),
                        Value = c.Double(nullable: false),
                        PhotoOfAsteroid_ImageID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ImageAsteroids", t => t.PhotoOfAsteroid_ImageID)
                .Index(t => t.PhotoOfAsteroid_ImageID);
            
            CreateTable(
                "dbo.ImageAsteroids",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageSize = c.Int(nullable: false),
                        FileName = c.String(),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asteroids", "PhotoOfAsteroid_ImageID", "dbo.ImageAsteroids");
            DropIndex("dbo.Asteroids", new[] { "PhotoOfAsteroid_ImageID" });
            DropTable("dbo.ImageAsteroids");
            DropTable("dbo.Asteroids");
        }
    }
}
