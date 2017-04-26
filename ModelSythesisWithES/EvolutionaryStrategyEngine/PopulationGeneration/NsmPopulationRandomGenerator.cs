using System;
using System.Collections.Generic;
using System.Diagnostics;
using Accord.Diagnostics;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;
using Debug = System.Diagnostics.Debug;

namespace EvolutionaryStrategyEngine.PopulationGeneration
{
    public class NsmPopulationRandomGenerator : IPopulationGenerator
    {
        public IList<Solution> GeneratePopulation(ExperimentParameters experimentParameters)
        {
            var population = new List<Solution>(experimentParameters.BasePopulationSize);

            for (var i = 0; i < experimentParameters.BasePopulationSize; i++)
            {
                population.Add(new Solution(experimentParameters));

                for (var j = 0; j < population[i].ObjectCoefficients.Length; j++)
                {
                    population[i].ObjectCoefficients[j] = MersenneTwister.Instance.NextDouble();
                    population[i].StdDeviationsCoefficients[j] = MersenneTwister.Instance.NextDoublePositive();
                    //population[i].ObjectCoefficients[j] = MersenneTwister.Instance.NextDouble(-10.0, 10.0);
                    //population[i].StdDeviationsCoefficients[j] = MersenneTwister.Instance.NextDouble(-10.0, 10.0);
                    //if (Math.Abs(population[i].StdDeviationsCoefficients[j]) < 0.1)
                    //{
                    //    Debugger.Break();
                    //}
                }
            }

            return population;
        }
    }
}
