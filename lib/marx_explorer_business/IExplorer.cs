using mars_explorer_entity;
using System.Collections.Generic;

namespace mars_explorer_business
{
    public interface IExplorer
    {
        public List<string> Explore(List<string> lines);
    }
}
