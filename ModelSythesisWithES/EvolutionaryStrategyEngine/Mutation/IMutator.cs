using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Mutation
{
    public interface IMutator
    {
        Solution Mutate(Solution solution);
    }
}
