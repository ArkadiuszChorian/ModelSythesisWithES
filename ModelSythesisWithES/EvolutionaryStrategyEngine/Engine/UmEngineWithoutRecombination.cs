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
    public class UmEngineWithoutRecombination : IEngine
    {
        public UmEngineWithoutRecombination(IPopulationGenerator populationGenerator, IEvaluator evaluator, ILogger logger, IMutator objectMutator, IMutator stdDeviationsMutator, IMutationRuleSupervisor mutationRuleSupervisor, ISelector parentsSelector, ISurvivorsSelector survivorsSelector, IPointsGenerator positivePointsGenerator, IPointsGenerator negativePointsGenerator, ExperimentParameters experimentParameters, IList<Solution> population)
        {
            PopulationGenerator = populationGenerator;
            Evaluator = evaluator;
            Logger = logger;
            ObjectMutator = objectMutator;
            StdDeviationsMutator = stdDeviationsMutator;
            MutationRuleSupervisor = mutationRuleSupervisor;
            ParentsSelector = parentsSelector;
            SurvivorsSelector = survivorsSelector;
            PositivePointsGenerator = positivePointsGenerator;
            NegativePointsGenerator = negativePointsGenerator;
            ExperimentParameters = experimentParameters;
            Population = population;
        }

        public IPopulationGenerator PopulationGenerator { get; set; }
        public IEvaluator Evaluator { get; set; }
        public ILogger Logger { get; set; }
        public IMutator ObjectMutator { get; set; }
        public IMutator StdDeviationsMutator { get; set; }
        public IMutationRuleSupervisor MutationRuleSupervisor { get; set; }
        public ISelector ParentsSelector { get; set; }
        public ISurvivorsSelector SurvivorsSelector { get; set; }
        public IPointsGenerator PositivePointsGenerator { get; set; }
        public IPointsGenerator NegativePointsGenerator { get; set; }
        public ExperimentParameters ExperimentParameters { get; set; }

        //TODO
        public IList<Solution> Population { get; set; }

        public virtual void RunExperiment()
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
