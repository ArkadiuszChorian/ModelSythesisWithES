using System;
using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class Mutator : IMutator
    {       
        public Mutator(AlgorithmParameters algorithmParameters)
        {
            GlobalLearningRate = algorithmParameters.GlobalLearningRate;
            IndividualLearningRate = algorithmParameters.IndividualLearningRate;
            StepThreshold = algorithmParameters.StepThreshold;
            RotationAngle = algorithmParameters.RotationAngle;
            Mutations = new List<Func<Solution, Solution>>();

            switch (algorithmParameters.TypeOfMutation)
            {
                case AlgorithmParameters.MutationType.UncorrelatedOneStep:
                    Mutations.Add(MutateStdDeviationsWithOneStep);
                    Mutations.Add(MutateObjectWithOneStep);
                    break;
                case AlgorithmParameters.MutationType.UncorrelatedNSteps:
                    Mutations.Add(MutateStdDeviationsWithNSteps);
                    Mutations.Add(MutateObjectWithNStep);
                    break;
                case AlgorithmParameters.MutationType.Correlated:
                    Mutations.Add(MutateStdDeviationsWithNSteps);
                    Mutations.Add(MutateRotations);
                    Mutations.Add(MutateObjectWithCorrelation);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithmParameters.TypeOfMutation), algorithmParameters.TypeOfMutation, null);
            }         
        }

        public double GlobalLearningRate { get; set; }
        public double IndividualLearningRate { get; set; }
        public double StepThreshold { get; set; }
        public double RotationAngle { get; set; }
        public List<Func<Solution, Solution>> Mutations { get; set; }

        public Solution Mutate(Solution solution)
        {
            foreach (var mutation in Mutations)
            {
                solution = mutation(solution);
            }

            return solution;
        }

        private Solution MutateStdDeviationsWithOneStep(Solution solution)
        {
            solution.OneStepStdDeviation *= Math.Exp(IndividualLearningRate * MersenneTwister.Instance.NextDoublePositive());
            solution.OneStepStdDeviation = solution.OneStepStdDeviation < StepThreshold ? StepThreshold : solution.OneStepStdDeviation;

            return solution;
        }

        private Solution MutateStdDeviationsWithNSteps(Solution solution)
        {
            var numberOfCoefficients = solution.StdDeviationsCoefficients.Length;

            for (var j = 0; j < numberOfCoefficients; j++)
            {
                solution.StdDeviationsCoefficients[j] *= Math.Exp(IndividualLearningRate * MersenneTwister.Instance.NextDoublePositive() + GlobalLearningRate * MersenneTwister.Instance.NextDoublePositive());
                solution.StdDeviationsCoefficients[j] = solution.StdDeviationsCoefficients[j] < StepThreshold ? StepThreshold : solution.StdDeviationsCoefficients[j];
            }

            return solution;
        }

        private Solution MutateRotations(Solution solution)
        {
            var numberOfCoefficients = solution.RotationsCoefficients.Length;

            for (var j = 0; j < numberOfCoefficients; j++)
            {
                solution.RotationsCoefficients[j] += RotationAngle * MersenneTwister.Instance.NextDoublePositive();

                if (Math.Abs(solution.RotationsCoefficients[j]) > Math.PI)
                {
                    solution.RotationsCoefficients[j] -= 2 * Math.PI * Math.Sign(solution.RotationsCoefficients[j]);
                }
            }

            return solution;
        }

        private Solution MutateObjectWithOneStep(Solution solution)
        {
            return MutateObject(solution, true);
        }

        private Solution MutateObjectWithNStep(Solution solution)
        {
            return MutateObject(solution, false);
        }

        private Solution MutateObjectWithCorrelation(Solution solution)
        {
            throw new NotImplementedException();
        }

        private Solution MutateObject(Solution solution, bool isOneStepMutation)
        {
            var numberOfCoefficients = solution.ObjectCoefficients.Length;

            for (var i = 0; i < numberOfCoefficients; i++)
            {
                if (isOneStepMutation)
                {
                    solution.ObjectCoefficients[i] += solution.OneStepStdDeviation * MersenneTwister.Instance.NextDoublePositive();
                }
                else
                {
                    solution.ObjectCoefficients[i] += solution.StdDeviationsCoefficients[i] * MersenneTwister.Instance.NextDoublePositive();                   
                }               
            }

            return solution;
        }
    }
}
