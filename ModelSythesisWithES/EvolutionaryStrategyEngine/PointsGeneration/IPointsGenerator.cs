using EvolutionaryStrategyEngine.Benchmarks;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.PointsGeneration
{
    public interface IPointsGenerator
    {
        //Point[] GeneratePoints(int numberOfPointsToGenerate, List<Constraint> constraints);
        Point[] GeneratePoints(int numberOfPointsToGenerate, IBenchmark benchmark);
    }
}
