using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class NStepsMutationObjectMutator : IMutator<NStepsMutationSolution>
    {
        public NStepsMutationSolution Mutate(NStepsMutationSolution solution)
        {
            var numberOfCoefficients = solution.ObjectCoefficients.Length;

            for (var i = 0; i < numberOfCoefficients; i++)
            {
                solution.ObjectCoefficients[i] += solution.StdDeviationsCoefficients[i] * MersenneTwister.Instance.NextDoublePositive();
            }

            return solution;
        }
    }
}
