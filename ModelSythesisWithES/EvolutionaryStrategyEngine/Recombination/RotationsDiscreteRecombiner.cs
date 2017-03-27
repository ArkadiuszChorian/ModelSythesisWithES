using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class RotationsDiscreteRecombiner : IRecombiner
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
                    var chosenValue = parents[MersenneTwister.Instance.Next(parents.Count)].RotationsCoefficients[i][j];

                    child.RotationsCoefficients[i][j] = chosenValue;
                    child.RotationsCoefficients[j][i] = chosenValue;
                }
            }

            return child;
        }
    }
}
