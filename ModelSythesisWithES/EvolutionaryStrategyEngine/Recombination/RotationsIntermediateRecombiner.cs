using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class RotationsIntermediateRecombiner : IRecombiner
    {
        public Solution Recombine(IList<Solution> parents, Solution child = null)
        {
            var vectorSize = parents.First().ObjectCoefficients.Length;

            if (child == null)
            {
                child = new Solution(parents.First());
            }

            for (var i = 0; i < vectorSize; i++)
            {
                for (var j = i + 1; j < vectorSize; j++)
                {
                    var averangeValue = parents.Sum(parent => parent.RotationsCoefficients[i][j]) / parents.Count;

                    child.RotationsCoefficients[i][j] = averangeValue;
                    child.RotationsCoefficients[j][i] = averangeValue;
                }
            }

            return child;
        }
    }
}
