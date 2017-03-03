using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Selection
{
    public class SurvivorsSeletor : ISelector
    {
        public SurvivorsSeletor(AlgorithmParameters algorithmParameters)
        {
            NumberOfSurvivorsSolutionsToSelect = algorithmParameters.NumberOfSurvivorsSolutionsToSelect;
        }

        public IList<Solution> Select(IList<Solution> solutions)
        {
            return solutions.OrderByDescending(solution => solution.FitnessScore).Take(NumberOfSurvivorsSolutionsToSelect).ToList();
        }

        public int NumberOfSurvivorsSolutionsToSelect { get; set; }
    }
}
