using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Recombination
{
    public abstract class Recombiner : IRecombiner
    {
        protected Recombiner(ExperimentParameters experimentParameters)
        {
            NumberOfSolutionsToRecombine = (int)experimentParameters.PartOfPopulationToRecombine * experimentParameters.BasePopulationSize;
        }

        public int NumberOfSolutionsToRecombine { get; set; }

        protected IList<Solution> SelectParents(IList<Solution> parents)
        {
            var selectedParents = new HashSet<Solution>();
           
            while (selectedParents.Count < NumberOfSolutionsToRecombine)
            {
                selectedParents.Add(parents[MersenneTwister.Instance.Next(parents.Count)]);
            }

            return selectedParents.ToList();
        }

        public abstract Solution Recombine(IList<Solution> parents, Solution child = null);
    }
}
