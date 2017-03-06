using System;

namespace EvolutionaryStrategyEngine.Models
{
    public class AlgorithmParameters
    {
        public AlgorithmParameters()
        {
            
        }
        public AlgorithmParameters(int objectVectorSize)
        {
            GlobalLearningRate = 1 / Math.Sqrt(2 * objectVectorSize);
            IndividualLearningRate = 1 / Math.Sqrt(2 * Math.Sqrt(objectVectorSize));
            StepThreshold = 0;
            RotationAngle = 5 * Math.PI / 180;
            ObjectVectorSize = objectVectorSize;
            TypeOfMutation = MutationType.Correlated;
        }
        public AlgorithmParameters(
            double globalLerningRate, 
            double individualLearningRate, 
            double stepThreshold, 
            double rotationAngle, 
            int objectVectorSize, 
            int numberOfNegativeMeasurePoints,
            int numberOfDimensions, 
            int numberOfConstraints,
            MutationType typeOfMutation)
        {           
            GlobalLearningRate = globalLerningRate;
            IndividualLearningRate = individualLearningRate;
            StepThreshold = stepThreshold;
            RotationAngle = rotationAngle;
            ObjectVectorSize = objectVectorSize;
            NumberOfNegativeMeasurePoints = numberOfNegativeMeasurePoints;
            NumberOfDimensions = numberOfDimensions;
            NumberOfConstraints = numberOfConstraints;
            TypeOfMutation = typeOfMutation;
        }

        public enum MutationType
        {
            UncorrelatedOneStep,
            UncorrelatedNSteps,
            Correlated
        }
        public enum SelectionType
        {
            Distinct,
            Union
        }

        public double GlobalLearningRate { get; set; }
        public double IndividualLearningRate { get; set; }
        public double StepThreshold { get; set; }
        public double RotationAngle { get; set; }
        public int ObjectVectorSize { get; set; }
        public int NumberOfParentsSolutionsToSelect { get; set; }
        public int NumberOfSurvivorsSolutionsToSelect { get; set; }
        public int NumberOfNegativeMeasurePoints { get; set; }
        public int NumberOfDimensions { get; set; }
        public int NumberOfConstraints { get; set; }
        public Tuple<double, double> DefaultDomainLimit { get; set; }
        public MutationType TypeOfMutation { get; set; }      
    }
}
