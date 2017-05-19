using System.Collections.Generic;
using EvolutionaryStrategyEngine.Benchmarks;
using EvolutionaryStrategyEngine.DistanceMeasuring;
using EvolutionaryStrategyEngine.Evaluation;
using EvolutionaryStrategyEngine.Logging;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Mutation;
using EvolutionaryStrategyEngine.MutationSupervison;
using EvolutionaryStrategyEngine.PointsGeneration;
using EvolutionaryStrategyEngine.PopulationGeneration;
using EvolutionaryStrategyEngine.Recombination;
using EvolutionaryStrategyEngine.Selection;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Engine
{
    public static class EngineFactory
    {
        public static IEngine GetEngine(ExperimentParameters experimentParameters)
        {
            IEngine engine;

            //BasePopulation
            Solution[] basePopulation = new Solution[experimentParameters.BasePopulationSize];
            Solution[] offspringPopulation = new Solution[experimentParameters.OffspringPopulationSize];
            IBenchmark benchmark = BenchmarkFactory.GetBenchmark(experimentParameters);
            IPopulationGenerator populationGenerator = PopulationGeneratorsFactory.GetPopulationGenerator(experimentParameters);

            //Points generators
            //var domain = new Domain2(experimentParameters);
            IPointsGenerator positivePointsGenerator = new PositiveMeasurePointsGenerator();
            var positivePoints =
                positivePointsGenerator.GeneratePoints(experimentParameters.NumberOfPositiveMeasurePoints, benchmark);
            IPointsGenerator negativePointsGenerator = new NegativeMeasurePointsGenerator(positivePoints, new CanberraDistanceCalculator());

            //Evaluator
            var negativePoints =
                negativePointsGenerator.GeneratePoints(experimentParameters.NumberOfNegativeMeasurePoints, benchmark);
            IEvaluator evaluator = new Evaluator(experimentParameters, positivePoints, negativePoints);

            //Logger
            ILogger logger = null;

            //Selectors
            var parentsSelector = SelectorsFactory.GetParentsSelector(experimentParameters);
            var survivorsSelector = SelectorsFactory.GetSurvivorsSelector(experimentParameters);

            //Mutation
            var objectMutator = MutatorsFactory.GetObjectMutator(experimentParameters);
            var stdDeviationsMutator = MutatorsFactory.GetStdDevsMutator(experimentParameters);
            var mutationRuleSupervisor = MutationSupervisorsFactory.GetMutationRuleSupervisor(experimentParameters);

            if (experimentParameters.TypeOfMutation == ExperimentParameters.MutationType.Correlated)
            {
                if (experimentParameters.UseRecombination)
                {
                    var objectRecombiner = RecombinersFactory.GetObjectRecombiner(experimentParameters);
                    var stdDevsRecombiner = RecombinersFactory.GetStdDevsRecombiner(experimentParameters);
                    var rotationsRecombiner = RecombinersFactory.GetRotationsRecombiner(experimentParameters);
                    var rotationsMutator = MutatorsFactory.GetRotationsMutator(experimentParameters);

                    engine = new CmEngineWithRecombination(benchmark, populationGenerator, evaluator, logger, objectMutator, stdDeviationsMutator, mutationRuleSupervisor, parentsSelector, survivorsSelector, positivePointsGenerator, negativePointsGenerator, experimentParameters, basePopulation, offspringPopulation, objectRecombiner, stdDevsRecombiner, rotationsMutator, rotationsRecombiner);
                }
                else
                {
                    var rotationsMutator = MutatorsFactory.GetRotationsMutator(experimentParameters);

                    engine = new CmEngineWithoutRecombination(benchmark, populationGenerator, evaluator, logger, objectMutator, stdDeviationsMutator, mutationRuleSupervisor, parentsSelector, survivorsSelector, positivePointsGenerator, negativePointsGenerator, experimentParameters, basePopulation, offspringPopulation, rotationsMutator);
                }
            }
            else
            {
                if (experimentParameters.UseRecombination)
                {
                    var objectRecombiner = RecombinersFactory.GetObjectRecombiner(experimentParameters);
                    var stdDevsRecombiner = RecombinersFactory.GetStdDevsRecombiner(experimentParameters);

                    engine = new UmEngineWithRecombination(benchmark, populationGenerator, evaluator, logger, objectMutator, stdDeviationsMutator, mutationRuleSupervisor, parentsSelector, survivorsSelector, positivePointsGenerator, negativePointsGenerator, experimentParameters, basePopulation, offspringPopulation, objectRecombiner, stdDevsRecombiner);
                }
                else
                {
                    engine = new UmEngineWithoutRecombination(benchmark, populationGenerator, evaluator, logger, objectMutator, stdDeviationsMutator, mutationRuleSupervisor, parentsSelector, survivorsSelector, positivePointsGenerator, negativePointsGenerator, experimentParameters, basePopulation, offspringPopulation);
                }
            }             
            
            return engine;
        }
    }
}
