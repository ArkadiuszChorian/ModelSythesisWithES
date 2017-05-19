using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class OsmObjectMutator : IMutator
    {
        private readonly MersenneTwister _randomGenerator;

        public OsmObjectMutator()
        {
            _randomGenerator = MersenneTwister.Instance;
        }

        public Solution Mutate(Solution solution)
        {
            var numberOfCoefficients = solution.ObjectCoefficients.Length;

            for (var i = 0; i < numberOfCoefficients; i++)
            {
                solution.ObjectCoefficients[i] += solution.OneStepStdDeviation * _randomGenerator.NextDoublePositive();
            }

            return solution;
        }
    }
}
