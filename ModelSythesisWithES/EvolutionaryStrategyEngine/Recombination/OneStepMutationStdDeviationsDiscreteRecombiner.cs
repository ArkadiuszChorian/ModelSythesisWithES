using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class OneStepMutationStdDeviationsDiscreteRecombiner : IRecombiner<OneStepMutationSolution>
    {
        public OneStepMutationSolution Recombine(IList<OneStepMutationSolution> parents, OneStepMutationSolution child = null)
        {
            if (child == null)
            {
                child = new OneStepMutationSolution(parents.First().ObjectCoefficients.Length);
            }

            child.OneStepStdDeviation = parents[MersenneTwister.Instance.Next(parents.Count)].OneStepStdDeviation;

            return child;
        }
    }
}
