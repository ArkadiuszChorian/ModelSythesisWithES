using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Benchmarks;
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
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Engine
{
    public class CmEngineWithRecombination : UmEngineWithRecombination
    {
        public CmEngineWithRecombination(IBenchmark benchmark, IPopulationGenerator populationGenerator, IEvaluator evaluator, ILogger logger, IMutator objectMutator, IMutator stdDeviationsMutator, IMutationRuleSupervisor mutationRuleSupervisor, IParentsSelector parentsParentsSelector, ISurvivorsSelector survivorsSelector, IPointsGenerator positivePointsGenerator, IPointsGenerator negativePointsGenerator, ExperimentParameters experimentParameters, Solution[] basePopulation, Solution[] offspringPopulation, IRecombiner objectRecombiner, IRecombiner stdDeviationsRecombiner, IMutator rotationsMutator, IRecombiner rotationsRecombiner) : base(benchmark, populationGenerator, evaluator, logger, objectMutator, stdDeviationsMutator, mutationRuleSupervisor, parentsParentsSelector, survivorsSelector, positivePointsGenerator, negativePointsGenerator, experimentParameters, basePopulation, offspringPopulation, objectRecombiner, stdDeviationsRecombiner)
        {
            RotationsMutator = rotationsMutator;
            RotationsRecombiner = rotationsRecombiner;
        }

        public IMutator RotationsMutator { get; set; }
        public IRecombiner RotationsRecombiner { get; set; }

        public override void RunExperiment()
        {
            //BasePopulation = PopulationGenerator.GeneratePopulation(ExperimentParameters);

            //for (var i = 0; i < ExperimentParameters.NumberOfGenerations; i++)
            //{
            //    var newPopulation = ParentsSelector.Select(BasePopulation);

            //    for (var j = 0; j < newPopulation.Count; j++)
            //    {
            //        //TODO: Recombination
            //        newPopulation[j] = StdDeviationsRecombiner.Recombine(newPopulation, newPopulation[i]);
            //        newPopulation[j] = RotationsRecombiner.Recombine(newPopulation, newPopulation[i]);
            //        newPopulation[j] = ObjectRecombiner.Recombine(newPopulation, newPopulation[i]);

            //        newPopulation[j] = StdDeviationsMutator.Mutate(newPopulation[j]);
            //        newPopulation[j] = ObjectMutator.Mutate(newPopulation[j]);

            //        newPopulation[j].FitnessScore = Evaluator.Evaluate(newPopulation[j]);
            //    }

            //    BasePopulation = SurvivorsSelector.MakeUnionOrDistinct(newPopulation, BasePopulation);
            //    BasePopulation = SurvivorsSelector.Select(newPopulation);
            //}

            //BasePopulation = BasePopulation.OrderByDescending(solution => solution.FitnessScore).ToList();
        }
    }
}
