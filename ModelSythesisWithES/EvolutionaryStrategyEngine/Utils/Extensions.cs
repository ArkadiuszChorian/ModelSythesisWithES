using System;
using EvolutionaryStrategyEngine.Benchmarks;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.PointsGeneration;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Utils
{
    public static class Extensions
    {
        public static Constraint[] GetConstraints(this Solution solution, ExperimentParameters experimentParameters)
        {
            var numberOfConstraintCoefficients = experimentParameters.NumberOfDimensions + 1;
            var numberOfConstraints = experimentParameters.NumberOfConstraints;
            var limiter = numberOfConstraintCoefficients * numberOfConstraints;
            var constraints = new Constraint[numberOfConstraints];            
            var j = 0;

            for (var i = 0; i < limiter; i += numberOfConstraintCoefficients)
            {
                var constraintLimitingValue = solution.ObjectCoefficients[i + numberOfConstraintCoefficients - 1];
                var constraintCoefficients = new double[numberOfConstraintCoefficients - 1];

                Array.Copy(solution.ObjectCoefficients, i, constraintCoefficients, 0, numberOfConstraintCoefficients - 1);
                
                constraints[j++] = new LinearConstraint(constraintCoefficients, constraintLimitingValue);
            }

            return constraints;
        }
    }
}
