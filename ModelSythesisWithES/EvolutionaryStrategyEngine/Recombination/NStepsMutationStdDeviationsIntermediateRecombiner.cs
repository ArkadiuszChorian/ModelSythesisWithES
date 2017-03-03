using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class NStepsMutationStdDeviationsIntermediateRecombiner : IRecombiner<NStepsMutationSolution>
    {
        public NStepsMutationSolution Recombine(IList<NStepsMutationSolution> parents, NStepsMutationSolution child = null)
        {
            var vectorSize = parents.First().ObjectCoefficients.Length;

            if (child == null)
            {
                child = new NStepsMutationSolution(vectorSize);
            }

            for (var i = 0; i < vectorSize; i++)
            {
                child.StdDeviationsCoefficients[i] = parents.Sum(parent => parent.StdDeviationsCoefficients[i]) / parents.Count;
            }

            return child;
        }
    }
}
