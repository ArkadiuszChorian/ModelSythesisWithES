using EvolutionaryStrategyEngine.Benchmarks;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.PointsGeneration
{
    public class PositiveMeasurePointsGenerator : IPointsGenerator
    {
        private readonly MersenneTwister _randomGenerator;

        public PositiveMeasurePointsGenerator()
        {
            _randomGenerator = MersenneTwister.Instance;
        }
           
        public Point[] GeneratePoints(int numberOfPointsToGenerate, IBenchmark benchmark)
        {
            //TODO: Check if constraints have common space. Now, if they don't have, algorithm will stuck in while loop.

            var numberOfDimensions = benchmark.Domains.Length;
            var constraints = benchmark.Constraints;
            var numberOfConstraints = constraints.Length;         
            var points = new Point[numberOfPointsToGenerate];

            for (var i = 0; i < numberOfPointsToGenerate; i++)
            {
                points[i] = new Point(numberOfDimensions);
                var currentPoint = points[i];
                var isSatsfyngConstraints = false;

                while (isSatsfyngConstraints == false)
                {
                    isSatsfyngConstraints = true;

                    for (var j = 0; j < numberOfDimensions; j++)
                    {
                        currentPoint.Coordinates[j] = _randomGenerator.NextDouble(benchmark.Domains[j].LowerLimit, benchmark.Domains[j].UpperLimit);                        
                    }

                    for (var j = 0; j < numberOfConstraints; j++)
                    {
                        if (constraints[j].IsSatysfingConstraint(currentPoint)) continue;
                        isSatsfyngConstraints = false;
                        break;
                    }
                }
            }

            return points;
        }

        //public Point[] GeneratePoints(int numberOfPointsToGenerate, List<Constraint> constraints)
        //{
        //    //TODO: Check if constraints have common space. Now, if they don't have, algorithm will stuck in while loop.

        //    var points = new Point[numberOfPointsToGenerate];

        //    for (var i = 0; i < numberOfPointsToGenerate; i++)
        //    {
        //        points[i] = new Point(NumberOfDimensions);
        //        var currentPoint = points[i];
        //        var isSatsfyngConstraints = false;

        //        while (isSatsfyngConstraints == false)
        //        {
        //            isSatsfyngConstraints = true;

        //            for (var j = 0; j < NumberOfDimensions; j++)
        //            {
        //                currentPoint.Coordinates[j] = _randomGenerator.NextDouble(Domain2.Limits[j].Item1, Domain2.Limits[j].Item2);
        //                //currentPoint.Coordinates[j] = random.Next((int)Domain2.Limits[j].Item1, (int)Domain2.Limits[j].Item2);
        //            }

        //            foreach (var constraint in constraints)
        //            {
        //                if (constraint.IsSatysfingConstraint(currentPoint) == false)
        //                {
        //                    isSatsfyngConstraints = false;
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    return points;
        //}
    }
}
