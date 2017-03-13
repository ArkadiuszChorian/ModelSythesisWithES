using System;
using System.Collections.Generic;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Utils
{
    public static class Extensions
    {
        public static double[][] ToDoublesArray(this Point[] points)
        {
            var array = new double[points.Length][];

            for (var i = 0; i < points.Length; i++)
            {
                array[i] = points[i].Coordinates;
            }

            return array;
        }

        public static List<Constraint> GetConstraints(this Solution solution, ExperimentParameters experimentParameters)
        {
            var constraints = new List<Constraint>();
            var numberOfConstraintCoefficients = experimentParameters.NumberOfDimensions + 1;

            for (var i = 0; i < experimentParameters.NumberOfConstraints; i += numberOfConstraintCoefficients)
            {
                var constraintLimitingValue = solution.ObjectCoefficients[i + numberOfConstraintCoefficients - 1];
                var constraintCoefficients = new double[numberOfConstraintCoefficients - 1];

                Array.Copy(solution.ObjectCoefficients, i, constraintCoefficients, 0, numberOfConstraintCoefficients - 1);

                constraints.Add(new LinearConstraint(constraintCoefficients, constraintLimitingValue));
            }

            return constraints;
        }
    }
}
