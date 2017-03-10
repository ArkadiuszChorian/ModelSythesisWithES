using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Solutions
{
    public class NStepsMutationSolution : Solution
    {
        public NStepsMutationSolution(ExperimentParameters experimentParameters) : base(experimentParameters)
        {
            StdDeviationsCoefficients = new double[experimentParameters.NumberOfDimensions];
        }

        public NStepsMutationSolution(int vectorSize) : base(vectorSize)
        {
            StdDeviationsCoefficients = new double[vectorSize];
        }

        public double[] StdDeviationsCoefficients { get; set; }
    }
}
