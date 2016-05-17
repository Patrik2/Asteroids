namespace Asteroids.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apple : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Asteroids", "PhotoOfAsteroid_ImageID", "dbo.ImageAsteroids");
            DropIndex("dbo.Asteroids", new[] { "PhotoOfAsteroid_ImageID" });
            DropColumn("dbo.Asteroids", "PhotoOfAsteroid_ImageID");
            DropTable("dbo.ImageAsteroids");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageAsteroids",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageSize = c.Int(nullable: false),
                        FileName = c.String(),
                        ImageData = c.Binary(),
                        Content = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.ImageID);
            
            AddColumn("dbo.Asteroids", "PhotoOfAsteroid_ImageID", c => c.Int());
            CreateIndex("dbo.Asteroids", "PhotoOfAsteroid_ImageID");
            AddForeignKey("dbo.Asteroids", "PhotoOfAsteroid_ImageID", "dbo.ImageAsteroids", "ImageID");
        }
    }
}
