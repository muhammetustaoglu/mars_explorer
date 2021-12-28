using mars_explorer_entity;
using System.Collections.Generic;

namespace mars_explorer_business
{
    public interface IEvaluator
    {
        public IExploreEntity Evaluate(List<string> inputLines);
    }
}
