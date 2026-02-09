using NUnit.Framework;
using System.Collections.Generic;
using DriverCore.Models;
using DriverCore.Algorithms;

namespace DriverTests
{
    [TestFixture]
    public class DriverTests
    {
        [Test]
        public void SimpleFinder_FindsNearest()
        {
            var drivers = new List<Driver>
            {
                new Driver("D1", 10, 10),
                new Driver("D2", 20, 20),
                new Driver("D3", 30, 30)
            };
            
            var order = new Order(0, 0);
            var finder = new SimpleFinder();
            
            var result = finder.FindNearest(order, drivers, 2);
            
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("D1", result[0].Id);
        }
        
        [Test]
        public void AllFinders_Work()
        {
            var drivers = new List<Driver>();
            var rnd = new System.Random();
            
            for (int i = 0; i < 100; i++)
            {
                drivers.Add(new Driver($"D{i}", rnd.Next(0, 1000), rnd.Next(0, 1000)));
            }
            
            var order = new Order(500, 500);
            
            var finders = new IDriverFinder[]
            {
                new SimpleFinder(),
                new BucketFinder(),
                new GridFinder()
            };
            
            foreach (var finder in finders)
            {
                var result = finder.FindNearest(order, drivers, 5);
                Assert.AreEqual(5, result.Count);
            }
        }
    }
}