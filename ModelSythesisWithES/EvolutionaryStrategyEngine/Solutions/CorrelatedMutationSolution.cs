using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Solutions
{
    public class CorrelatedMutationSolution : NStepsMutationSolution
    {
        public CorrelatedMutationSolution(ExperimentParameters experimentParameters) : base(experimentParameters)
        {            
            RotationsCoefficients = new double[experimentParameters.NumberOfDimensions * (experimentParameters.NumberOfDimensions - 1) / 2][];

            for (var i = 0; i < RotationsCoefficients.Length; i++)
            {
                RotationsCoefficients[i] = new double[experimentParameters.NumberOfDimensions * (experimentParameters.NumberOfDimensions - 1) / 2];
            }
        }

        public CorrelatedMutationSolution(int vectorSize) : base(vectorSize)
        {
            RotationsCoefficients = new double[vectorSize * (vectorSize - 1) / 2][];

            for (var i = 0; i < RotationsCoefficients.Length; i++)
            {
                RotationsCoefficients[i] = new double[vectorSize * (vectorSize - 1) / 2];
            }
        }

        public double[][] RotationsCoefficients { get; set; }
    }
}
