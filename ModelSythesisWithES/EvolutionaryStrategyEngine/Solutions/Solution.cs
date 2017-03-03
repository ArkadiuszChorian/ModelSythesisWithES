using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Solutions
{
    public abstract class Solution
    {
        protected Solution(AlgorithmParameters algorithmParameters)
        {
            ObjectCoefficients = new double[algorithmParameters.ObjectVectorSize];
        }

        protected Solution(int vectorSize)
        {
            ObjectCoefficients = new double[vectorSize];
        }

        public double[] ObjectCoefficients { get; set; }
        public double FitnessScore { get; set; }
    }
}

//public Solution(AlgorithmParameters algorithmParameters)
//{
//    ObjectCoefficients = new double[algorithmParameters.ObjectVectorSize];

//    switch (algorithmParameters.TypeOfMutation)
//    {
//        case AlgorithmParameters.MutationType.UncorrelatedNSteps:
//            StdDeviationsCoefficients = new double[algorithmParameters.ObjectVectorSize];
//            break;
//        case AlgorithmParameters.MutationType.Correlated:
//            StdDeviationsCoefficients = new double[algorithmParameters.ObjectVectorSize];
//            RotationsCoefficients = new double[algorithmParameters.ObjectVectorSize];
//            break;
//        default:
//            throw new ArgumentOutOfRangeException(nameof(algorithmParameters.TypeOfMutation), algorithmParameters.TypeOfMutation, null);
//    }
//}

//protected Solution()
//{
//    throw new NotImplementedException();
//}


//public double[] StdDeviationsCoefficients { get; set; }
//public double[] RotationsCoefficients { get; set; }
//public double OneStepStdDeviation { get; set; }
