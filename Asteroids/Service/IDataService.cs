using Asteroids.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asteroids.Service
{
    public interface IDataService
    {
        void EditOfAsteroid(Asteroid asteroid);
        void CreateAsteroid(Asteroid asteroid);
        IList<Asteroid> GetAsteroids();
        Asteroid FindAsteroid(int ID);
        void RemoveAsteroid(Asteroid asteroid);
        void SaveChangesAsteroids();
    }
}