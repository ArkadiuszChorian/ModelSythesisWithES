using System;
using System.Linq;
using EvolutionaryStrategyEngine.Evaluation;
using EvolutionaryStrategyEngine.Logging;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Mutation;
using EvolutionaryStrategyEngine.Recombination;
using EvolutionaryStrategyEngine.Selection;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine
{
    public class EvolutionaryStrategyEngine
    {
        private IEvaluator _evaluator;
        private ILogger _logger;
        private IMutator _mutator;
        private IRecombiner _recombiner;
        private ISelector _parentsSelector;
        private ISelector _survivorsSelector;

        public EvolutionaryStrategyEngine(AlgorithmParameters algorithmParameters, double[][] measurePoints)
        {
            AlgorithmParameters = algorithmParameters;
            Population = new Solution[AlgorithmParameters.PopulationSize];

            _evaluator = new Evaluator(measurePoints);
            _logger = new Logger();
            _mutator = new Mutator(algorithmParameters);
            _recombiner = new Recombiner();
            _parentsSelector = new RandomParentsSelector(algorithmParameters);
            _survivorsSelector = new SurvivorsSeletor(algorithmParameters);
        }

        public AlgorithmParameters AlgorithmParameters { get; set; }
        public Solution[] Population { get; set; }

        public void RunExperiment(int iterations)
        {
            GenerateRandomPopulation();

            for (var i = 0; i < iterations; i++)
            {
                var newPopulation = _parentsSelector.Select(Population).ToArray();

                for (var j = 0; j < newPopulation.Length; j++)
                {
                    newPopulation[j] = _mutator.Mutate(newPopulation[j]);
                    newPopulation[j].FitnessScore = _evaluator.Evaluate(newPopulation[j]);
                }             

                Population = _survivorsSelector.Select(newPopulation.ToList()).ToArray();
            }

            Population = Population.OrderByDescending(solution => solution.FitnessScore).ToArray();           
        }

        private void GenerateRandomPopulation()
        {
            for (var i = 0; i < Population.Length; i++)
            {                
                Population[i] = new Solution(AlgorithmParameters);
                var currentSolution = Population[i];

                for (var j = 0; j < currentSolution.ObjectCoefficients.Length; j++)
                {
                    currentSolution.ObjectCoefficients[j] = MersenneTwister.Instance.NextDouble();
                    currentSolution.StdDeviationsCoefficients[j] = MersenneTwister.Instance.NextDoublePositive();
                    currentSolution.OneStepStdDeviation = MersenneTwister.Instance.NextDoublePositive();
                }
            }
        }
    }
}
