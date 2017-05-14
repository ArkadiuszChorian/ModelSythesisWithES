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
            var population = new List<Solution>(experimentParameters.BasePopulationSize);

            for (var i = 0; i < experimentParameters.BasePopulationSize; i++)
            {
                population.Add(new Solution(experimentParameters));

                for (var j = 0; j < population[i].ObjectCoefficients.Length; j++)
                {
                    population[i].ObjectCoefficients[j] = MersenneTwister.Instance.NextDouble();
                    population[i].StdDeviationsCoefficients[j] = MersenneTwister.Instance.NextDoublePositive();                  
                }

                var size = population[i].RotationsCoefficients.Length;

                for (var j = 0; j < size; j++)
                {
                    var randomValue = MersenneTwister.Instance.NextDoublePositive();
                    
                    population[i].RotationsCoefficients[j] = randomValue;
                }

                //if (size > 1)
                //{
                //    for (var j = 0; j < size; j++)
                //    {
                //        for (var k = j + 1; k < size; k++)
                //        {
                //            var randomValue = MersenneTwister.Instance.NextDoublePositive();

                //            //population[i].RotationsCoefficients[j][k] = randomValue;
                //            //population[i].RotationsCoefficients[k][j] = randomValue;
                //            population[i].RotationsCoefficients[]
                //        }
                //    }
                //}
                //else
                //{
                //    //population[i].RotationsCoefficients[0][0] = MersenneTwister.Instance.NextDoublePositive();
                //    population[i].RotationsCoefficients[0] = MersenneTwister.Instance.NextDoublePositive();
                //}               
            }

            return population;
        }
    }
}
