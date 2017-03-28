using System.Collections.Generic;
using EvolutionaryStrategyEngine.Evaluation;
using EvolutionaryStrategyEngine.Logging;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Mutation;
using EvolutionaryStrategyEngine.MutationSupervison;
using EvolutionaryStrategyEngine.PointsGeneration;
using EvolutionaryStrategyEngine.PopulationGeneration;
using EvolutionaryStrategyEngine.Selection;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Engine
{
    public interface IEngine
    {
        void RunExperiment();

        IPopulationGenerator PopulationGenerator { get; set; }
        IEvaluator Evaluator { get; set; }
        ILogger Logger { get; set; }
        IMutator ObjectMutator { get; set; }
        IMutator StdDeviationsMutator { get; set; }
        IMutationRuleSupervisor MutationRuleSupervisor { get; set; }
        ISelector ParentsSelector { get; set; }
        ISurvivorsSelector SurvivorsSelector { get; set; }
        IPointsGenerator PositivePointsGenerator { get; set; }
        IPointsGenerator NegativePointsGenerator { get; set; }
        ExperimentParameters ExperimentParameters { get; set; }
        IList<Solution> Population { get; set; }
    }
}
