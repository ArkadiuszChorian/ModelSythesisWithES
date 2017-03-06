using System.Collections.Generic;
using System.Diagnostics;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.DistanceMeasuring;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.PointsGeneration
{
    public class NegativeMeasurePointsGenerator : IPointsGenerator
    {
        private Point[] _positiveMeasurePoints;
        private IDistanceCalculator _distanceCalculator;

        public NegativeMeasurePointsGenerator(Point[] positiveMeasurePoints, IDistanceCalculator distanceCalculator, Domain domain)
        {
            _positiveMeasurePoints = positiveMeasurePoints;
            _distanceCalculator = distanceCalculator;
            Domain = domain;
            NumberOfDimensions = domain.NumberOfDimensions;
        }

        public Domain Domain { get; set; }
        public int NumberOfDimensions { get; set; }

        public void CalculateNearestNeighbourDistances()
        {
            for (var i = 0; i < _positiveMeasurePoints.Length; i++)
            {
                _positiveMeasurePoints[i].DistanceToNearestNeighbour = int.MaxValue;

                for (var j = 0; j < _positiveMeasurePoints.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var distanceBetweenPoints = _distanceCalculator.CalculateDistance(_positiveMeasurePoints[i].Coordinates,
                        _positiveMeasurePoints[j].Coordinates);

                    if (distanceBetweenPoints < _positiveMeasurePoints[i].DistanceToNearestNeighbour)
                    {
                        _positiveMeasurePoints[i].DistanceToNearestNeighbour = distanceBetweenPoints;
                    }
                }
            }
        }

        public Point[] GeneratePoints(int numberOfPointsToGenerate, List<Constraint> constraints = null)
        {
            var points = new Point[numberOfPointsToGenerate];

            for (var i = 0; i < numberOfPointsToGenerate; i++)
            {
                points[i] = new Point(NumberOfDimensions);
                var currentPoint = points[i];
                var isSatsfyngNearestNeighbourConstraints = false;

                while (isSatsfyngNearestNeighbourConstraints == false)
                {
                    isSatsfyngNearestNeighbourConstraints = true;

                    for (var j = 0; j < NumberOfDimensions; j++)
                    {
                        currentPoint.Coordinates[j] = MersenneTwister.Instance.NextDouble(Domain.Limits[j].Item1, Domain.Limits[j].Item2);
                    }

                    for (var j = 0; j < _positiveMeasurePoints.Length; j++)
                    {
                        if (IsOutsideNeighbourhood(currentPoint, _positiveMeasurePoints[j]) == false)
                        {
                            isSatsfyngNearestNeighbourConstraints = false;
                            break;
                        }
                    }
                }
            }

            return points;
        }

        private bool IsOutsideNeighbourhood(Point pointToCheck, Point centerPoint)
        {
            return _distanceCalculator.CalculateDistance(pointToCheck.Coordinates, centerPoint.Coordinates) >
                   centerPoint.DistanceToNearestNeighbour;
        }
    }
}
