using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Solutions
{
    public class OneStepMutationSolution : Solution
    {
        public OneStepMutationSolution(AlgorithmParameters algorithmParameters) : base(algorithmParameters){}

        public OneStepMutationSolution(int vectorSize) : base(vectorSize){}

        public double OneStepStdDeviation { get; set; }
    }
}
