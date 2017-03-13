using System;
using EvolutionaryStrategyEngine.DistanceMeasuring;
using EvolutionaryStrategyEngine.Evaluation;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Mutation;
using EvolutionaryStrategyEngine.MutationSupervison;
using EvolutionaryStrategyEngine.PointsGeneration;
using EvolutionaryStrategyEngine.Recombination;
using EvolutionaryStrategyEngine.Selection;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Engine
{
    public class EngineFactory
    {
        public Engine<T> GetEngine<T>(ExperimentParameters experimentParameters) where T : Solution, new()
        {
            var engine = new Engine<T>();

            engine.ExperimentParameters = experimentParameters;

            //TODO
            engine.Population = new NStepsMutationSolution[experimentParameters.PopulationSize];

            switch (experimentParameters.TypeOfMutation)
            {
                case ExperimentParameters.MutationType.UncorrelatedOneStep:
                    engine.ObjectMutator = (IMutator<T>) new OneStepMutationObjectMutator();
                    engine.StdDeviationsMutator = (IMutator<T>) new OneStepMutationStdDeviationsMutator();

                    engine.MutationRuleSupervisor = (IMutationRuleSupervisor<T>)new OneStepMutationOneFifthRuleSupervisor();

                    if (experimentParameters.UseRecombination)
                    {
                        switch (experimentParameters.TypeOfObjectsRecombiner)
                        {
                            case ExperimentParameters.RecombinerType.Discrete:
                                engine.ObjectRecombiner = new ObjectDiscreteRecombiner<T>();
                                break;
                            case ExperimentParameters.RecombinerType.Intermediate:
                                engine.ObjectRecombiner = new ObjectIntermediateRecombiner<T>();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        switch (experimentParameters.TypeOfStdDeviationsRecombiner)
                        {
                            case ExperimentParameters.RecombinerType.Discrete:
                                engine.ObjectRecombiner = (IRecombiner<T>)new OneStepMutationStdDeviationsDiscreteRecombiner();
                                break;
                            case ExperimentParameters.RecombinerType.Intermediate:
                                engine.ObjectRecombiner = (IRecombiner<T>)new OneStepMutationStdDeviationsIntermediateRecombiner();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    break;
                case ExperimentParameters.MutationType.UncorrelatedNSteps:
                    engine.ObjectMutator = (IMutator<T>)new NStepsMutationObjectMutator();
                    engine.StdDeviationsMutator = (IMutator<T>)new NStepsMutationStdDeviationsMutator();

                    engine.MutationRuleSupervisor = (IMutationRuleSupervisor<T>) new NStepsMutationOneFifthRuleSupervisor();

                    if (experimentParameters.UseRecombination)
                    {
                        switch (experimentParameters.TypeOfObjectsRecombiner)
                        {
                            case ExperimentParameters.RecombinerType.Discrete:
                                engine.ObjectRecombiner = new ObjectDiscreteRecombiner<T>();
                                break;
                            case ExperimentParameters.RecombinerType.Intermediate:
                                engine.ObjectRecombiner = new ObjectIntermediateRecombiner<T>();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        switch (experimentParameters.TypeOfStdDeviationsRecombiner)
                        {
                            case ExperimentParameters.RecombinerType.Discrete:
                                engine.ObjectRecombiner = (IRecombiner<T>)new NStepsMutationStdDeviationsDiscreteRecombiner();
                                break;
                            case ExperimentParameters.RecombinerType.Intermediate:
                                engine.ObjectRecombiner = (IRecombiner<T>)new NStepsMutationStdDeviationsIntermediateRecombiner();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    break;
                case ExperimentParameters.MutationType.Correlated:
                    engine.ObjectMutator = (IMutator<T>)new CorrelatedMutationObjectMutator(experimentParameters);
                    engine.StdDeviationsMutator = (IMutator<T>)new CorrelatedMutationObjectMutator(experimentParameters);
                    engine.RotationsMutator = (IMutator<T>) new RotationsMutator();

                    engine.MutationRuleSupervisor = (IMutationRuleSupervisor<T>)new NStepsMutationOneFifthRuleSupervisor();

                    if (experimentParameters.UseRecombination)
                    {
                        switch (experimentParameters.TypeOfObjectsRecombiner)
                        {
                            case ExperimentParameters.RecombinerType.Discrete:
                                engine.ObjectRecombiner = new ObjectDiscreteRecombiner<T>();
                                break;
                            case ExperimentParameters.RecombinerType.Intermediate:
                                engine.ObjectRecombiner = new ObjectIntermediateRecombiner<T>();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        switch (experimentParameters.TypeOfStdDeviationsRecombiner)
                        {
                            case ExperimentParameters.RecombinerType.Discrete:
                                engine.ObjectRecombiner = (IRecombiner<T>)new NStepsMutationStdDeviationsDiscreteRecombiner();
                                break;
                            case ExperimentParameters.RecombinerType.Intermediate:
                                engine.ObjectRecombiner = (IRecombiner<T>)new NStepsMutationStdDeviationsIntermediateRecombiner();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        switch (experimentParameters.TypeOfRotationsRecombiner)
                        {
                            case ExperimentParameters.RecombinerType.Discrete:
                                engine.ObjectRecombiner = (IRecombiner<T>)new RotationsDiscreteRecombiner();
                                break;
                            case ExperimentParameters.RecombinerType.Intermediate:
                                engine.ObjectRecombiner = (IRecombiner<T>)new RotationsIntermediateRecombiner();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //Points generators and evaluator

            var domain = new Domain(experimentParameters);

            switch (experimentParameters.TypeOfPointsGeneration)
            {
                case ExperimentParameters.PointsGenerationType.NoGeneration:
                    break;
                case ExperimentParameters.PointsGenerationType.OnlyPositive:
                    engine.PositivePointsGenerator = new PositiveMeasurePointsGenerator(domain);       
                    engine.Evaluator = new Evaluator(experimentParameters, engine.PositivePointsGenerator.GeneratePoints(experimentParameters.NumberOfPositiveMeasurePoints, experimentParameters.ConstraintsToPointGeneration));            
                    break;
                case ExperimentParameters.PointsGenerationType.PositiveAndNegative:
                    engine.PositivePointsGenerator = new PositiveMeasurePointsGenerator(domain);

                    var positivePoints =
                        engine.PositivePointsGenerator.GeneratePoints(
                            experimentParameters.NumberOfPositiveMeasurePoints,
                            experimentParameters.ConstraintsToPointGeneration);

                    engine.NegativePointsGenerator = new NegativeMeasurePointsGenerator(positivePoints,
                        new CanberraDistanceCalculator(), domain);

                    engine.Evaluator = new Evaluator(experimentParameters, positivePoints, engine.NegativePointsGenerator.GeneratePoints(experimentParameters.NumberOfNegativeMeasurePoints, experimentParameters.ConstraintsToPointGeneration));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }         
            
            //Selectors
            engine.ParentsSelector = new RandomParentsSelector(experimentParameters);
            engine.SurvivorsSelector = new SurvivorsSeletor(experimentParameters);    
            
            return engine;
        }
    }
}
