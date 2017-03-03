using System;

namespace EvolutionaryStrategyEngine.DistanceMeasuring
{
    public class CanberraDistanceCalculator : IDistanceCalculator
    {
        public double CalculateDistance(double[] vector1, double[] vector2)
        {
            var distance = 0.0;
            var numberOfDimensions = vector1.Length;

            for (var i = 0; i < numberOfDimensions; i++)
            {
                distance += Math.Abs(vector1[i] - vector2[i]) / (Math.Abs(vector1[i]) + Math.Abs(vector2[i]));
            }

            return distance;
        }
    }
}
