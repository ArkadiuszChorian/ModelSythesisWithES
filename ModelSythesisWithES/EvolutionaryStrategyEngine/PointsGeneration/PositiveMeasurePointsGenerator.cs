using System.Collections.Generic;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.PointsGeneration
{
    public class PositiveMeasurePointsGenerator : IPointsGenerator
    {
        public PositiveMeasurePointsGenerator(Domain domain)
        {
            NumberOfDimensions = domain.NumberOfDimensions;
            Domain = domain;
        }

        public Domain Domain { get; set; }
        public int NumberOfDimensions { get; set; }  
           
        public Point[] GeneratePoints(int numberOfPointsToGenerate, List<Constraint> constraints)
        {
            //TODO: Check if constraints has common space. Now, if they don't have, algorithm will stuck in while loop.

            var points = new Point[numberOfPointsToGenerate];

            for (var i = 0; i < numberOfPointsToGenerate; i++)
            {
                points[i] = new Point(NumberOfDimensions);
                var currentPoint = points[i];
                var isSatsfyngConstraints = false;

                while (isSatsfyngConstraints == false)
                {
                    isSatsfyngConstraints = true;

                    for (var j = 0; j < NumberOfDimensions; j++)
                    {
                        currentPoint.Coordinates[j] = MersenneTwister.Instance.NextDouble(Domain.Limits[j].Item1, Domain.Limits[j].Item2);
                    }

                    foreach (var constraint in constraints)
                    {
                        if (constraint.IsSatysfingConstraint(currentPoint) == false)
                        {
                            isSatsfyngConstraints = false;
                            break;
                        }
                    }
                }
            }

            return points;
        }
    }
}
