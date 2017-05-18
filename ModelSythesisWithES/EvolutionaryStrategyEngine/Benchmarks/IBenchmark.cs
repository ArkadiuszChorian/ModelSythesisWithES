using System;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Benchmarks
{
    public interface IBenchmark
    {
        Constraint[] Constraints { get; set; }
        Domain[] Domains { get; set; }
    }
}
