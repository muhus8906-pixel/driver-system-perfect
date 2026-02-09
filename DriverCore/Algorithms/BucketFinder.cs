using System.Collections.Generic;
using System.Linq;
using DriverCore.Models;

namespace DriverCore.Algorithms
{
    public class BucketFinder : IDriverFinder
    {
        private int _bucketSize;
        
        public BucketFinder(int bucketSize = 100)
        {
            _bucketSize = bucketSize;
        }
        
        public List<Driver> FindNearest(Order order, List<Driver> drivers, int count)
        {
            var bucketX = order.X / _bucketSize;
            var bucketY = order.Y / _bucketSize;
            
            var inBucket = drivers
                .Where(d => d.X / _bucketSize == bucketX && d.Y / _bucketSize == bucketY)
                .ToList();
                
            if (inBucket.Count < count)
                inBucket = drivers;
            
            return inBucket
                .OrderBy(d => d.DistanceTo(order.X, order.Y))
                .Take(count)
                .ToList();
        }
    }
}