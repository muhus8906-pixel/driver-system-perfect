using System.Collections.Generic;
using System.Linq;
using DriverCore.Models;

namespace DriverCore.Algorithms
{
    public class GridFinder : IDriverFinder
    {
        public List<Driver> FindNearest(Order order, List<Driver> drivers, int count)
        {
            var nearby = drivers
                .Where(d => 
                    d.X >= order.X - 50 && d.X <= order.X + 50 &&
                    d.Y >= order.Y - 50 && d.Y <= order.Y + 50)
                .ToList();
                
            if (nearby.Count < count)
                nearby = drivers;
            
            return nearby
                .OrderBy(d => d.DistanceTo(order.X, order.Y))
                .Take(count)
                .ToList();
        }
    }
}