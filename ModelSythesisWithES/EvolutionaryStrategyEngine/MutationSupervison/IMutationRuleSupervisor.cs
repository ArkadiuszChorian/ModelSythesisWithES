using System.Collections.Generic;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.MutationSupervison
{
    public interface IMutationRuleSupervisor
    {
        IList<Solution> EnsureRuleFullfillment(IList<Solution> solutions);
    }
}