using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Selection
{
    public interface IParentsSelector
    {
        Solution[] Select(Solution[] parentSolutions);
    }
}
