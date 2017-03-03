using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class RotationsIntermediateRecombiner : IRecombiner<CorrelatedMutationSolution>
    {
        public CorrelatedMutationSolution Recombine(IList<CorrelatedMutationSolution> parents, CorrelatedMutationSolution child = null)
        {
            var vectorSize = parents.First().ObjectCoefficients.Length;

            if (child == null)
            {
                child = new CorrelatedMutationSolution(vectorSize);
            }

            for (var i = 0; i < vectorSize; i++)
            {
                child.RotationsCoefficients[i] = parents.Sum(parent => parent.RotationsCoefficients[i]) / parents.Count;
            }

            return child;
        }
    }
}
