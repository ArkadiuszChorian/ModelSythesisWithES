﻿using System;

namespace EvolutionaryStrategyEngine.DistanceMeasuring
{
    public class EuclideanDistanceCalculator : IDistanceCalculator
    {
        public double CalculateDistance(double[] vector1, double[] vector2)
        {
            var sum = 0.0;
            var numberOfDimensions = vector1.Length;

            for (var i = 0; i < numberOfDimensions; i++)
            {
                sum += Math.Pow(vector1[i] - vector2[i], 2);
            }

            return Math.Sqrt(sum);
        }
    }
}
