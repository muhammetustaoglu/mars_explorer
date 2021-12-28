using System.Collections.Generic;

namespace mars_explorer_entity
{
    public interface IExploreEntity
    {
        public int HorizonX { get; set; }
        public int HorizonY { get; set; }
        public List<Rover> Rovers { get; set; }
    }
}