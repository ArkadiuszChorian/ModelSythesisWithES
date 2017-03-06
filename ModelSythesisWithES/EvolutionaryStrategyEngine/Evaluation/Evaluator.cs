using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Evaluation
{
    public class Evaluator : IEvaluator
    {
        public Evaluator() {}

        public Evaluator(AlgorithmParameters algorithmParameters, Point[] positiveMeasurePoints, Point[] negativeMeasurePoints)
        {
            PositiveMeasurePoints = positiveMeasurePoints;
            NegativeMeasurePoints = negativeMeasurePoints;
            NumberOfConstraints = algorithmParameters.NumberOfConstraints;
            NumberOfConstraintCoefficients = algorithmParameters.ObjectVectorSize / NumberOfConstraints;
        }

        public Point[] PositiveMeasurePoints { get; set; }
        public Point[] NegativeMeasurePoints { get; set; }
        public int NumberOfConstraints { get; set; }
        public int NumberOfConstraintCoefficients { get; set; }

        public double Evaluate(Solution solution)
        {
            var numberOfPositivePointsSatisfyingConstraints = 0;
            var numberOfNegativePointsSatisfyingConstraints = 0;
            //var numberOfRestrictions = Arguments.Get<int>("NumberOfRestrictions");
            //var numberOfConstraints = Arguments.Get<int>("NumberOfRestrictions");
            //var numberOfConstraintCoefficients = solution.ObjectCoefficients.Length / numberOfConstraints;

            for (var i = 0; i < PositiveMeasurePoints.Length; i++)
            {              
                if (IsSatisfyingConstraints(solution, PositiveMeasurePoints[i]))
                {
                    numberOfPositivePointsSatisfyingConstraints++;
                }
            }

            for (var i = 0; i < NegativeMeasurePoints.Length; i++)
            {             
                if (IsSatisfyingConstraints(solution, NegativeMeasurePoints[i]))
                {
                    numberOfNegativePointsSatisfyingConstraints++;
                }
            }

            return (double)numberOfPositivePointsSatisfyingConstraints / (PositiveMeasurePoints.Length + numberOfNegativePointsSatisfyingConstraints);
        }

        private bool IsSatisfyingConstraints(Solution solution, Point point)
        {
            for (var i = 0; i < NumberOfConstraints; i += NumberOfConstraintCoefficients)
            {
                var constraintComputedValue = 0.0;
                var constraintLimitingValue = solution.ObjectCoefficients[i + NumberOfConstraintCoefficients - 1];

                for (var j = i; j < NumberOfConstraintCoefficients - 1; j++)
                {
                    constraintComputedValue += solution.ObjectCoefficients[j] * point.Coordinates[j - i];
                }

                if (constraintComputedValue > constraintLimitingValue)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
