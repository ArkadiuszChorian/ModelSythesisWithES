﻿using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class RotationsIntermediateRecombiner : IRecombiner
    {
        public RotationsIntermediateRecombiner(ExperimentParameters experimentParameters)
        {
            ExperimentParameters = experimentParameters;
        }

        public ExperimentParameters ExperimentParameters { get; set; }

        public Solution Recombine(Solution[] parents, Solution child = null)
        {
            var vectorSize = parents[0].RotationsCoefficients.Length;
            var numberOfParents = parents.Length;

            if (child == null)
                child = new Solution(ExperimentParameters);

            for (var i = 0; i < vectorSize; i++)
            {
                var sum = 0.0;

                for (var j = 0; j < numberOfParents; j++)
                    sum += parents[j].RotationsCoefficients[i];

                child.RotationsCoefficients[i] = sum / numberOfParents;
            }

            return child;
        }
    }
}
