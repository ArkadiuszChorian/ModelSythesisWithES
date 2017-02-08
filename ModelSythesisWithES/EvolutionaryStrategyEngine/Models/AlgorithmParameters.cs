using System;

namespace EvolutionaryStrategyEngine.Models
{
    public class AlgorithmParameters
    {
        public AlgorithmParameters(int objectVectorSize, int populationSize)
        {
            GlobalLearningRate = 1 / Math.Sqrt(2 * objectVectorSize);
            IndividualLearningRate = 1 / Math.Sqrt(2 * Math.Sqrt(objectVectorSize));
            StepThreshold = 0.005;
            RotationAngle = 5 * Math.PI / 180;
            ObjectVectorSize = objectVectorSize;         
            PopulationSize = populationSize;
            NumberOfParentsSolutionsToSelect = PopulationSize;
            NumberOfSurvivorsSolutionsToSelect = PopulationSize;
            TypeOfMutation = MutationType.UncorrelatedNSteps;
        }
        public AlgorithmParameters(double globalLerningRate, double individualLearningRate, double stepThreshold, double rotationAngle, int objectVectorSize, int populationSize, int numberOfParentsSolutionsToSelect, int numberOfSurvivorsSolutionsToSelect, MutationType typeOfMutation)
        {           
            GlobalLearningRate = globalLerningRate;
            IndividualLearningRate = individualLearningRate;
            StepThreshold = stepThreshold;
            RotationAngle = rotationAngle;
            ObjectVectorSize = objectVectorSize;
            PopulationSize = populationSize;
            NumberOfParentsSolutionsToSelect = numberOfParentsSolutionsToSelect;
            NumberOfSurvivorsSolutionsToSelect = numberOfSurvivorsSolutionsToSelect;
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
        public int PopulationSize { get; set; }
        public int NumberOfParentsSolutionsToSelect { get; set; }
        public int NumberOfSurvivorsSolutionsToSelect { get; set; }
        public MutationType TypeOfMutation { get; set; }      
    }
}
