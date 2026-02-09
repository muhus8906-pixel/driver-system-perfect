using System;

namespace DriverCore.Models
{
    public class Driver
    {
        public string Id { get; }
        public int X { get; }
        public int Y { get; }
        
        public Driver(string id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
        
        public double DistanceTo(int targetX, int targetY)
        {
            int dx = X - targetX;
            int dy = Y - targetY;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}