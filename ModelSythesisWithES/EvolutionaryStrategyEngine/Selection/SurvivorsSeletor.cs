using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Selection
{
    public class SurvivorsSeletor : ISelector
    {
        public SurvivorsSeletor(ExperimentParameters experimentParameters)
        {
            NumberOfSolutionsToSelect = (int)experimentParameters.PartOfSurvivorsSolutionsToSelect * experimentParameters.PopulationSize;
        }

        public IList<Solution> Select(IList<Solution> solutions)
        {
            return solutions.OrderByDescending(solution => solution.FitnessScore).Take(NumberOfSolutionsToSelect).ToList();
        }

        public int NumberOfSolutionsToSelect { get; set; }
    }
}
