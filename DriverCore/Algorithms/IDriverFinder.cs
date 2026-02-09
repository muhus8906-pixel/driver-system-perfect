using System.Collections.Generic;
using DriverCore.Models;

namespace DriverCore.Algorithms
{
    public interface IDriverFinder
    {
        List<Driver> FindNearest(Order order, List<Driver> drivers, int count);
    }
}