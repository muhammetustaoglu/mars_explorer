using mars_explorer_business;
using mars_explorer_entity;
using mars_explorer_service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace mars_explorer_container
{
    public class Bootstrapper
    {
        public static IServiceProvider Bootstrap()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
           .AddTransient<IExploreService, ExploreService>()
           .AddTransient<IEvaluator, InputEvaluator>()
           .AddTransient<IExplorer, Explorer>()
           .AddTransient<IExploreEntity, ExploreEntity>()
           .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
