using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class OneStepMutationStdDeviationsIntermediateRecombiner : IRecombiner<OneStepMutationSolution>
    {
        public OneStepMutationSolution Recombine(IList<OneStepMutationSolution> parents, OneStepMutationSolution child = null)
        {
            if (child == null)
            {
                child = new OneStepMutationSolution(parents.First().ObjectCoefficients.Length);
            }

            child.OneStepStdDeviation = parents.Sum(parent => parent.OneStepStdDeviation) / parents.Count;

            return child;
        }
    }
}
