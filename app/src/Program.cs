using mars_explorer_container;
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

            ServiceProvider serviceProvider = (ServiceProvider)Bootstrapper.Bootstrap();

            IExploreService exploreService = serviceProvider.GetService<IExploreService>();

            try
            {
                List<string> response = exploreService.Explore(lines);

                foreach (string item in response)
                    Console.WriteLine(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}

