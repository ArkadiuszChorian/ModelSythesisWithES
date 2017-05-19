using System;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Benchmarks
{
    public static class BenchmarkFactory
    {
        public static IBenchmark GetBenchmark(ExperimentParameters experimentParameters)
        {
            switch (experimentParameters.TypeOfBenchmark)
            {
                case ExperimentParameters.BenchmarkType.Balln:
                    return new BallnBenchmark(experimentParameters);
                case ExperimentParameters.BenchmarkType.Cuben:
                    return new CubenBenchmark(experimentParameters);
                case ExperimentParameters.BenchmarkType.Simplexn:
                    return new SimplexnBenchmark(experimentParameters);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
