using System.Collections.Generic;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public interface IRecombiner<T> where T : Solution
    {
        T Recombine(IList<T> parents, T child = null);
    }
}
