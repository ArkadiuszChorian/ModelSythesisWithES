using System;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class RotationsMutator : IMutator
    {
        public double RotationAngle { get; set; }

        public Solution Mutate(Solution solution)
        {
            var vectorSize = solution.RotationsCoefficients.Length;

            for (var i = 0; i < vectorSize; i++)
            {
                for (var j = i + 1; j < vectorSize; j++)
                {
                    var mutationValue = RotationAngle * MersenneTwister.Instance.NextDoublePositive();

                    solution.RotationsCoefficients[i][j] += mutationValue;
                    solution.RotationsCoefficients[j][i] += mutationValue;

                    if (Math.Abs(solution.RotationsCoefficients[i][j]) > Math.PI)
                    {
                        var reduction = 2 * Math.PI * Math.Sign(solution.RotationsCoefficients[i][j]);

                        solution.RotationsCoefficients[i][j] -= reduction;
                        solution.RotationsCoefficients[j][i] -= reduction;
                    }
                }
            }

            return solution;
        }
    }
}
