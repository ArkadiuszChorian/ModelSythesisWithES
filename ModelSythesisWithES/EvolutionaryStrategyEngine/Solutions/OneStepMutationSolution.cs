using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Solutions
{
    public class OneStepMutationSolution : Solution
    {
        public OneStepMutationSolution(ExperimentParameters experimentParameters) : base(experimentParameters){}

        public OneStepMutationSolution(int vectorSize) : base(vectorSize){}

        public double OneStepStdDeviation { get; set; }
    }
}
