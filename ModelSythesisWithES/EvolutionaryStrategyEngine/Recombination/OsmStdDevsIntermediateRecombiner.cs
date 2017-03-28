using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class OsmStdDevsIntermediateRecombiner : Recombiner
    {
        public OsmStdDevsIntermediateRecombiner(ExperimentParameters experimentParameters) : base(experimentParameters)
        {
        }

        public override Solution Recombine(IList<Solution> parents, Solution child = null)
        {
            var selectedParents = SelectParents(parents);

            if (child == null)
            {
                child = new Solution(selectedParents.First());
            }

            child.OneStepStdDeviation = selectedParents.Sum(parent => parent.OneStepStdDeviation) / selectedParents.Count;

            return child;
        }
    }
}
