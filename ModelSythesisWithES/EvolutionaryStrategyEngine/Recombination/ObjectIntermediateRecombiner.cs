using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class ObjectIntermediateRecombiner : Recombiner
    {
        public ObjectIntermediateRecombiner(ExperimentParameters experimentParameters) : base(experimentParameters)
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
                child.ObjectCoefficients[i] = selectedParents.Sum(parent => parent.ObjectCoefficients[i]) / selectedParents.Count;
            }

            return child;
        }
    }
}
