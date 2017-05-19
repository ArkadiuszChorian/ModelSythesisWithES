﻿using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class OsmStdDevsDiscreteRecombiner : IRecombiner
    {
        private readonly MersenneTwister _randomGenerator;

        public OsmStdDevsDiscreteRecombiner(ExperimentParameters experimentParameters)
        {
            _randomGenerator = MersenneTwister.Instance;
            ExperimentParameters = experimentParameters;
        }

        public ExperimentParameters ExperimentParameters { get; set; }

        public Solution Recombine(Solution[] parents, Solution child = null)
        {
            if (child == null)
                child = new Solution(ExperimentParameters);

            child.OneStepStdDeviation = parents[_randomGenerator.Next(parents.Length)].OneStepStdDeviation;

            return child;
        }
    }
}
