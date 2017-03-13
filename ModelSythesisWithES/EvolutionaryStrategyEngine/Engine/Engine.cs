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
    public class Engine<T> where T : Solution, new()
    {
        public IEvaluator Evaluator { get; set; }
        public ILogger Logger { get; set; }
        public IMutator<T> ObjectMutator { get; set; }
        public IMutator<T> StdDeviationsMutator { get; set; }
        public IMutator<T> RotationsMutator { get; set; }
        public IMutationRuleSupervisor<T> MutationRuleSupervisor { get; set; }
        public IRecombiner<T> ObjectRecombiner { get; set; }
        public IRecombiner<T> StdDeviationsRecombiner { get; set; }
        public IRecombiner<T> RotationsRecombiner { get; set; }
        public ISelector ParentsSelector { get; set; }
        public ISelector SurvivorsSelector { get; set; }
        public IPointsGenerator PositivePointsGenerator { get; set; }
        public IPointsGenerator NegativePointsGenerator { get; set; }
        public ExperimentParameters ExperimentParameters { get; set; }

        //TODO
        public IList<Solution> Population { get; set; }
        //public NStepsMutationSolution[] Population { get; set; }

        public void RunExperiment()
        {
            GenerateRandomPopulation();

            for (var i = 0; i < ExperimentParameters.NumberOfGenerations; i++)
            {
                var newPopulation = ParentsSelector.Select(Population).ToArray();

                for (var j = 0; j < newPopulation.Length; j++)
                {
                    newPopulation[j] = StdDeviationsMutator.Mutate(newPopulation[j] as T);
                    newPopulation[j] = ObjectMutator.Mutate((T) newPopulation[j]);

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
                Population[i] = new NStepsMutationSolution(ExperimentParameters);
                var currentSolution = (NStepsMutationSolution)Population[i];

                for (var j = 0; j < currentSolution.ObjectCoefficients.Length; j++)
                {
                    currentSolution.ObjectCoefficients[j] = MersenneTwister.Instance.NextDouble();
                    currentSolution.StdDeviationsCoefficients[j] = MersenneTwister.Instance.NextDoublePositive();
                    //currentSolution.OneStepStdDeviation = MersenneTwister.Instance.NextDoublePositive();
                }
            }
        }

        //public static Engine<T> GetEngine(ExperimentParameters experimentParameters)
        //{
        //    switch (experimentParameters.TypeOfPointsGeneration)
        //    {
        //        case ExperimentParameters.PointsGenerationType.NoGeneration:
        //            break;
        //        case ExperimentParameters.PointsGenerationType.OnlyPositive:

        //            break;
        //        case ExperimentParameters.PointsGenerationType.PositiveAndNegative:
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }

        //    var engine = new Engine<T>();
        //    engine.Evaluator = new Evaluator();

        //    switch (experimentParameters.TypeOfMutation)
        //    {
        //        case ExperimentParameters.MutationType.UncorrelatedOneStep:
        //            engine.
        //            break;
        //        case ExperimentParameters.MutationType.UncorrelatedNSteps:
        //            break;
        //        case ExperimentParameters.MutationType.Correlated:
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //}
    }
}
