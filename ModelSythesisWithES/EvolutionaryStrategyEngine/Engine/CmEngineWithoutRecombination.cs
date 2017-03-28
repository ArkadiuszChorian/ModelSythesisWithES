using System.Collections.Generic;
using System.Linq;
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
    public class CmEngineWithoutRecombination : UmEngineWithoutRecombination
    {
        public CmEngineWithoutRecombination(IPopulationGenerator populationGenerator, IEvaluator evaluator, ILogger logger, IMutator objectMutator, IMutator stdDeviationsMutator, IMutationRuleSupervisor mutationRuleSupervisor, ISelector parentsSelector, ISurvivorsSelector survivorsSelector, IPointsGenerator positivePointsGenerator, IPointsGenerator negativePointsGenerator, ExperimentParameters experimentParameters, IList<Solution> population, IMutator rotationsMutator) : base(populationGenerator, evaluator, logger, objectMutator, stdDeviationsMutator, mutationRuleSupervisor, parentsSelector, survivorsSelector, positivePointsGenerator, negativePointsGenerator, experimentParameters, population)
        {
            RotationsMutator = rotationsMutator;
        }

        public IMutator RotationsMutator { get; set; }
        
        public override void RunExperiment()
        {
            Population = PopulationGenerator.GeneratePopulation(ExperimentParameters);

            for (var i = 0; i < ExperimentParameters.NumberOfGenerations; i++)
            {
                var newPopulation = ParentsSelector.Select(Population);

                for (var j = 0; j < newPopulation.Count; j++)
                {
                    newPopulation[j] = StdDeviationsMutator.Mutate(newPopulation[j]);
                    newPopulation[j] = ObjectMutator.Mutate(newPopulation[j]);

                    newPopulation[j].FitnessScore = Evaluator.Evaluate(newPopulation[j]);
                }

                Population = SurvivorsSelector.MakeUnionOrDistinct(newPopulation, Population);
                Population = SurvivorsSelector.Select(newPopulation);
            }

            Population = Population.OrderByDescending(solution => solution.FitnessScore).ToList();
        }
    }
}
