namespace Asteroids.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Asteroids", "PhotoOfAsteroid_ImageID", "dbo.ImageAsteroids");
            DropIndex("dbo.Asteroids", new[] { "PhotoOfAsteroid_ImageID" });
            AddColumn("dbo.Asteroids", "FileName", c => c.String());
            DropColumn("dbo.Asteroids", "PhotoOfAsteroid_ImageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Asteroids", "PhotoOfAsteroid_ImageID", c => c.Int());
            DropColumn("dbo.Asteroids", "FileName");
            CreateIndex("dbo.Asteroids", "PhotoOfAsteroid_ImageID");
            AddForeignKey("dbo.Asteroids", "PhotoOfAsteroid_ImageID", "dbo.ImageAsteroids", "ImageID");
        }
    }
}
