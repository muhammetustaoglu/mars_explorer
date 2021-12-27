using System.Collections.Generic;

namespace mars_explorer_service
{
    public interface IEvaluator
    {
        public void Evaluate(int horizonX, int horizonY, List<Rover> commands);
    }
}
