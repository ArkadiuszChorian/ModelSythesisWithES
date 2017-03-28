using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.PopulationGeneration
{
    public class CmPopulationRandomGenerator : IPopulationGenerator
    {
        public IList<Solution> GeneratePopulation(ExperimentParameters experimentParameters)
        {
            var population = new List<Solution>(experimentParameters.PopulationSize);

            for (var i = 0; i < experimentParameters.PopulationSize; i++)
            {
                population[i] = new Solution(experimentParameters);

                for (var j = 0; j < population[i].ObjectCoefficients.Length; j++)
                {
                    population[i].ObjectCoefficients[j] = MersenneTwister.Instance.NextDouble();
                    population[i].StdDeviationsCoefficients[j] = MersenneTwister.Instance.NextDoublePositive();                  
                }

                for (var j = 0; j < population[i].RotationsCoefficients.Length; j++)
                {
                    for (var k = j + 1; k < population[i].RotationsCoefficients.Length; k++)
                    {
                        var randomValue = MersenneTwister.Instance.NextDoublePositive();

                        population[i].RotationsCoefficients[j][k] = randomValue;
                        population[i].RotationsCoefficients[k][j] = randomValue;                      
                    }
                }
            }

            return population;
        }
    }
}
