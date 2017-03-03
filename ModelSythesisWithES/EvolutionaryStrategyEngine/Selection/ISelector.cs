using System.Collections.Generic;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Selection
{
    public interface ISelector
    {
        IList<Solution> Select(IList<Solution> solutions);
    }
}
