using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Evaluation
{
    public interface IEvaluator
    {
        double Evaluate(Solution solution);
    }
}
