using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.PopulationGeneration
{
    public class OsmPopulationRandomGenerator : IPopulationGenerator
    {
        public IList<Solution> GeneratePopulation(ExperimentParameters experimentParameters)
        {
            var population = new List<Solution>(experimentParameters.BasePopulationSize);

            for (var i = 0; i < experimentParameters.BasePopulationSize; i++)
            {
                population[i] = new Solution(experimentParameters);

                for (var j = 0; j < population[i].ObjectCoefficients.Length; j++)
                {
                    population[i].ObjectCoefficients[j] = MersenneTwister.Instance.NextDouble();
                    
                }
                population[i].OneStepStdDeviation = MersenneTwister.Instance.NextDoublePositive();
            }

            return population;
        }
    }
}
