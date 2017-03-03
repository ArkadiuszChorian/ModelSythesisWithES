using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class OneStepMutationObjectMutator : IMutator<OneStepMutationSolution>
    {
        public OneStepMutationSolution Mutate(OneStepMutationSolution solution)
        {
            var numberOfCoefficients = solution.ObjectCoefficients.Length;

            for (var i = 0; i < numberOfCoefficients; i++)
            {
                solution.ObjectCoefficients[i] += solution.OneStepStdDeviation * MersenneTwister.Instance.NextDoublePositive();
            }

            return solution;
        }
    }
}
