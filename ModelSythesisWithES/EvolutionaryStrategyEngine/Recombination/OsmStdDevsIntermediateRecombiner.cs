﻿using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class OsmStdDevsIntermediateRecombiner : IRecombiner
    {
        public OsmStdDevsIntermediateRecombiner(ExperimentParameters experimentParameters)
        {
            ExperimentParameters = experimentParameters;
        }

        public ExperimentParameters ExperimentParameters { get; set; }

        public Solution Recombine(Solution[] parents, Solution child = null)
        {
            var numberOfParents = parents.Length;

            if (child == null)
                child = new Solution(ExperimentParameters);

            var sum = 0.0;

            for (var j = 0; j < numberOfParents; j++)
                sum += parents[j].OneStepStdDeviation;

            child.OneStepStdDeviation = sum / numberOfParents;           

            return child;
        }
    }
}
