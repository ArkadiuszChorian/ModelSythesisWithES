using System;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class RotationsMutator : IMutator<CorrelatedMutationSolution>
    {
        public double RotationAngle { get; set; }

        public CorrelatedMutationSolution Mutate(CorrelatedMutationSolution solution)
        {
            var numberOfCoefficients = solution.RotationsCoefficients.Length;

            for (var j = 0; j < numberOfCoefficients; j++)
            {
                solution.RotationsCoefficients[j] += RotationAngle * MersenneTwister.Instance.NextDoublePositive();

                if (Math.Abs(solution.RotationsCoefficients[j]) > Math.PI)
                {
                    solution.RotationsCoefficients[j] -= 2 * Math.PI * Math.Sign(solution.RotationsCoefficients[j]);
                }
            }

            return solution;
        }
    }
}
