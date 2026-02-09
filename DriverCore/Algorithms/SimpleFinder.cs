using System.Collections.Generic;
using System.Linq;
using DriverCore.Models;

namespace DriverCore.Algorithms
{
    public class SimpleFinder : IDriverFinder
    {
        public List<Driver> FindNearest(Order order, List<Driver> drivers, int count)
        {
            return drivers
                .OrderBy(d => d.DistanceTo(order.X, order.Y))
                .Take(count)
                .ToList();
        }
    }
}
