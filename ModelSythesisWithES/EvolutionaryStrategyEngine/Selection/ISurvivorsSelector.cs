using System.Collections.Generic;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Selection
{
    public interface ISurvivorsSelector : ISelector
    {
        IList<Solution> MakeUnionOrDistinct(IList<Solution> newSolutions, IList<Solution> oldSolutions);
    }
}
