using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Solutions
{
    public class NStepsMutationSolution : Solution
    {
        public NStepsMutationSolution(AlgorithmParameters algorithmParameters) : base(algorithmParameters)
        {
            StdDeviationsCoefficients = new double[algorithmParameters.ObjectVectorSize];
        }

        public NStepsMutationSolution(int vectorSize) : base(vectorSize)
        {
            StdDeviationsCoefficients = new double[vectorSize];
        }

        public double[] StdDeviationsCoefficients { get; set; }
    }
}
