using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Evaluation
{
    public interface IEvaluator
    {
        double Evaluate(Solution solution);
    }
}
