using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Mutation
{
    public interface IMutator
    {
        Solution Mutate(Solution solution);
    }
}
