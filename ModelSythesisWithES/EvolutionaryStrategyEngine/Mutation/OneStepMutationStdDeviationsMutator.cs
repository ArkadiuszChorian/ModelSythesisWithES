using System;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class OneStepMutationStdDeviationsMutator : IMutator<OneStepMutationSolution>
    {
        public double IndividualLearningRate { get; set; }
        public double StepThreshold { get; set; }

        public OneStepMutationSolution Mutate(OneStepMutationSolution solution)
        {
            solution.OneStepStdDeviation *= Math.Exp(IndividualLearningRate * MersenneTwister.Instance.NextDoublePositive());
            solution.OneStepStdDeviation = solution.OneStepStdDeviation < StepThreshold ? StepThreshold : solution.OneStepStdDeviation;

            return solution; 

        }
    }
}
