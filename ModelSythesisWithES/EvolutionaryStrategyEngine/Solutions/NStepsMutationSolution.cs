using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Solutions
{
    public class NStepsMutationSolution : Solution
    {
        public NStepsMutationSolution(ExperimentParameters experimentParameters) : base(experimentParameters)
        {
            //StdDeviationsCoefficients = new double[experimentParameters.NumberOfDimensions];
            StdDeviationsCoefficients = new double[(experimentParameters.NumberOfDimensions + 1) * experimentParameters.NumberOfConstraints];
        }

        public NStepsMutationSolution(int vectorSize) : base(vectorSize)
        {
            StdDeviationsCoefficients = new double[vectorSize];
        }

        public NStepsMutationSolution()
        {
        }

        public double[] StdDeviationsCoefficients { get; set; }
    }
}
