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
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Engine
{
    public class CmEngineWithoutRecombination : UmEngineWithoutRecombination
    {
        public CmEngineWithoutRecombination(IPopulationGenerator populationGenerator, IEvaluator evaluator, ILogger logger, IMutator objectMutator, IMutator stdDeviationsMutator, IMutationRuleSupervisor mutationRuleSupervisor, ISelector parentsSelector, ISurvivorsSelector survivorsSelector, IPointsGenerator positivePointsGenerator, IPointsGenerator negativePointsGenerator, ExperimentParameters experimentParameters, IList<Solution> basePopulation, IList<Solution> offspringPopulation, IMutator rotationsMutator) : base(populationGenerator, evaluator, logger, objectMutator, stdDeviationsMutator, mutationRuleSupervisor, parentsSelector, survivorsSelector, positivePointsGenerator, negativePointsGenerator, experimentParameters, basePopulation, offspringPopulation)
        {
            RotationsMutator = rotationsMutator;
        }

        public IMutator RotationsMutator { get; set; }
        
        public override void RunExperiment()
        {
            BasePopulation = PopulationGenerator.GeneratePopulation(ExperimentParameters);

            for (var i = 0; i < ExperimentParameters.OffspringPopulationSize; i++)
            {
                OffspringPopulation.Add(new Solution(ExperimentParameters));
            }

            InitialPopulation = BasePopulation.DeepCopyByExpressionTree();

            for (var i = 0; i < ExperimentParameters.NumberOfGenerations; i++)
            {
                for (var j = 0; j < ExperimentParameters.OffspringPopulationSize; j++)
                {
                    OffspringPopulation[j] = BasePopulation[MersenneTwister.Instance.Next(BasePopulation.Count)].DeepCopyByExpressionTree();

                    OffspringPopulation[j] = StdDeviationsMutator.Mutate(OffspringPopulation[j]);
                    OffspringPopulation[j] = RotationsMutator.Mutate(OffspringPopulation[j]);
                    OffspringPopulation[j] = ObjectMutator.Mutate(OffspringPopulation[j]);

                    OffspringPopulation[j].FitnessScore = Evaluator.Evaluate(OffspringPopulation[j]);
                }
                BasePopulation = SurvivorsSelector.Select(OffspringPopulation);
            }

            BasePopulation = BasePopulation.OrderByDescending(solution => solution.FitnessScore).ToList();
        }
    }
}
