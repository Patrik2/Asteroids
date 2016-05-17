using Asteroids.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Asteroids.Service
{
    public class DbService : IDataService
    {
        private IAsteroidsContext asteroidsContext;
        public DbService(IAsteroidsContext asteroidsContext)
        {
            this.asteroidsContext = asteroidsContext;
        }
        public void EditOfAsteroid(Asteroid asteroid)
        {
            IAsteroidsContext context = (IAsteroidsContext)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IAsteroidsContext));
            if (asteroid.File != null)
            {
                asteroid.FileName = asteroid.File.FileName;
                byte[] data = new byte[asteroid.File.ContentLength];
                asteroid.File.InputStream.Read(data, 0, asteroid.File.ContentLength);
                asteroid.FileData = data;
                asteroidsContext.SetStateModified(asteroid);
                //asteroidsContext.Entry(asteroid).State = EntityState.Modified;
            }
            else
            {
                asteroidsContext.Asteroids.Attach((Asteroid)asteroid);
                asteroidsContext.SetModified(asteroid);
                //asteroidsContext.SetStateModified(asteroid);
                //asteroidsContext.Entry(asteroid).Property(x => x.Name).IsModified = true;
                //asteroidsContext.Entry(asteroid).Property(x => x.Profit).IsModified = true;
                //asteroidsContext.Entry(asteroid).Property(x => x.Value).IsModified = true;
            }
            
            asteroidsContext.SaveChanges();
            asteroidsContext.Detach(asteroid);
        }
        public void CreateAsteroid(Asteroid asteroid)
        {
            if (asteroid.File != null)
            {
                asteroid.FileName = asteroid.File.FileName;
                byte[] data = new byte[asteroid.File.ContentLength];
                asteroid.File.InputStream.Read(data, 0, asteroid.File.ContentLength);
                asteroid.FileData = data;
            }

            asteroidsContext.Asteroids.Add(asteroid);
            asteroidsContext.SaveChanges();
            asteroidsContext.Detach(asteroid);
        }
        public IList<Asteroid> GetAsteroids()
        {
            return asteroidsContext.Asteroids.ToList();
        }
        public Asteroid FindAsteroid(int ID)
        {
            var asteroid = asteroidsContext.Asteroids.Find(ID);
            return asteroid;
        }
        public void RemoveAsteroid(Asteroid asteroid)
        {
            asteroidsContext.Asteroids.Remove(asteroid);
        }
        public void SaveChangesAsteroids()
        {
            asteroidsContext.SaveChanges();
        }
    }
}