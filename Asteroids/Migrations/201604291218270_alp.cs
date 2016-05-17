namespace Asteroids.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asteroids", "FileData", c => c.Binary());
            AddColumn("dbo.Asteroids", "PhotoOfAsteroid_ImageID", c => c.Int());
            AddColumn("dbo.ImageAsteroids", "Content", c => c.Binary(nullable: false));
            CreateIndex("dbo.Asteroids", "PhotoOfAsteroid_ImageID");
            AddForeignKey("dbo.Asteroids", "PhotoOfAsteroid_ImageID", "dbo.ImageAsteroids", "ImageID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asteroids", "PhotoOfAsteroid_ImageID", "dbo.ImageAsteroids");
            DropIndex("dbo.Asteroids", new[] { "PhotoOfAsteroid_ImageID" });
            DropColumn("dbo.ImageAsteroids", "Content");
            DropColumn("dbo.Asteroids", "PhotoOfAsteroid_ImageID");
            DropColumn("dbo.Asteroids", "FileData");
        }
    }
}
