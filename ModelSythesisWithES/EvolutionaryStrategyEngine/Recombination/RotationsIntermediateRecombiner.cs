using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class RotationsIntermediateRecombiner : Recombiner
    {
        public RotationsIntermediateRecombiner(ExperimentParameters experimentParameters) : base(experimentParameters)
        {
        }

        public override Solution Recombine(IList<Solution> parents, Solution child = null)
        {
            var selectedParents = SelectParents(parents);
            var vectorSize = selectedParents.First().ObjectCoefficients.Length;

            if (child == null)
            {
                child = new Solution(selectedParents.First());
            }

            for (var i = 0; i < vectorSize; i++)
            {
                for (var j = i + 1; j < vectorSize; j++)
                {
                    var averangeValue = selectedParents.Sum(parent => parent.RotationsCoefficients[i][j]) / selectedParents.Count;

                    child.RotationsCoefficients[i][j] = averangeValue;
                    child.RotationsCoefficients[j][i] = averangeValue;
                }
            }

            return child;
        }
    }
}
