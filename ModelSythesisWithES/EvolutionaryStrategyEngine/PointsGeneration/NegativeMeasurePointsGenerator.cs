using EvolutionaryStrategyEngine.Benchmarks;
using EvolutionaryStrategyEngine.DistanceMeasuring;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.PointsGeneration
{
    public class NegativeMeasurePointsGenerator : IPointsGenerator
    {
        private readonly MersenneTwister _randomGenerator;
        private readonly Point[] _positiveMeasurePoints;
        private readonly IDistanceCalculator _distanceCalculator;

        public NegativeMeasurePointsGenerator(Point[] positiveMeasurePoints, IDistanceCalculator distanceCalculator)
        {
            _randomGenerator = MersenneTwister.Instance;
            _positiveMeasurePoints = positiveMeasurePoints;
            _distanceCalculator = distanceCalculator;

            CalculateNearestNeighbourDistances();
        }

        public void CalculateNearestNeighbourDistances()
        {
            var numberOfPositiveMeasurePoints = _positiveMeasurePoints.Length;

            for (var i = 0; i < numberOfPositiveMeasurePoints; i++)
            {
                _positiveMeasurePoints[i].DistanceToNearestNeighbour = int.MaxValue;

                for (var j = 0; j < numberOfPositiveMeasurePoints; j++)
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

        public Point[] GeneratePoints(int numberOfPointsToGenerate, IBenchmark benchmark)
        {
            var numberOfDimensions = benchmark.Domains.Length;
            var points = new Point[numberOfPointsToGenerate];
            const double m = 1;

            for (var i = 0; i < numberOfPointsToGenerate; i++)
            {
                points[i] = new Point(numberOfDimensions);
                var currentPoint = points[i];
                var isSatisfyingNearestNeighbourConstraints = false;

                while (isSatisfyingNearestNeighbourConstraints == false)
                {
                    isSatisfyingNearestNeighbourConstraints = true;

                    for (var j = 0; j < numberOfDimensions; j++)
                    {
                        currentPoint.Coordinates[j] = _randomGenerator.NextDouble(benchmark.Domains[j].LowerLimit + m * benchmark.Domains[j].LowerLimit, benchmark.Domains[j].UpperLimit + m * benchmark.Domains[j].UpperLimit);
                        //currentPoint.Coordinates[j] = _randomGenerator.NextDouble(-500, 500);
                    }

                    for (var j = 0; j < _positiveMeasurePoints.Length; j++)
                    {
                        if (IsOutsideNeighbourhood(currentPoint, _positiveMeasurePoints[j])) continue;
                        isSatisfyingNearestNeighbourConstraints = false;
                        break;
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
