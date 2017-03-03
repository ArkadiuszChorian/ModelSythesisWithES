using System.Collections.Generic;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.PointsGeneration
{
    public interface IPointsGenerator
    {
        Point[] GeneratePoints(List<Constraint> constraints, int numberOfPointsToGenerate);
    }
}
