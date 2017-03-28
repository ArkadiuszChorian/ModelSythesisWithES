using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Recombination
{
    public class OsmStdDevsDiscreteRecombiner : Recombiner
    {
        public OsmStdDevsDiscreteRecombiner(ExperimentParameters experimentParameters) : base(experimentParameters)
        {
        }

        public override Solution Recombine(IList<Solution> parents, Solution child = null)
        {
            var selectedParents = SelectParents(parents);

            if (child == null)
            {
                child = new Solution(selectedParents.First());
            }

            child.OneStepStdDeviation = selectedParents[MersenneTwister.Instance.Next(selectedParents.Count)].OneStepStdDeviation;

            return child;
        }
    }
}
