using System.Collections.Generic;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.PointsGeneration
{
    public interface IPointsGenerator
    {
        Point[] GeneratePoints(int numberOfPointsToGenerate, List<Constraint> constraints);
    }
}
