using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Asteroids.Models;

namespace Asteroids.Models
{
    public interface IAsteroidsContext
    {
        IDbSet<Asteroid> Asteroids { get; set; }
        void SetModified(Asteroid asteroid);
        void SetStateModified(Asteroid asteroid);

        void Detach(Asteroid asteroid);
        int SaveChanges();
        //void Dispose();
    }
}