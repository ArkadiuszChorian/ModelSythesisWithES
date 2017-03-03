using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Solutions
{
    public class CorrelatedMutationSolution : NStepsMutationSolution
    {
        public CorrelatedMutationSolution(AlgorithmParameters algorithmParameters) : base(algorithmParameters)
        {
            RotationsCoefficients = new double[algorithmParameters.ObjectVectorSize];
        }

        public CorrelatedMutationSolution(int vectorSize) : base(vectorSize)
        {
            RotationsCoefficients = new double[vectorSize];
        }

        public double[] RotationsCoefficients { get; set; }
    }
}
