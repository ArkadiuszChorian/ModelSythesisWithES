using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Solutions
{
    public abstract class Solution
    {
        protected Solution(ExperimentParameters experimentParameters)
        {
            ObjectCoefficients = new double[(experimentParameters.NumberOfDimensions + 1) * experimentParameters.NumberOfConstraints];
        }

        protected Solution(int vectorSize)
        {
            ObjectCoefficients = new double[vectorSize];
        }

        protected Solution()
        {
        }

        public double[] ObjectCoefficients { get; set; }
        public double FitnessScore { get; set; }
    }
}

//public Solution(ExperimentParameters experimentParameters)
//{
//    ObjectCoefficients = new double[experimentParameters.ObjectVectorSize];

//    switch (experimentParameters.TypeOfMutation)
//    {
//        case ExperimentParameters.MutationType.UncorrelatedNSteps:
//            StdDeviationsCoefficients = new double[experimentParameters.ObjectVectorSize];
//            break;
//        case ExperimentParameters.MutationType.Correlated:
//            StdDeviationsCoefficients = new double[experimentParameters.ObjectVectorSize];
//            RotationsCoefficients = new double[experimentParameters.ObjectVectorSize];
//            break;
//        default:
//            throw new ArgumentOutOfRangeException(nameof(experimentParameters.TypeOfMutation), experimentParameters.TypeOfMutation, null);
//    }
//}

//protected Solution()
//{
//    throw new NotImplementedException();
//}


//public double[] StdDeviationsCoefficients { get; set; }
//public double[] RotationsCoefficients { get; set; }
//public double OneStepStdDeviation { get; set; }
