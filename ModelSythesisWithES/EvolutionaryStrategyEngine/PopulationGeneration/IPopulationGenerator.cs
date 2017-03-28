using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.PopulationGeneration
{
    public interface IPopulationGenerator
    {
        IList<Solution> GeneratePopulation(ExperimentParameters experimentParameters);
    }
}
