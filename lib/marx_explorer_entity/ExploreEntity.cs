using System.Collections.Generic;

namespace mars_explorer_entity
{
    public class ExploreEntity : IExploreEntity
    {
        public ExploreEntity()
        {
            this.Rovers = new List<Rover>();
        }
        public int HorizonX { get; set; }
        public int HorizonY { get; set; }
        public List<Rover> Rovers { get; set; }
    }
}
