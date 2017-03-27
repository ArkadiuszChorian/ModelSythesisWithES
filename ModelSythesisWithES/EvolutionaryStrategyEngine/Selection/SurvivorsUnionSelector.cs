using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Selection
{
    public class SurvivorsUnionSelector : ISelector
    {
        public SurvivorsUnionSelector(ExperimentParameters experimentParameters)
        {
            NumberOfSolutionsToSelect = (int)experimentParameters.PartOfSurvivorsSolutionsToSelect * experimentParameters.PopulationSize;
        }

        public IList<Solution> Select(IList<Solution> solutions, IList<Solution> oldSolutions)
        {      
            return solutions.Concat(oldSolutions).OrderByDescending(solution => solution.FitnessScore).Take(NumberOfSolutionsToSelect).ToList();
        }

        public int NumberOfSolutionsToSelect { get; set; }
    }
}
