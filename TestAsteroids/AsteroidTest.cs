using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Asteroids.Controllers;
using Asteroids.Models;
using Moq;
using System.Data.Entity;
using System.Web.Mvc;
using Asteroids.Service;
using System.ComponentModel.DataAnnotations;

namespace AsteroidsTest
{
    [TestClass]
    public class AsteroidTest
    {
        private Mock<IDbSet<T>> CreateMockedDbSet<T>(IEnumerable<T> elements)
            where T : class
        {
            var queryable = elements.AsQueryable();
            var mockProducts = new Mock<IDbSet<T>>();
            mockProducts.Setup(m => m.Provider).Returns(queryable.Provider);
            mockProducts.Setup(m => m.Expression).Returns(queryable.Expression);
            mockProducts.Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockProducts.Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            return mockProducts;
        }
        [TestMethod]
        public void TestCountOfInsertedObject()
        {
            var asteroids = new[]
            {
                new Asteroid { Name = "Ceres", Profit=3.2, Value = 5.27 }
            };
            var mockAsteroidsDb = CreateMockedDbSet(asteroids);
            var mockAsteroidContext = new Mock<IAsteroidsContext>();
            mockAsteroidContext.Setup(asteroidContext => asteroidContext.Asteroids).Returns(mockAsteroidsDb.Object);
            // var mock = new DbService(mockAsteroidContext.Object);
            //var controller = new AsteroidsController(mock);
            Assert.AreEqual(asteroids.Count(), mockAsteroidContext.Object.Asteroids.Count());
            //Assert.AreEqual("Earth", mockAsteroidContext.Object.Asteroids.Single().Name);
        }
        [TestMethod]
        public void TestValidationOfName()
        {
            var asteroids = new Asteroid { Name = "Cere@" };
            var context = new ValidationContext(asteroids, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(asteroids, context, results, true);

            Assert.IsTrue(results.Any(vr => vr.MemberNames.Any(x => x == "Name")));
        }
        [TestMethod]
        public void TestCreateAsteroid()
        {
            var asteroid = new Asteroid { Name = "Pallas", Profit = 22, Value = 122 };
            var asteroidsContext = new AsteroidsContext();
            asteroidsContext.Database.ExecuteSqlCommand("truncate table [Asteroids]");
            var services = new DbService(asteroidsContext);
            var asteroidsController = new AsteroidsController(services);

            asteroidsController.Create(asteroid);

            Assert.AreEqual(asteroid.Name, asteroidsContext.Asteroids.Single().Name);
            //Assert.IsTrue(asteroidsContext.Asteroids.Any(x => x.Name == "Pallas"));
        }

        [TestMethod]
        public void TestEditAsteroid()
        {
            var asteroid = new Asteroid { Name = "Vesta" };
            var asteroidsContext = new AsteroidsContext();
            var services = new DbService(asteroidsContext);
            var asteroidsController = new AsteroidsController(services);
            var oldAsteroid = asteroidsContext.Asteroids.Single();
            oldAsteroid.Name = asteroid.Name;

            asteroidsController.Edit(oldAsteroid);

            Assert.AreEqual(asteroid.Name, asteroidsContext.Asteroids.Single().Name);
        }
        [TestMethod]
        public void TestDeleteAsteroid()
        {
            var asteroidsContext = new AsteroidsContext();
            var services = new DbService(asteroidsContext);
            var asteroidsController = new AsteroidsController(services);
            var asteroid = asteroidsContext.Asteroids.Single();

            asteroidsController.DeleteConfirmed(asteroid.ID);

            //Assert.AreEqual(asteroid.Name, asteroidsContext.Asteroids.Single().Name);
            Assert.IsFalse(asteroidsContext.Asteroids.Any());
        }

    }
}
