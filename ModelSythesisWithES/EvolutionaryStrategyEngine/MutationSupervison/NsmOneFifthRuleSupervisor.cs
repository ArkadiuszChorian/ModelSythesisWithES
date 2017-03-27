using System.Collections.Generic;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.MutationSupervison
{
    public class NsmOneFifthRuleSupervisor : IMutationRuleSupervisor
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
                    var stdDeviationsCoefficientsVectorSize = solution.StdDeviationsCoefficients.Length;

                    for (var i = 0; i < stdDeviationsCoefficientsVectorSize; i++)
                    {
                        solution.StdDeviationsCoefficients[i] /= StdDeviationsScalingFactor;
                    }
                }
            }

            if (succesfulMutationsRatio < OneFifthRatio)
            {
                foreach (var solution in solutions)
                {
                    var stdDeviationsCoefficientsVectorSize = solution.StdDeviationsCoefficients.Length;

                    for (var i = 0; i < stdDeviationsCoefficientsVectorSize; i++)
                    {
                        solution.StdDeviationsCoefficients[i] *= StdDeviationsScalingFactor;
                    }
                }
            }

            return solutions;
        }
    }
}
