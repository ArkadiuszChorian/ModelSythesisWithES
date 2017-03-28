using System;
using System.Collections.Generic;
using EvolutionaryStrategyEngine.Constraints;

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
            double partOfSurvivorsSolutionsToSelect = (double)1/7,
            SelectionType typeOfSurvivorsSelection = SelectionType.Distinct,

            int numberOfPositiveMeasurePoints = 100,  
            int numberOfNegativeMeasurePoints = 100,  
            double lowerLimitOfDomain = -100,
            double upperLimitOfDomain = 100,
            bool usePointsGeneration = true,

            int populationSize = 100,
            int numberOfGenerations = 100,
            int oneFifthRuleCheckInterval = 5,

            bool useRecombination = false,
            RecombinerType typeOfObjectsRecombiner = RecombinerType.Discrete,
            RecombinerType typeOfStdDeviationsRecombiner = RecombinerType.Discrete,
            RecombinerType typeOfRotationsRecombiner = RecombinerType.Discrete,
            double partOfPopulationToRecombine = (double)2/100,

            List<Constraint> constraintsToPointsGeneration = default(List<Constraint>)
            )
        {
            NumberOfDimensions = numberOfDimensions;

            NumberOfConstraints = numberOfConstraints;

            GlobalLearningRate = Math.Abs(globalLerningRate) < double.Epsilon ? 1 / Math.Sqrt(2 * numberOfDimensions) : globalLerningRate;
            IndividualLearningRate = Math.Abs(individualLearningRate) < double.Epsilon ? 1 / Math.Sqrt(2 * Math.Sqrt(numberOfDimensions)) : individualLearningRate;
            StepThreshold = stepThreshold;
            RotationAngle = rotationAngle;
            TypeOfMutation = typeOfMutation;

            PartOfParentsSolutionsToSelect = partOfParentsSolutionsToSelect;
            PartOfSurvivorsSolutionsToSelect = partOfSurvivorsSolutionsToSelect;
            TypeOfSurvivorsSelection = typeOfSurvivorsSelection;

            NumberOfPositiveMeasurePoints = numberOfPositiveMeasurePoints;
            NumberOfNegativeMeasurePoints = numberOfNegativeMeasurePoints;
            DefaultDomainLimit = Tuple.Create(lowerLimitOfDomain, upperLimitOfDomain);
            UsePointsGeneration = usePointsGeneration;

            PopulationSize = populationSize;
            NumberOfGenerations = numberOfGenerations;
            OneFifthRuleCheckInterval = oneFifthRuleCheckInterval;

            UseRecombination = useRecombination;
            TypeOfObjectsRecombiner = typeOfObjectsRecombiner;
            TypeOfStdDeviationsRecombiner = typeOfStdDeviationsRecombiner;
            TypeOfRotationsRecombiner = typeOfRotationsRecombiner;
            PartOfPopulationToRecombine = partOfPopulationToRecombine;

            ConstraintsToPointGeneration = constraintsToPointsGeneration;
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

        public enum RecombinerType
        {
            Discrete,
            Intermediate
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
        public SelectionType TypeOfSurvivorsSelection { get; set; }

        //Points generation
        public int NumberOfPositiveMeasurePoints { get; set; }
        public int NumberOfNegativeMeasurePoints { get; set; }
        public Tuple<double, double> DefaultDomainLimit { get; set; }
        public bool UsePointsGeneration { get; set; }

        //Experiment execution
        public int PopulationSize { get; set; }
        public int NumberOfGenerations { get; set; }    
        public int OneFifthRuleCheckInterval { get; set; }

        //Recombination
        public bool UseRecombination { get; set; }
        public RecombinerType TypeOfObjectsRecombiner { get; set; }    
        public RecombinerType TypeOfStdDeviationsRecombiner { get; set; }    
        public RecombinerType TypeOfRotationsRecombiner { get; set; }
        public double PartOfPopulationToRecombine { get; set; }    

        //Constraints to generate points
        public List<Constraint> ConstraintsToPointGeneration { get; set; }
    }
}
