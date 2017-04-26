using System.Collections.Generic;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.MutationSupervison
{
    public interface IMutationRuleSupervisor
    {
        void RemeberSolutionParameters(Solution solution);
        void IncrementMutationsNumber();
        void IncrementGenerationNumber();
        void CompareNewSolutionParameters(Solution solution);
        IList<Solution> EnsureRuleFullfillment(IList<Solution> solutions);
    }
}