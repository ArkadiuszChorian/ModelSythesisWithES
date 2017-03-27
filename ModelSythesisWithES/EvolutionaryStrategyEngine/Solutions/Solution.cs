using System;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Solutions
{
    public class Solution
    {
        public Solution(ExperimentParameters experimentParameters)
        {
            ObjectCoefficients = new double[(experimentParameters.NumberOfDimensions + 1) * experimentParameters.NumberOfConstraints];

            switch (experimentParameters.TypeOfMutation)
            {
                case ExperimentParameters.MutationType.UncorrelatedOneStep:
                    break;
                case ExperimentParameters.MutationType.UncorrelatedNSteps:
                    StdDeviationsCoefficients = new double[(experimentParameters.NumberOfDimensions + 1) * experimentParameters.NumberOfConstraints];
                    break;
                case ExperimentParameters.MutationType.Correlated:
                    StdDeviationsCoefficients = new double[(experimentParameters.NumberOfDimensions + 1) * experimentParameters.NumberOfConstraints];

                    RotationsCoefficients = new double[experimentParameters.NumberOfDimensions * (experimentParameters.NumberOfDimensions - 1) / 2][];

                    for (var i = 0; i < RotationsCoefficients.Length; i++)
                    {
                        RotationsCoefficients[i] = new double[experimentParameters.NumberOfDimensions * (experimentParameters.NumberOfDimensions - 1) / 2];
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }           
        }

        public Solution(int vectorSize)
        {
            ObjectCoefficients = new double[vectorSize];
            StdDeviationsCoefficients = new double[vectorSize];

            RotationsCoefficients = new double[vectorSize * (vectorSize - 1) / 2][];

            for (var i = 0; i < RotationsCoefficients.Length; i++)
            {
                RotationsCoefficients[i] = new double[vectorSize * (vectorSize - 1) / 2];
            }
        }

        public Solution(Solution solution)
        {
            ObjectCoefficients = solution.ObjectCoefficients;
            OneStepStdDeviation = solution.OneStepStdDeviation;
            StdDeviationsCoefficients = solution.StdDeviationsCoefficients;
            RotationsCoefficients = solution.RotationsCoefficients;
            FitnessScore = solution.FitnessScore;
        }

        public double[] ObjectCoefficients { get; set; }
        public double OneStepStdDeviation { get; set; }
        public double[] StdDeviationsCoefficients { get; set; }
        public double[][] RotationsCoefficients { get; set; }
        public double FitnessScore { get; set; }
    }
}
