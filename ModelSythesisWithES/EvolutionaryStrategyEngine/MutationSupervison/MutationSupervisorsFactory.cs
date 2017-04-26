using System;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.MutationSupervison
{
    public static class MutationSupervisorsFactory
    {
        public static IMutationRuleSupervisor GetMutationRuleSupervisor(ExperimentParameters experimentParameters)
        {
            switch (experimentParameters.TypeOfMutation)
            {
                case ExperimentParameters.MutationType.UncorrelatedOneStep:
                    return new OsmOneFifthRuleSupervisor();
                case ExperimentParameters.MutationType.UncorrelatedNSteps:
                    return new NsmOneFifthRuleSupervisor(experimentParameters);
                case ExperimentParameters.MutationType.Correlated:
                    return new NsmOneFifthRuleSupervisor(experimentParameters);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
