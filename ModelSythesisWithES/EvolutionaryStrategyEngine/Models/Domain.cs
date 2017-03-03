using System;
using System.Collections.Generic;

namespace EvolutionaryStrategyEngine.Models
{
    public class Domain
    {
        public Domain(AlgorithmParameters algorithmParameters)
        {
            NumberOfDimensions = algorithmParameters.NumberOfDimensions;
            Limits = new List<Tuple<double, double>>();

            for (var i = 0; i < algorithmParameters.NumberOfDimensions; i++)
            {
                Limits[i] = algorithmParameters.DefaultDomainLimit;
            }
        }

        public Domain(AlgorithmParameters algorithmParameters, List<Tuple<double, double>> domainLimits)
        {
            NumberOfDimensions = algorithmParameters.NumberOfDimensions;
            Limits = domainLimits;
        }

        public int NumberOfDimensions { get; set; }
        public List<Tuple<double, double>> Limits { get; set; }
    }
}
