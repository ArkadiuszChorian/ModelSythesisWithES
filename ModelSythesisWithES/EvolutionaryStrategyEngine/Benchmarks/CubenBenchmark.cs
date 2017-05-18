using System.Collections.Generic;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Benchmarks
{
    public class CubenBenchmark : IBenchmark
    {
        public CubenBenchmark(ExperimentParameters experimentParameters)
        {
            var numberOfDimensions = experimentParameters.NumberOfDimensions;
            var cubenBoundaryValue = experimentParameters.CubenBoundaryValue;   
            var constraints = new List<Constraint>(numberOfDimensions * 2);
            
            Domains = new Domain[numberOfDimensions];

            for (var i = 0; i < numberOfDimensions; i++)
            {
                var termsCoefficients1 = new double[numberOfDimensions];
                var termsCoefficients2 = new double[numberOfDimensions];
                termsCoefficients1[i] = -1;
                termsCoefficients2[i] = 1;

                constraints.Add(new LinearConstraint(termsCoefficients1, -i));
                constraints.Add(new LinearConstraint(termsCoefficients2, i + cubenBoundaryValue));

                Domains[i] = new Domain(i - cubenBoundaryValue, i + 2 * cubenBoundaryValue);
            }

            Constraints = constraints.ToArray();
        }

        public Constraint[] Constraints { get; set; }
        public Domain[] Domains { get; set; }
    }
}
