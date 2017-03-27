using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Evaluation;
using EvolutionaryStrategyEngine.Logging;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Mutation;
using EvolutionaryStrategyEngine.MutationSupervison;
using EvolutionaryStrategyEngine.PointsGeneration;
using EvolutionaryStrategyEngine.Recombination;
using EvolutionaryStrategyEngine.Selection;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Engine
{
    public class UmEngineWithRecombination : UmEngineWithoutRecombination
    {
        public UmEngineWithRecombination(IEvaluator evaluator, ILogger logger, IMutator objectMutator, IMutator stdDeviationsMutator, IMutationRuleSupervisor mutationRuleSupervisor, ISelector parentsSelector, ISelector survivorsSelector, IPointsGenerator positivePointsGenerator, IPointsGenerator negativePointsGenerator, ExperimentParameters experimentParameters, IList<Solution> population, IRecombiner objectRecombiner, IRecombiner stdDeviationsRecombiner) : base(evaluator, logger, objectMutator, stdDeviationsMutator, mutationRuleSupervisor, parentsSelector, survivorsSelector, positivePointsGenerator, negativePointsGenerator, experimentParameters, population)
        {
            ObjectRecombiner = objectRecombiner;
            StdDeviationsRecombiner = stdDeviationsRecombiner;
        }

        public IRecombiner ObjectRecombiner { get; set; }
        public IRecombiner StdDeviationsRecombiner { get; set; }  

        public override void RunExperiment()
        {
            GenerateRandomPopulation();

            for (var i = 0; i < ExperimentParameters.NumberOfGenerations; i++)
            {
                var newPopulation = ParentsSelector.Select(Population).ToArray();

                for (var j = 0; j < newPopulation.Length; j++)
                {
                    newPopulation[j] = StdDeviationsMutator.Mutate(newPopulation[j]);
                    newPopulation[j] = ObjectMutator.Mutate(newPopulation[j]);

                    newPopulation[j].FitnessScore = Evaluator.Evaluate(newPopulation[j]);
                }

                Population = SurvivorsSelector.Select(newPopulation.ToList()).ToArray();
            }

            Population = Population.OrderByDescending(solution => solution.FitnessScore).ToArray();
        }

        private void GenerateRandomPopulation()
        {
            //for (var i = 0; i < Population.Length; i++)
            for (var i = 0; i < Population.Count; i++)
            {
                Population[i] = new Solution(ExperimentParameters);
                var currentSolution = Population[i];

                for (var j = 0; j < currentSolution.ObjectCoefficients.Length; j++)
                {
                    currentSolution.ObjectCoefficients[j] = MersenneTwister.Instance.NextDouble();
                    currentSolution.StdDeviationsCoefficients[j] = MersenneTwister.Instance.NextDoublePositive();
                    //currentSolution.OneStepStdDeviation = MersenneTwister.Instance.NextDoublePositive();
                }
            }
        }
    }
}
