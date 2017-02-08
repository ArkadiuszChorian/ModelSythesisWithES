using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Selection
{
    public interface ISelector
    {
        IList<Solution> Select(IList<Solution> solutions);
    }
}
