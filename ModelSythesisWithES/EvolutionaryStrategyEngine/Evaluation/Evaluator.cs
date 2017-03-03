using EvolutionaryStrategyEngine.DistanceMeasuring;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Evaluation
{
    public class Evaluator : IEvaluator
    {
        private IDistanceCalculator _distanceCalculator;

        public Evaluator() {}

        public Evaluator(AlgorithmParameters algorithmParameters, IDistanceCalculator distanceCalculator, double[][] positiveMeasurePoints)
        {
            _distanceCalculator = distanceCalculator;
            PositiveMeasurePoints = positiveMeasurePoints;
            NegativeMeasurePoints = new double[algorithmParameters.NumberOfNegativeMeasurePoints][];
            for (var i = 0; i < algorithmParameters.NumberOfNegativeMeasurePoints; i++)
            {
                NegativeMeasurePoints[i] = new double[algorithmParameters.NumberOfDimensions];

                for (var j = 0; j < algorithmParameters.NumberOfDimensions; j++)
                {
                    //NegativeMeasurePoints[i][j] = MersenneTwister
                } 
            }
        }

        public double[][] PositiveMeasurePoints { get; set; }
        public double[][] NegativeMeasurePoints { get; set; }

        public double Evaluate(Solution solution)
        {
            var correctlyBounded = 0;
            var incorrectlyBounded = 0;
            var numberOfRestrictions = Arguments.Get<int>("NumberOfRestrictions");
            var numberOfRestrictionCoefficients = solution.ObjectCoefficients.Length / numberOfRestrictions;

            for (var i = 0; i < PositiveMeasurePoints.Length; i++)
            {
                var measurePoint = PositiveMeasurePoints[i];

                for (var j = 0; j < numberOfRestrictions; j += numberOfRestrictionCoefficients)
                {
                    var restrictionComputedValue = 0.0;
                    var restrictionLimitingValue = solution.ObjectCoefficients[j + numberOfRestrictionCoefficients - 1];

                    for (var k = j; k < numberOfRestrictionCoefficients - 1; k++)
                    {
                        restrictionComputedValue += solution.ObjectCoefficients[k] + measurePoint[k - j];
                    }

                    if (restrictionComputedValue <= restrictionLimitingValue)
                    {
                        correctlyBounded++;
                    }
                    else
                    {
                        incorrectlyBounded++;
                    }
                }
            }

            return (double)correctlyBounded / (correctlyBounded + incorrectlyBounded);
        }
    }
}
