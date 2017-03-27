using System.Collections.Generic;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.MutationSupervison
{
    public class OsmOneFifthRuleSupervisor : IMutationRuleSupervisor
    {
        private const double OneFifthRatio = 0.2;

        public int SuccesfulMutationsNumber { get; set; }
        public int MutationsNumber { get; set; }
        public int StdDeviationsScalingFactor { get; set; }

        public IList<Solution> EnsureRuleFullfillment(IList<Solution> solutions)
        {
            var succesfulMutationsRatio = (double)SuccesfulMutationsNumber / MutationsNumber;

            if (succesfulMutationsRatio > OneFifthRatio)
            {
                foreach (var solution in solutions)
                {
                    solution.OneStepStdDeviation /= StdDeviationsScalingFactor;
                }
            }

            if (succesfulMutationsRatio < OneFifthRatio)
            {
                foreach (var solution in solutions)
                {
                    solution.OneStepStdDeviation *= StdDeviationsScalingFactor;
                }
            }

            return solutions;
        }
    }
}
