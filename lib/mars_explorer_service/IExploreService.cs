using System.Collections.Generic;

namespace mars_explorer_service
{
    public interface IExploreService
    {
        public int HorizonX { get; set; }
        public int HorizonY { get; set; }
        public List<Rover> Rovers { get; set; }
        void Explore(Rover rover);
    }
}
