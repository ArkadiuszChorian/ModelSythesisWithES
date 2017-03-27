using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Selection
{
    public class RandomParentsSelector : ISelector
    {
        public RandomParentsSelector(ExperimentParameters experimentParameters)
        {
            NumberOfSolutionsToSelect = (int)experimentParameters.PartOfParentsSolutionsToSelect * experimentParameters.PopulationSize;
        }

        public IList<Solution> Select(IList<Solution> solutions, IList<Solution> oldSolutions = null)
        {
            if (NumberOfSolutionsToSelect == solutions.Count)
            {
                return solutions;
            }

            var selectedSolutions = new List<Solution>(NumberOfSolutionsToSelect);

            for (var i = 0; i < NumberOfSolutionsToSelect; i++)
            {
                //TODO: Solutions are taken with repetition
                selectedSolutions[i] = solutions[MersenneTwister.Instance.Next(solutions.Count)];
            }

            return selectedSolutions;
        }

        public int NumberOfSolutionsToSelect { get; set; }
    }
}
