using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Selection
{
    public class SurvivorsUnionSelector : SurvivorsDistinctSeletor
    {
        public SurvivorsUnionSelector(ExperimentParameters experimentParameters) : base(experimentParameters)
        {
        }

        public override IList<Solution> MakeUnionOrDistinct(IList<Solution> newSolutions, IList<Solution> oldSolutions)
        {
            return oldSolutions.Concat(newSolutions).ToList();
        }
    }
}
