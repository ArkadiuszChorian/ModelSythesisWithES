using System;

namespace EvolutionaryStrategyEngine.Models
{
    public class ExperimentParameters
    {
        //GlobalLearningRate = 1 / Math.Sqrt(2 * objectVectorSize);
        //    IndividualLearningRate = 1 / Math.Sqrt(2 * Math.Sqrt(objectVectorSize));
        //    StepThreshold = 0;
        //    RotationAngle = 5 * Math.PI / 180;
        //    ObjectVectorSize = objectVectorSize;
        //    TypeOfMutation = MutationType.Correlated;

        public ExperimentParameters(
            int numberOfDimensions,

            int numberOfConstraints,

            double globalLerningRate = 0, 
            double individualLearningRate = 0, 
            double stepThreshold = 0.1, 
            double rotationAngle = 5 * Math.PI / 180,
            MutationType typeOfMutation = MutationType.Correlated,

            double partOfParentsSolutionsToSelect = 1.0,
            double partOfSurvivorsSolutionsToSelect = 1.0,
            SelectionType typeOfSelection = SelectionType.Distinct,

            int numberOfPositiveMeasurePoints = 100,  
            int numberOfNegativeMeasurePoints = 100,  
            double lowerLimitOfDomain = -100,
            double upperLimitOfDomain = 100,
            PointsGenerationType typeOfPointsGeneration = PointsGenerationType.PositiveAndNegative,

            int populationSize = 100,
            int numberOfGenerations = 100,
            int oneFifthRuleCheckInterval = 5,
            bool useRecombination = false              
            )
        {
            NumberOfDimensions = numberOfDimensions;

            NumberOfConstraints = numberOfConstraints;

            GlobalLearningRate = globalLerningRate == 0 ? 1 / Math.Sqrt(2 * numberOfDimensions) : globalLerningRate;
            IndividualLearningRate = individualLearningRate == 0 ? 1 / Math.Sqrt(2 * Math.Sqrt(numberOfDimensions)) : individualLearningRate;
            StepThreshold = stepThreshold;
            RotationAngle = rotationAngle;
            TypeOfMutation = typeOfMutation;

            PartOfParentsSolutionsToSelect = partOfParentsSolutionsToSelect;
            PartOfSurvivorsSolutionsToSelect = partOfSurvivorsSolutionsToSelect;
            TypeOfSelection = typeOfSelection;

            NumberOfPositiveMeasurePoints = numberOfPositiveMeasurePoints;
            NumberOfNegativeMeasurePoints = numberOfNegativeMeasurePoints;
            DefaultDomainLimit = Tuple.Create(lowerLimitOfDomain, upperLimitOfDomain);
            TypeOfPointsGeneration = typeOfPointsGeneration;

            PopulationSize = populationSize;
            NumberOfGenerations = numberOfGenerations;
            OneFifthRuleCheckInterval = oneFifthRuleCheckInterval;
            UseRecombination = useRecombination;          
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

        public enum PointsGenerationType
        {
            NoGeneration,
            OnlyPositive,
            PositiveAndNegative
        }

        //Global parameters
        public int NumberOfDimensions { get; set; }

        //Problem specific
        public int NumberOfConstraints { get; set; }

        //Mutation
        public double GlobalLearningRate { get; set; }
        public double IndividualLearningRate { get; set; }
        public double StepThreshold { get; set; }
        public double RotationAngle { get; set; }
        public MutationType TypeOfMutation { get; set; }

        //Selection
        public double PartOfParentsSolutionsToSelect { get; set; }
        public double PartOfSurvivorsSolutionsToSelect { get; set; }
        public SelectionType TypeOfSelection { get; set; }

        //Points generation
        public int NumberOfPositiveMeasurePoints { get; set; }
        public int NumberOfNegativeMeasurePoints { get; set; }
        public Tuple<double, double> DefaultDomainLimit { get; set; }
        public PointsGenerationType TypeOfPointsGeneration { get; set; }

        //Experiment execution
        public int PopulationSize { get; set; }
        public int NumberOfGenerations { get; set; }    
        public int OneFifthRuleCheckInterval { get; set; }
        public bool UseRecombination { get; set; }          
    }
}
