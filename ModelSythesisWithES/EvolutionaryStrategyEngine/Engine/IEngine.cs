using System.Collections.Generic;
using EvolutionaryStrategyEngine.Benchmarks;
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

        IBenchmark Benchmark { get; set; }
        IPopulationGenerator PopulationGenerator { get; set; }
        IEvaluator Evaluator { get; set; }
        ILogger Logger { get; set; }
        IMutator ObjectMutator { get; set; }
        IMutator StdDeviationsMutator { get; set; }
        IMutationRuleSupervisor MutationRuleSupervisor { get; set; }
        IParentsSelector ParentsSelector { get; set; }
        ISurvivorsSelector SurvivorsSelector { get; set; }
        IPointsGenerator PositivePointsGenerator { get; set; }
        IPointsGenerator NegativePointsGenerator { get; set; }
        ExperimentParameters ExperimentParameters { get; set; }
        Solution[] BasePopulation { get; set; }
        Solution[] OffspringPopulation { get; set; }
        Solution[] InitialPopulation { get; set; }
    }
}
