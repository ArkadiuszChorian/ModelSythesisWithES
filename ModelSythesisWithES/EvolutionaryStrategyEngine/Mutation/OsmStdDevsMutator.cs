﻿using System;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class OsmStdDevsMutator : IMutator
    {
        private readonly MersenneTwister _randomGenerator;

        public OsmStdDevsMutator(ExperimentParameters experimentParameters)
        {
            IndividualLearningRate = experimentParameters.IndividualLearningRate;
            StepThreshold = experimentParameters.StepThreshold;
            _randomGenerator = MersenneTwister.Instance;
        }

        public double IndividualLearningRate { get; set; }
        public double StepThreshold { get; set; }

        public Solution Mutate(Solution solution)
        {
            solution.OneStepStdDeviation *= Math.Exp(IndividualLearningRate * _randomGenerator.NextDoublePositive());
            solution.OneStepStdDeviation = solution.OneStepStdDeviation < StepThreshold ? StepThreshold : solution.OneStepStdDeviation;

            return solution; 
        }
    }
}
