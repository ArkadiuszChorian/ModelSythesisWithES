using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class ObjectDiscreteRecombiner<T> : IRecombiner<T> where T : Solution, new()
    {
        public T Recombine(IList<T> parents, T child = null)
        {
            var vectorSize = parents.First().ObjectCoefficients.Length;

            if (child == null)
            {
                child = new T {ObjectCoefficients = new double[vectorSize]};
            }

            for (var i = 0; i < vectorSize; i++)
            {
                child.ObjectCoefficients[i] = parents[MersenneTwister.Instance.Next(parents.Count)].ObjectCoefficients[i];
            }

            return child;
        }
    }
}
