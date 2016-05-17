using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Asteroids.Models
{
    public class AsteroidsContext : DbContext, IAsteroidsContext
    {
        public AsteroidsContext(string db) : base(db)
        {

        }
        public IDbSet<Asteroid> Asteroids { get; set; }
        public void SetModified(Asteroid asteroid)
        {
            Entry(asteroid).Property(x => x.Name).IsModified = true;
            Entry(asteroid).Property(x => x.Profit).IsModified = true;
            Entry(asteroid).Property(x => x.Value).IsModified = true;
        }
        public void SetStateModified(Asteroid asteroid)
        {
            Entry(asteroid).State = EntityState.Modified;
        }

        public void Detach(Asteroid asteroid)
        {
            ////Entry(asteroid).State = EntityState.Detached;
        }

    }
}