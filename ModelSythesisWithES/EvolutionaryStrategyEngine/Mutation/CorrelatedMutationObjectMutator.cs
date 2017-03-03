using System;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class CorrelatedMutationObjectMutator : IMutator<CorrelatedMutationSolution>
    {
        public CorrelatedMutationSolution Mutate(CorrelatedMutationSolution solution)
        {
            throw new NotImplementedException();
            //var lenght = solution.ObjectCoefficients.Length;

            //var covarianceMatrix = new double[lenght, lenght];

            //for (var i = 0; i < lenght; i++)
            //{
            //    for (var j = 0; j < lenght; j++)
            //    {
            //        if (i == j)
            //        {
            //            covarianceMatrix[i, j] = Math.Pow(solution.StdDeviationsCoefficients[i], 2);
            //        }
            //        else
            //        {
            //            covarianceMatrix[i, j] = 0.5 * (Math.Pow(solution.StdDeviationsCoefficients[i], 2) - Math.Pow(solution.StdDeviationsCoefficients[j], 2)) * Math.Tan();
            //        }
            //    }
            //}
        }
    }
}
