using System.Collections.Generic;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.MutationSupervison
{
    public interface IMutationRuleSupervisor<T> where T : Solution
    {
        IList<T> EnsureRuleFullfillment(IList<T> solutions);
    }
}