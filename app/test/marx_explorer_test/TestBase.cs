using mars_explorer_container;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace marx_explorer_test
{
    public abstract class TestBase
    {
        protected IServiceProvider ServiceProvider { get; set; }
        protected TestBase()
        {
            this.ServiceProvider = (ServiceProvider)Bootstrapper.Bootstrap();
        }
    }
}
