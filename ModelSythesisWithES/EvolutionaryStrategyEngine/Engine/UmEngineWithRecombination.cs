﻿using System.Collections.Generic;
using System.Linq;
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
    public class UmEngineWithRecombination : UmEngineWithoutRecombination
    {
        public UmEngineWithRecombination(IPopulationGenerator populationGenerator, IEvaluator evaluator, ILogger logger, IMutator objectMutator, IMutator stdDeviationsMutator, IMutationRuleSupervisor mutationRuleSupervisor, ISelector parentsSelector, ISurvivorsSelector survivorsSelector, IPointsGenerator positivePointsGenerator, IPointsGenerator negativePointsGenerator, ExperimentParameters experimentParameters, IList<Solution> population, IRecombiner objectRecombiner, IRecombiner stdDeviationsRecombiner) : base(populationGenerator, evaluator, logger, objectMutator, stdDeviationsMutator, mutationRuleSupervisor, parentsSelector, survivorsSelector, positivePointsGenerator, negativePointsGenerator, experimentParameters, population)
        {
            ObjectRecombiner = objectRecombiner;
            StdDeviationsRecombiner = stdDeviationsRecombiner;
        }

        public IRecombiner ObjectRecombiner { get; set; }
        public IRecombiner StdDeviationsRecombiner { get; set; }  

        public override void RunExperiment()
        {
            Population = PopulationGenerator.GeneratePopulation(ExperimentParameters);

            for (var i = 0; i < ExperimentParameters.NumberOfGenerations; i++)
            {
                var newPopulation = ParentsSelector.Select(Population);

                for (var j = 0; j < newPopulation.Count; j++)
                {
                    //TODO: Recombination
                    newPopulation[j] = StdDeviationsRecombiner.Recombine(newPopulation);
                    newPopulation[j] = ObjectRecombiner.Recombine(newPopulation, newPopulation[i]);

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
