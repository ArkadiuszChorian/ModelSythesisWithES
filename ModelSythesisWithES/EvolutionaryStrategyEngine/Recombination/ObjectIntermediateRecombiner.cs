using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class ObjectIntermediateRecombiner<T> : IRecombiner<T> where T : Solution, new()
    {
        public T Recombine(IList<T> parents, T child = default(T))
        {
            var vectorSize = parents.First().ObjectCoefficients.Length;

            if (child == null)
            {
                child = new T { ObjectCoefficients = new double[vectorSize] };
            }

            for (var i = 0; i < vectorSize; i++)
            {
                child.ObjectCoefficients[i] = parents.Sum(parent => parent.ObjectCoefficients[i]) / parents.Count;
            }

            return child;
        }
    }
}
