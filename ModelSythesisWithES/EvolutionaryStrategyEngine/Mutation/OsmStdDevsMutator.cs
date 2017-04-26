using System;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class OsmStdDevsMutator : IMutator
    {
        public OsmStdDevsMutator(ExperimentParameters experimentParameters)
        {
            IndividualLearningRate = experimentParameters.IndividualLearningRate;
            StepThreshold = experimentParameters.StepThreshold;
        }

        public double IndividualLearningRate { get; set; }
        public double StepThreshold { get; set; }

        public Solution Mutate(Solution solution)
        {
            solution.OneStepStdDeviation *= Math.Exp(IndividualLearningRate * MersenneTwister.Instance.NextDoublePositive());
            solution.OneStepStdDeviation = solution.OneStepStdDeviation < StepThreshold ? StepThreshold : solution.OneStepStdDeviation;

            return solution; 
        }
    }
}
