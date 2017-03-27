using System;
using Accord.Statistics.Distributions.Multivariate;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class CmObjectMutator : IMutator
    {
        private readonly double[] _zeroMeans;

        public CmObjectMutator(ExperimentParameters experimentParameters)
        {
            _zeroMeans = new double[experimentParameters.NumberOfDimensions];
        }

        public Solution Mutate(Solution solution)
        {
            var vectorSize = solution.ObjectCoefficients.Length;
            var covarianceMatrix = new double[vectorSize, vectorSize];

            for (var i = 0; i < vectorSize; i++)
            {
                for (var j = 0; j < vectorSize; j++)
                {
                    if (i == j)
                    {
                        covarianceMatrix[i, j] = Math.Pow(solution.StdDeviationsCoefficients[i], 2);
                    }
                    else
                    {
                        covarianceMatrix[i, j] = (Math.Pow(solution.StdDeviationsCoefficients[i], 2) - Math.Pow(solution.StdDeviationsCoefficients[j], 2)) * Math.Tan(2 * solution.RotationsCoefficients[i][j]) / 2;
                    }
                }
            }

            var mutationVector = new MultivariateNormalDistribution(_zeroMeans, covarianceMatrix).Generate();

            for (var i = 0; i < solution.ObjectCoefficients.Length; i++)
            {
                solution.ObjectCoefficients[i] += mutationVector[i];
            }

            return solution;
        }
    }
}
