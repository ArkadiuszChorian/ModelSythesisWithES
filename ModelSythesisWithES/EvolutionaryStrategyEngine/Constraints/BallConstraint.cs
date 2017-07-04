﻿using System;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Constraints
{
    public class BallConstraint : Constraint
    {
        public BallConstraint(double[] termsCoefficients, double limitingValue) : base(termsCoefficients, limitingValue)
        {
        }

        public override bool IsSatysfingConstraint(Point point)
        {
            var constraintSum = 0.0;
            var numberOfDimensions = TermsCoefficients.Length;

            for (var i = 0; i < numberOfDimensions; i++)
            {
                constraintSum += Math.Pow(point.Coordinates[i] - TermsCoefficients[i], 2);
            }

            //return Math.Pow(LimitingValue, 2) >= constraintSum;
            return LimitingValue >= constraintSum;
        }
    }
}
