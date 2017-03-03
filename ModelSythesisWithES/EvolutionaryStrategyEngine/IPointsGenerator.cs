using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine
{
    public interface IPointsGenerator
    {
        Point[] GeneratePoints();
    }
}
