using mars_explorer_service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace mars_explorer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            string line;

            while ((line = Console.ReadLine()) != null && line != string.Empty)
                lines.Add(line);

            if (lines.Count == 0 || lines.Count == 1)
            {
                Console.WriteLine("There is no line command to move a rover");
                return;
            }

            ServiceProvider serviceProvider = new ServiceCollection()
            .AddTransient<IExploreService, ExploreService>()
            .AddTransient<IEvaluator>(p => new InputEvaluator(lines))
                .BuildServiceProvider();

            IExploreService exploreService = serviceProvider.GetService<IExploreService>();

            try
            {
                foreach (Rover item in exploreService.Rovers)
                {
                    exploreService.Explore(item);

                    if (item.PointX < 0 || item.PointX > exploreService.HorizonX || item.PointY < 0 || item.PointY > exploreService.HorizonY)
                        throw new ArgumentException("Coordinates are out of rectangle surface with respect to given points.");

                    Console.WriteLine(string.Format("{0} {1} {2}"), item.PointX, item.PointY, item.Direction.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}

