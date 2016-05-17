using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asteroids.Models;
using Asteroids.Service;

namespace Asteroids.Controllers
{
    public class AsteroidsController : Controller
    {
        //private AsteroidsContext asteroidsContext;
        private IDataService services;
        public AsteroidsController(IDataService services)
        {
            //this.asteroidsContext = asteroidsContext;
            this.services = services;
        }
        //public AsteroidsController(AsteroidsContext asteroidContext)
        //{
        //    asteroidsContext = asteroidContext;
        //}
        //public AsteroidsController()
        //{
        //    AsteroidsContext asteroidsContext = new AsteroidsContext();
        //    this.asteroidsContext = asteroidsContext;
        //}
        //public AsteroidsController(IAsteroidsContext asteroidContext)
        //{
        //    this.asteroidsContext = asteroidsContext;
        //}
        // GET: Asteroids
        public ActionResult Index()
        {
            //return View(asteroidsContext.Asteroids.ToList());
            var asteroids = services.GetAsteroids();
            return View(asteroids);
        }
        // GET: Asteroids/Details/5
        public ActionResult Details(int id)
        {
            //Asteroid asteroid = asteroidsContext.Asteroids.Find(id);
            var asteroid = services.FindAsteroid(id);
            if (asteroid == null)
            {
                return HttpNotFound();
            }
            return View(asteroid);
        }
        // GET: Asteroids/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Asteroids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asteroid asteroid)
        {
            //[Bind(Include = "ID,Name,Profit,Value")]
            if (ModelState.IsValid)
            {
                services.CreateAsteroid(asteroid);
                return RedirectToAction("Index");
            }
            return View(asteroid);
        }
        // GET: Asteroids/Edit/5
        public ActionResult Edit(int id)
        {
            //ModelState.Clear();
            //Asteroid asteroid = asteroidsContext.Asteroids.Find(id);
            var asteroid = services.FindAsteroid(id);
            if (asteroid == null)
            {
                return HttpNotFound();
            }
            return View(asteroid);
        }
        // POST: Asteroids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Profit,Value,File")] Asteroid asteroid)
        {
            if (ModelState.IsValid)
            {
                services.EditOfAsteroid(asteroid);
                return RedirectToAction("Index");
            }
            return View(asteroid);
        }
        //public void EditOfAsteroid(IAsteroid asteroid)
        //{
        //    if (asteroid.File != null)
        //    {
        //        asteroid.FileName = asteroid.File.FileName;
        //        byte[] data = new byte[asteroid.File.ContentLength];
        //        asteroid.File.InputStream.Read(data, 0, asteroid.File.ContentLength);
        //        asteroid.FileData = data;
        //        asteroidsContext.SetStateModified(asteroid);
        //        //asteroidsContext.Entry(asteroid).State = EntityState.Modified;
        //    }
        //    else
        //    {
        //        asteroidsContext.Asteroids.Attach((Asteroid)asteroid);
        //        asteroidsContext.SetModified(asteroid);
        //        //asteroidsContext.Entry(asteroid).Property(x => x.Name).IsModified = true;
        //        //asteroidsContext.Entry(asteroid).Property(x => x.Profit).IsModified = true;
        //        //asteroidsContext.Entry(asteroid).Property(x => x.Value).IsModified = true;
        //    }
        //    asteroidsContext.SaveChanges();
        //}

        // GET: Asteroids/Delete/5
        public ActionResult Delete(int id)
        {
            //Asteroid asteroid = asteroidsContext.Asteroids.Find(id);
            var asteroid = services.FindAsteroid(id);
            if (asteroid == null)
            {
                return HttpNotFound();
            }
            return View(asteroid);
        }
        // POST: Asteroids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Asteroid asteroid = asteroidsContext.Asteroids.Find(id);
            var asteroid = services.FindAsteroid(id);
            services.RemoveAsteroid(asteroid);
            services.SaveChangesAsteroids();
            //asteroidsContext.Asteroids.Remove(asteroid);
            //asteroidsContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        asteroidsContext.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
