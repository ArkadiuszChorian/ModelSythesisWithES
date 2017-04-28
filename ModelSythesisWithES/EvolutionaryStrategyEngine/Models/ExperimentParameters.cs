using System;
using System.Collections.Generic;
using System.Threading;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Models
{
    public class ExperimentParameters
    {
        //private static readonly Lazy<ExperimentParameters> LazyInstance = new Lazy<ExperimentParameters>(() => new ExperimentParameters(), LazyThreadSafetyMode.PublicationOnly);
        private static readonly Lazy<ExperimentParameters> LazyInstance = new Lazy<ExperimentParameters>(() =>
        {
            if (Arguments.HasAnyKeys() == false)
                throw new MemberAccessException(
                    "There was no command line arguments. Give command line arguments or use Initialize method with hard-coded parameters before using Instance property.");
            try
            {
                return new ExperimentParameters();
            }
            catch (KeyNotFoundException)
            {
                throw new MemberAccessException(
                    "Given command line arguments are incorrect. Give command line arguments or use Initialize method with hard-coded parameters before using Instance property. You have to give at least numberOfDimensions and numberOfConstraints arguments.");
            }
        }, LazyThreadSafetyMode.PublicationOnly);

        public static ExperimentParameters Instance => LazyInstance.Value;
        //[ThreadStatic]
        //private static ExperimentParameters _instance;

        public static void Initialize(
            int numberOfDimensions,

            int numberOfConstraints,

            double globalLerningRate = double.NaN,
            double individualLearningRate = double.NaN,
            double stepThreshold = Defaults.StepThreshold,
            double rotationAngle = Defaults.RotationAngle,
            MutationType typeOfMutation = Defaults.TypeOfMutation,

            double partOfParentsSolutionsToSelect = Defaults.PartOfParentsSolutionsToSelect,
            double partOfSurvivorsSolutionsToSelect = Defaults.PartOfSurvivorsSolutionsToSelect,
            SelectionType typeOfSurvivorsSelection = Defaults.TypeOfSurvivorsSelection,

            int numberOfPositiveMeasurePoints = Defaults.NumberOfPositiveMeasurePoints,
            int numberOfNegativeMeasurePoints = Defaults.NumberOfNegativeMeasurePoints,
            double lowerLimitOfDomain = Defaults.LowerLimitOfDomain,
            double upperLimitOfDomain = Defaults.UpperLimitOfDomain,
            bool usePointsGeneration = Defaults.UsePointsGeneration,

            int basePopulationSize = Defaults.BasePopulationSize,
            int offspringPopulationSize = Defaults.OffspringPopulationSize,
            int numberOfGenerations = Defaults.NumberOfGenerations,
            int oneFifthRuleCheckInterval = Defaults.OneFifthRuleCheckInterval,
            double oneFifthRuleScalingFactor = Defaults.OneFifthRuleScalingFactor,

            bool useRecombination = Defaults.UseRecombination,
            RecombinerType typeOfObjectsRecombiner = Defaults.TypeOfObjectsRecombiner,
            RecombinerType typeOfStdDeviationsRecombiner = Defaults.TypeOfStdDeviationsRecombiner,
            RecombinerType typeOfRotationsRecombiner = Defaults.TypeOfRotationsRecombiner,
            double partOfPopulationToRecombine = Defaults.PartOfPopulationToRecombine,

            List<Constraint> constraintsToPointsGeneration = Defaults.ConstraintsToPointsGeneration)
        {
            _instance = new ExperimentParameters(
                 numberOfDimensions,
                 numberOfConstraints,
                 double.IsNaN(globalLerningRate) ? Defaults.GlobalLerningRate(numberOfDimensions) : globalLerningRate,
                 double.IsNaN(individualLearningRate) ? Defaults.IndividualLearningRate(numberOfDimensions) : individualLearningRate,
                 stepThreshold,
                 rotationAngle,
                 typeOfMutation,
                 partOfParentsSolutionsToSelect,
                 partOfSurvivorsSolutionsToSelect,
                 typeOfSurvivorsSelection,
                 numberOfPositiveMeasurePoints,
                 numberOfNegativeMeasurePoints,
                 lowerLimitOfDomain,
                 upperLimitOfDomain,
                 usePointsGeneration,
                 basePopulationSize,
                 offspringPopulationSize,
                 numberOfGenerations,
                 oneFifthRuleCheckInterval,
                 oneFifthRuleScalingFactor,
                 useRecombination,
                 typeOfObjectsRecombiner,
                 typeOfStdDeviationsRecombiner,
                 typeOfRotationsRecombiner,
                 partOfPopulationToRecombine,
                 constraintsToPointsGeneration
                 );          
        }       

        //public static ExperimentParameters Instance
        //{
        //    get
        //    {
        //        if (_instance != null) return _instance;

        //        if (Arguments.HasAnyKeys() == false)
        //            throw new MemberAccessException(
        //                "There was no command line arguments. Give command line arguments or use Initialize method with hard-coded parameters before using Instance property.");

        //        try
        //        {
        //            _instance = new ExperimentParameters();
        //        }
        //        catch (KeyNotFoundException)
        //        {
        //            throw new MemberAccessException(
        //                "Given command line arguments are incorrect. Give command line arguments or use Initialize method with hard-coded parameters before using Instance property. You have to give at least numberOfDimensions and numberOfConstraints arguments.");
        //        }

        //        return _instance;
        //    }
        }

        public ExperimentParameters()
        {
            NumberOfDimensions = Arguments.Get<int>(nameof(NumberOfDimensions));

            NumberOfConstraints = Arguments.Get<int>(nameof(NumberOfConstraints));

            //Optional parameters

            GlobalLearningRate = Arguments.HasKey(nameof(Defaults.GlobalLerningRate)) ? Arguments.Get<double>(nameof(Defaults.GlobalLerningRate)) : Defaults.GlobalLerningRate(NumberOfDimensions);
            IndividualLearningRate = Arguments.HasKey(nameof(Defaults.IndividualLearningRate)) ? Arguments.Get<double>(nameof(Defaults.IndividualLearningRate)) : Defaults.IndividualLearningRate(NumberOfDimensions);
            StepThreshold = Arguments.HasKey(nameof(Defaults.StepThreshold)) ? Arguments.Get<double>(nameof(Defaults.StepThreshold)) : Defaults.StepThreshold;
            RotationAngle = Arguments.HasKey(nameof(Defaults.RotationAngle)) ? Arguments.Get<double>(nameof(Defaults.RotationAngle)) : Defaults.RotationAngle;
            TypeOfMutation = Arguments.HasKey(nameof(Defaults.TypeOfMutation)) ? Arguments.Get<MutationType>(nameof(Defaults.TypeOfMutation)) : Defaults.TypeOfMutation;

            PartOfParentsSolutionsToSelect = Arguments.HasKey(nameof(Defaults.PartOfParentsSolutionsToSelect)) ? Arguments.Get<double>(nameof(Defaults.PartOfParentsSolutionsToSelect)) : Defaults.PartOfParentsSolutionsToSelect;
            PartOfSurvivorsSolutionsToSelect = Arguments.HasKey(nameof(Defaults.PartOfSurvivorsSolutionsToSelect)) ? Arguments.Get<double>(nameof(Defaults.PartOfSurvivorsSolutionsToSelect)) : Defaults.PartOfSurvivorsSolutionsToSelect;
            TypeOfSurvivorsSelection = Arguments.HasKey(nameof(Defaults.TypeOfSurvivorsSelection)) ? Arguments.Get<SelectionType>(nameof(Defaults.TypeOfSurvivorsSelection)) : Defaults.TypeOfSurvivorsSelection;

            NumberOfPositiveMeasurePoints = Arguments.HasKey(nameof(Defaults.NumberOfPositiveMeasurePoints)) ? Arguments.Get<int>(nameof(Defaults.NumberOfPositiveMeasurePoints)) : Defaults.NumberOfPositiveMeasurePoints;
            NumberOfNegativeMeasurePoints = Arguments.HasKey(nameof(Defaults.NumberOfNegativeMeasurePoints)) ? Arguments.Get<int>(nameof(Defaults.NumberOfNegativeMeasurePoints)) : Defaults.NumberOfNegativeMeasurePoints;
            DefaultDomainLimit = Tuple.Create(
                Arguments.HasKey(nameof(Defaults.LowerLimitOfDomain)) ? Arguments.Get<double>(nameof(Defaults.LowerLimitOfDomain)) : Defaults.LowerLimitOfDomain, 
                Arguments.HasKey(nameof(Defaults.UpperLimitOfDomain)) ? Arguments.Get<double>(nameof(Defaults.UpperLimitOfDomain)) : Defaults.UpperLimitOfDomain);

            // ReSharper disable once SimplifyConditionalTernaryExpression === Reason: All defaults have to be in Defaults class.
            UsePointsGeneration = Arguments.HasKey(nameof(Defaults.UsePointsGeneration)) ? Arguments.Get<bool>(nameof(Defaults.UsePointsGeneration)) : Defaults.UsePointsGeneration;

            BasePopulationSize = Arguments.HasKey(nameof(Defaults.BasePopulationSize)) ? Arguments.Get<int>(nameof(Defaults.BasePopulationSize)) : Defaults.BasePopulationSize;
            OffspringPopulationSize = Arguments.HasKey(nameof(Defaults.OffspringPopulationSize)) ? Arguments.Get<int>(nameof(Defaults.OffspringPopulationSize)) : Defaults.OffspringPopulationSize;
            NumberOfGenerations = Arguments.HasKey(nameof(Defaults.NumberOfGenerations)) ? Arguments.Get<int>(nameof(Defaults.NumberOfGenerations)) : Defaults.NumberOfGenerations;
            OneFifthRuleCheckInterval = Arguments.HasKey(nameof(Defaults.OneFifthRuleCheckInterval)) ? Arguments.Get<int>(nameof(Defaults.OneFifthRuleCheckInterval)) : Defaults.OneFifthRuleCheckInterval;
            OneFifthRuleScalingFactor = Arguments.HasKey(nameof(Defaults.OneFifthRuleScalingFactor)) ? Arguments.Get<int>(nameof(Defaults.OneFifthRuleScalingFactor)) : Defaults.OneFifthRuleScalingFactor;

            // ReSharper disable once SimplifyConditionalTernaryExpression === Reason: All defaults have to be in Defaults class.
            UseRecombination = Arguments.HasKey(nameof(Defaults.UseRecombination)) ? Arguments.Get<bool>(nameof(Defaults.UseRecombination)) : Defaults.UseRecombination;
            TypeOfObjectsRecombiner = Arguments.HasKey(nameof(Defaults.TypeOfObjectsRecombiner)) ? Arguments.Get<RecombinerType>(nameof(Defaults.TypeOfObjectsRecombiner)) : Defaults.TypeOfObjectsRecombiner;
            TypeOfStdDeviationsRecombiner = Arguments.HasKey(nameof(Defaults.TypeOfStdDeviationsRecombiner)) ? Arguments.Get<RecombinerType>(nameof(Defaults.TypeOfStdDeviationsRecombiner)) : Defaults.TypeOfStdDeviationsRecombiner;
            TypeOfRotationsRecombiner = Arguments.HasKey(nameof(Defaults.TypeOfRotationsRecombiner)) ? Arguments.Get<RecombinerType>(nameof(Defaults.TypeOfRotationsRecombiner)) : Defaults.TypeOfRotationsRecombiner;
            PartOfPopulationToRecombine = Arguments.HasKey(nameof(Defaults.PartOfPopulationToRecombine)) ? Arguments.Get<double>(nameof(Defaults.PartOfPopulationToRecombine)) : Defaults.PartOfPopulationToRecombine;

            ConstraintsToPointsGeneration = Arguments.HasKey(nameof(Defaults.ConstraintsToPointsGeneration)) ? Arguments.GetObject<List<Constraint>>(nameof(Defaults.ConstraintsToPointsGeneration)) : Defaults.ConstraintsToPointsGeneration; ;
        }
        //GlobalLearningRate = 1 / Math.Sqrt(2 * objectVectorSize);
        //    IndividualLearningRate = 1 / Math.Sqrt(2 * Math.Sqrt(objectVectorSize));
        //    StepThreshold = 0;
        //    RotationAngle = 5 * Math.PI / 180;
        //    ObjectVectorSize = objectVectorSize;
        //    TypeOfMutation = MutationType.Correlated;

        public ExperimentParameters(
            int numberOfDimensions,

            int numberOfConstraints,

            double globalLerningRate = double.NaN,
            double individualLearningRate = double.NaN,
            double stepThreshold = Defaults.StepThreshold,
            double rotationAngle = Defaults.RotationAngle,
            MutationType typeOfMutation = Defaults.TypeOfMutation,

            double partOfParentsSolutionsToSelect = Defaults.PartOfParentsSolutionsToSelect,
            double partOfSurvivorsSolutionsToSelect = Defaults.PartOfSurvivorsSolutionsToSelect,
            SelectionType typeOfSurvivorsSelection = Defaults.TypeOfSurvivorsSelection,

            int numberOfPositiveMeasurePoints = Defaults.NumberOfPositiveMeasurePoints,
            int numberOfNegativeMeasurePoints = Defaults.NumberOfNegativeMeasurePoints,
            double lowerLimitOfDomain = Defaults.LowerLimitOfDomain,
            double upperLimitOfDomain = Defaults.UpperLimitOfDomain,
            bool usePointsGeneration = Defaults.UsePointsGeneration,

            int basePopulationSize = Defaults.BasePopulationSize,
            int offspringPopulationSize = Defaults.OffspringPopulationSize,
            int numberOfGenerations = Defaults.NumberOfGenerations,
            int oneFifthRuleCheckInterval = Defaults.OneFifthRuleCheckInterval,
            double oneFifthRuleScalingFactor = Defaults.OneFifthRuleScalingFactor,

            bool useRecombination = Defaults.UseRecombination,
            RecombinerType typeOfObjectsRecombiner = Defaults.TypeOfObjectsRecombiner,
            RecombinerType typeOfStdDeviationsRecombiner = Defaults.TypeOfStdDeviationsRecombiner,
            RecombinerType typeOfRotationsRecombiner = Defaults.TypeOfRotationsRecombiner,
            double partOfPopulationToRecombine = Defaults.PartOfPopulationToRecombine,

            List<Constraint> constraintsToPointsGeneration = Defaults.ConstraintsToPointsGeneration)
        {
            NumberOfDimensions = numberOfDimensions;

            NumberOfConstraints = numberOfConstraints;

            GlobalLearningRate = double.IsNaN(globalLerningRate) ? Defaults.GlobalLerningRate(numberOfDimensions) : globalLerningRate;
            IndividualLearningRate = double.IsNaN(individualLearningRate) ? Defaults.IndividualLearningRate(numberOfDimensions) : individualLearningRate;
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

            BasePopulationSize = basePopulationSize;
            OffspringPopulationSize = offspringPopulationSize;
            NumberOfGenerations = numberOfGenerations;
            OneFifthRuleCheckInterval = oneFifthRuleCheckInterval;
            OneFifthRuleScalingFactor = oneFifthRuleScalingFactor;

            UseRecombination = useRecombination;
            TypeOfObjectsRecombiner = typeOfObjectsRecombiner;
            TypeOfStdDeviationsRecombiner = typeOfStdDeviationsRecombiner;
            TypeOfRotationsRecombiner = typeOfRotationsRecombiner;
            PartOfPopulationToRecombine = partOfPopulationToRecombine;

            ConstraintsToPointsGeneration = constraintsToPointsGeneration;
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
        public int BasePopulationSize { get; set; }
        public int OffspringPopulationSize { get; set; }
        public int NumberOfGenerations { get; set; }    
        public int OneFifthRuleCheckInterval { get; set; }
        public double OneFifthRuleScalingFactor { get; set; }

        //Recombination
        public bool UseRecombination { get; set; }
        public RecombinerType TypeOfObjectsRecombiner { get; set; }    
        public RecombinerType TypeOfStdDeviationsRecombiner { get; set; }    
        public RecombinerType TypeOfRotationsRecombiner { get; set; }
        public double PartOfPopulationToRecombine { get; set; }    

        //Constraints to generate points
        public List<Constraint> ConstraintsToPointsGeneration { get; set; }
    }
}
