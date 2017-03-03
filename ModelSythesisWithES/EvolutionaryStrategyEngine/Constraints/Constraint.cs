using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Constraints
{
    public abstract class Constraint
    {
        protected Constraint(double[] termsCoefficients, double limitingValue)
        {
            TermsCoefficients = termsCoefficients;
            LimitingValue = limitingValue;
        }

        public double[] TermsCoefficients { get; set; }
        public double LimitingValue { get; set; }

        public abstract bool IsSatysfingConstraint(Point point);
    }
}
