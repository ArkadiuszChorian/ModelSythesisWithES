using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Mutation
{
    public interface IMutator<T> where T : Solution
    {
        T Mutate(T solution);
    }
}
