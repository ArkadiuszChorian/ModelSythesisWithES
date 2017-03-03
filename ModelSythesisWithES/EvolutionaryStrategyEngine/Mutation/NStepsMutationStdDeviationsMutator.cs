using System;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class NStepsMutationStdDeviationsMutator : IMutator<NStepsMutationSolution>
    {
        public double GlobalLearningRate { get; set; }
        public double IndividualLearningRate { get; set; }
        public double StepThreshold { get; set; }

        public NStepsMutationSolution Mutate(NStepsMutationSolution solution)
        {
            var numberOfCoefficients = solution.StdDeviationsCoefficients.Length;

            for (var j = 0; j < numberOfCoefficients; j++)
            {
                solution.StdDeviationsCoefficients[j] *= Math.Exp(IndividualLearningRate * MersenneTwister.Instance.NextDoublePositive() + GlobalLearningRate * MersenneTwister.Instance.NextDoublePositive());
                solution.StdDeviationsCoefficients[j] = solution.StdDeviationsCoefficients[j] < StepThreshold ? StepThreshold : solution.StdDeviationsCoefficients[j];
            }

            return solution;
        }
    }
}
