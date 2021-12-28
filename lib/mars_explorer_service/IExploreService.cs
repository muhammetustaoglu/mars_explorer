using mars_explorer_entity;
using System.Collections.Generic;

namespace mars_explorer_service
{
    public interface IExploreService
    {
        List<string> Explore(List<string> lines);
    }
}
