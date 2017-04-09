using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Selection
{
    public class ParentsRandomDistinctSelector : ISelector
    {
        public ParentsRandomDistinctSelector(ExperimentParameters experimentParameters)
        {
            NumberOfSolutionsToSelect = (int)experimentParameters.PartOfParentsSolutionsToSelect * experimentParameters.PopulationSize;
        }

        public int NumberOfSolutionsToSelect { get; set; }

        public virtual IList<Solution> Select(IList<Solution> solutions)
        {
            if (NumberOfSolutionsToSelect == solutions.Count)
            {
                return solutions;
            }

            var selectedSolutions = new List<Solution>(NumberOfSolutionsToSelect);

            for (var i = 0; i < NumberOfSolutionsToSelect; i++)
            {
                //TODO: Solutions are taken with repetition
                selectedSolutions.Add(solutions[MersenneTwister.Instance.Next(solutions.Count)]);
            }

            return selectedSolutions;
        }    
    }
}
