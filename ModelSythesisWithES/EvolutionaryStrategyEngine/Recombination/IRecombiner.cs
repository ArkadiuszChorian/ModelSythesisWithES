using System.Collections.Generic;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public interface IRecombiner
    {
        Solution Recombine(IList<Solution> parents, Solution child = null);
    }
}
