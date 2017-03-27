using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Selection
{
    public class SurvivorsDistinctSeletor : ISelector
    {
        public SurvivorsDistinctSeletor(ExperimentParameters experimentParameters)
        {
            NumberOfSolutionsToSelect = (int)experimentParameters.PartOfSurvivorsSolutionsToSelect * experimentParameters.PopulationSize;
        }

        public IList<Solution> Select(IList<Solution> solutions, IList<Solution> oldSolutions = null)
        {
            return solutions.OrderByDescending(solution => solution.FitnessScore).Take(NumberOfSolutionsToSelect).ToList();
        }

        public int NumberOfSolutionsToSelect { get; set; }
    }
}
