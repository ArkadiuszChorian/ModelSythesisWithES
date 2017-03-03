using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class NStepsMutationStdDeviationsDiscreteRecombiner : IRecombiner<NStepsMutationSolution>
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
                child.StdDeviationsCoefficients[i] = parents[MersenneTwister.Instance.Next(parents.Count)].StdDeviationsCoefficients[i];
            }

            return child;
        }
    }
}
