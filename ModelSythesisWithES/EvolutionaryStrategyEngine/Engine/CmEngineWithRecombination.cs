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
            var offspringPopulationSize = ExperimentParameters.OffspringPopulationSize;
            var numberOfGenerations = ExperimentParameters.NumberOfGenerations;

            BasePopulation = PopulationGenerator.GeneratePopulation(ExperimentParameters);
            
            for (var i = 0; i < offspringPopulationSize; i++)
                OffspringPopulation[i] = new Solution(ExperimentParameters);

            InitialPopulation = BasePopulation.DeepCopyByExpressionTree();

            for (var i = 0; i < numberOfGenerations; i++)
            {
                for (var j = 0; j < offspringPopulationSize; j++)
                {
                    var parentsPopulation = ParentsSelector.Select(BasePopulation);

                    OffspringPopulation[j] = StdDeviationsRecombiner.Recombine(parentsPopulation, OffspringPopulation[j]);
                    OffspringPopulation[j] = RotationsRecombiner.Recombine(parentsPopulation, OffspringPopulation[j]);
                    OffspringPopulation[j] = ObjectRecombiner.Recombine(parentsPopulation, OffspringPopulation[j]);

                    OffspringPopulation[j] = StdDeviationsMutator.Mutate(OffspringPopulation[j]);
                    OffspringPopulation[j] = RotationsMutator.Mutate(OffspringPopulation[j]);
                    OffspringPopulation[j] = ObjectMutator.Mutate(OffspringPopulation[j]);

                    OffspringPopulation[j].FitnessScore = Evaluator.Evaluate(OffspringPopulation[j]);
                }
                BasePopulation = SurvivorsSelector.Select(BasePopulation, OffspringPopulation);
            }
        }
    }
}
