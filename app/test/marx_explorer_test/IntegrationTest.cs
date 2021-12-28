using mars_explorer_service;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace marx_explorer_test
{
    public class IntegrationTest : TestBase
    {
        public IntegrationTest() : base()
        {

        }
        [Fact]
        public void Is_Explorer_Working_Correct()
        {
            IExploreService exploreService = this.ServiceProvider.GetService<IExploreService>();
            List<string> lines = new List<string>()
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            List<string> response = new();
            response = exploreService.Explore(lines);
            Assert.Equal(2, response.Count);
            Assert.Equal("1 3 N", response[0]);
            Assert.Equal("5 1 E", response[1]);
        }
    }
}
