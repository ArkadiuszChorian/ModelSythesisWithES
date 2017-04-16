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

        public static double[][] Get2DLineFromConstraint(this Constraint constraint, int minValue, int maxValue)
        {
            var points = new double[maxValue - minValue][];
            var index = 0;

            for (var i = minValue; i < maxValue; i++)
            {
                points[index] = new[] { i, (constraint.LimitingValue / constraint.TermsCoefficients[1]) - ((constraint.TermsCoefficients[0] / constraint.TermsCoefficients[1]) * i) };

                index++;
            }

            return points;
        }

        public static double[][] Get2DLinesFromConstraints(this List<Constraint> constraints, int minValue, int maxValue)
        {
            var points = new List<double[]>();

            foreach (var constraint in constraints)
            {
                var singleConstraintPoints = constraint.Get2DLineFromConstraint(minValue, maxValue);

                points.AddRange(singleConstraintPoints);
            }

            return points.ToArray();
        }
    }
}
