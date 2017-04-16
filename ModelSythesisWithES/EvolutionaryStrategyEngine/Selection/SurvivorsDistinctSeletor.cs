using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Selection
{
    public class SurvivorsDistinctSeletor : ISurvivorsSelector
    {
        public SurvivorsDistinctSeletor(ExperimentParameters experimentParameters)
        {
            NumberOfSolutionsToSelect = experimentParameters.PopulationSize;//(int)(experimentParameters.PartOfSurvivorsSolutionsToSelect * experimentParameters.PopulationSize);
        }

        public int NumberOfSolutionsToSelect { get; set; }

        public IList<Solution> Select(IList<Solution> solutions)
        {
            return solutions.OrderByDescending(solution => solution.FitnessScore).Take(NumberOfSolutionsToSelect).ToList();
        }

        public virtual IList<Solution> MakeUnionOrDistinct(IList<Solution> newSolutions, IList<Solution> oldSolutions)
        {
            return newSolutions;
        }

    }
}
