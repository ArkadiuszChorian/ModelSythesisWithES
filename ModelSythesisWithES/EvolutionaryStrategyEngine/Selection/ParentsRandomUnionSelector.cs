using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Selection
{
    public class ParentsRandomUnionSelector : ParentsRandomDistinctSelector
    {
        public ParentsRandomUnionSelector(ExperimentParameters experimentParameters) : base(experimentParameters)
        {
        }

        public override IList<Solution> Select(IList<Solution> solutions)
        {
            if (NumberOfSolutionsToSelect == solutions.Count)
            {
                return solutions.DeepCopyByExpressionTree();
            }

            var selectedSolutions = new List<Solution>(NumberOfSolutionsToSelect);

            for (var i = 0; i < NumberOfSolutionsToSelect; i++)
            {
                //TODO: Solutions are taken with repetition
                selectedSolutions[i] = solutions[MersenneTwister.Instance.Next(solutions.Count)];
            }

            return selectedSolutions.DeepCopyByExpressionTree();
        }    
    }
}
