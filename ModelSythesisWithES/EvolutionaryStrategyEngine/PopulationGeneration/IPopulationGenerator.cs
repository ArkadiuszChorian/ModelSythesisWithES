using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.PopulationGeneration
{
    public interface IPopulationGenerator
    {
        Solution[] GeneratePopulation(ExperimentParameters experimentParameters);
    }
}
