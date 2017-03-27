using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class ObjectIntermediateRecombiner : IRecombiner
    {
        public Solution Recombine(IList<Solution> parents, Solution child = null)
        {
            var vectorSize = parents.First().ObjectCoefficients.Length;

            if (child == null)
            {
                child = new Solution(parents.First());
            }

            for (var i = 0; i < vectorSize; i++)
            {
                child.ObjectCoefficients[i] = parents.Sum(parent => parent.ObjectCoefficients[i]) / parents.Count;
            }

            return child;
        }
    }
}
