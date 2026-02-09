using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DriverCore.Models;
using DriverCore.Algorithms;

namespace DriverApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== DRIVER SELECTION SYSTEM ===");
            Console.WriteLine();
            
            // 1. Тестовые данные
            var drivers = CreateTestDrivers(10000);
            Console.WriteLine($"Created {drivers.Count} test drivers");
            
            var order = new Order(5000, 5000);
            Console.WriteLine($"Order at: ({order.X}, {order.Y})");
            Console.WriteLine();
            
            // 2. Тест 3 алгоритмов
            var algorithms = new (string Name, IDriverFinder Finder)[]
            {
                ("Simple", new SimpleFinder()),
                ("Bucket", new BucketFinder()),
                ("Grid", new GridFinder())
            };
            
            foreach (var algo in algorithms)
            {
                Console.WriteLine($"--- {algo.Name} Algorithm ---");
                
                var sw = Stopwatch.StartNew();
                var result = algo.Finder.FindNearest(order, drivers, 5);
                sw.Stop();
                
                Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
                
                for (int i = 0; i < Math.Min(3, result.Count); i++)
                {
                    var d = result[i];
                    Console.WriteLine($"  {i+1}. {d.Id} ({d.X}, {d.Y})");
                }
                Console.WriteLine();
            }
            
            // 3. Бенчмарк
            Console.WriteLine("=== BENCHMARK (100 iterations) ===");
            foreach (var algo in algorithms)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < 100; i++)
                {
                    algo.Finder.FindNearest(order, drivers, 5);
                }
                sw.Stop();
                Console.WriteLine($"{algo.Name}: {sw.ElapsedMilliseconds} ms");
            }
            
            Console.WriteLine();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
        
        static List<Driver> CreateTestDrivers(int count)
        {
            var drivers = new List<Driver>();
            var rnd = new Random(42);
            
            for (int i = 0; i < count; i++)
            {
                drivers.Add(new Driver(
                    $"D{i:00000}",
                    rnd.Next(0, 10000),
                    rnd.Next(0, 10000)
                ));
            }
            
            return drivers;
        }
    }
}