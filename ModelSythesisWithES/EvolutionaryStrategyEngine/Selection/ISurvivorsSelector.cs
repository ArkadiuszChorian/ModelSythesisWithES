using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Selection
{
    public interface ISurvivorsSelector
    {
        Solution[] Select(Solution[] parentSolutions, Solution[] offspringSolutions);
    }
}
