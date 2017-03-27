using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class OsmStdDevsIntermediateRecombiner : IRecombiner
    {
        public Solution Recombine(IList<Solution> parents, Solution child = null)
        {
            if (child == null)
            {
                child = new Solution(parents.First());
            }

            child.OneStepStdDeviation = parents.Sum(parent => parent.OneStepStdDeviation) / parents.Count;

            return child;
        }
    }
}
