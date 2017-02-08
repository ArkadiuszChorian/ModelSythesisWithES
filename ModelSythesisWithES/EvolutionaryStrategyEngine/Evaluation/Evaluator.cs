using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Evaluation
{
    public class Evaluator : IEvaluator
    {
        public Evaluator() {}

        public Evaluator(double[][] measurePoints)
        {
            MeasurePoints = measurePoints;
        }

        public double[][] MeasurePoints { get; set; }

        public double Evaluate(Solution solution)
        {
            var correctlyBounded = 0;
            var incorrectlyBounded = 0;
            var numberOfRestrictions = Arguments.Get<int>("NumberOfRestrictions");
            var numberOfRestrictionCoefficients = solution.ObjectCoefficients.Length / numberOfRestrictions;

            for (var i = 0; i < MeasurePoints.Length; i++)
            {
                var measurePoint = MeasurePoints[i];

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
