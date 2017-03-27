using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class OsmStdDevsDiscreteRecombiner : IRecombiner
    {
        public Solution Recombine(IList<Solution> parents, Solution child = null)
        {
            if (child == null)
            {
                child = new Solution(parents.First());
            }

            child.OneStepStdDeviation = parents[MersenneTwister.Instance.Next(parents.Count)].OneStepStdDeviation;

            return child;
        }
    }
}
