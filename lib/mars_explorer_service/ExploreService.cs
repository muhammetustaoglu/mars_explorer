using mars_explorer_business;
using System.Collections.Generic;

namespace mars_explorer_service
{
    public class ExploreService : IExploreService
    {
        protected IExplorer Explorer { get; set; }
        public ExploreService(IExplorer explorer)
        {
            this.Explorer = explorer;
        }

        public List<string> Explore(List<string> lines)
        {
            return this.Explorer.Explore(lines);
        }
    }
}
