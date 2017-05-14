using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class RotationsDiscreteRecombiner : Recombiner
    {
        public RotationsDiscreteRecombiner(ExperimentParameters experimentParameters) : base(experimentParameters)
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
                    //var chosenValue = selectedParents[MersenneTwister.Instance.Next(selectedParents.Count)].RotationsCoefficients[i][j];

                    //child.RotationsCoefficients[i][j] = chosenValue;
                    //child.RotationsCoefficients[j][i] = chosenValue;
                }
            }

            return child;
        }
    }
}
