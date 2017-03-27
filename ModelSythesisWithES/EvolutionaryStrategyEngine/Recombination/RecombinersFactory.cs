using System;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Recombination
{
    public static class RecombinersFactory
    {
        public static IRecombiner GetObjectRecombiner(ExperimentParameters experimentParameters)
        {
            switch (experimentParameters.TypeOfObjectsRecombiner)
            {
                case ExperimentParameters.RecombinerType.Discrete:
                    return new ObjectDiscreteRecombiner();
                case ExperimentParameters.RecombinerType.Intermediate:
                    return new ObjectIntermediateRecombiner();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static IRecombiner GetStdDevsRecombiner(ExperimentParameters experimentParameters)
        {
            switch (experimentParameters.TypeOfMutation)
            {
                case ExperimentParameters.MutationType.UncorrelatedOneStep:
                    switch (experimentParameters.TypeOfStdDeviationsRecombiner)
                    {
                        case ExperimentParameters.RecombinerType.Discrete:
                            return new OsmStdDevsDiscreteRecombiner();
                        case ExperimentParameters.RecombinerType.Intermediate:
                            return new OsmStdDevsIntermediateRecombiner();
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case ExperimentParameters.MutationType.UncorrelatedNSteps:
                    switch (experimentParameters.TypeOfStdDeviationsRecombiner)
                    {
                        case ExperimentParameters.RecombinerType.Discrete:
                            return new NsmStdDevsDiscreteRecombiner();
                        case ExperimentParameters.RecombinerType.Intermediate:
                            return new NsmStdDevsIntermediateRecombiner();
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                case ExperimentParameters.MutationType.Correlated:
                    switch (experimentParameters.TypeOfStdDeviationsRecombiner)
                    {
                        case ExperimentParameters.RecombinerType.Discrete:
                            return new NsmStdDevsDiscreteRecombiner();
                        case ExperimentParameters.RecombinerType.Intermediate:
                            return new NsmStdDevsIntermediateRecombiner();
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static IRecombiner GetRotationsRecombiner(ExperimentParameters experimentParameters)
        {
            switch (experimentParameters.TypeOfRotationsRecombiner)
            {
                case ExperimentParameters.RecombinerType.Discrete:
                    return new RotationsDiscreteRecombiner();
                case ExperimentParameters.RecombinerType.Intermediate:
                    return new RotationsIntermediateRecombiner();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
