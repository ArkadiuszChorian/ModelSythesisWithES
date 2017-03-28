using System;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Selection
{
    public static class SelectorsFactory
    {
        public static ISelector GetParentsSelector(ExperimentParameters experimentParameters)
        {
            switch (experimentParameters.TypeOfSurvivorsSelection)
            {
                case ExperimentParameters.SelectionType.Distinct:
                    return new ParentsRandomDistinctSelector(experimentParameters); ;
                case ExperimentParameters.SelectionType.Union:
                    return new ParentsRandomUnionSelector(experimentParameters);
                default:
                    throw new ArgumentOutOfRangeException();
            }            
        }

        public static ISurvivorsSelector GetSurvivorsSelector(ExperimentParameters experimentParameters)
        {
            switch (experimentParameters.TypeOfSurvivorsSelection)
            {
                case ExperimentParameters.SelectionType.Distinct:
                    return new SurvivorsDistinctSeletor(experimentParameters);
                case ExperimentParameters.SelectionType.Union:
                    return new SurvivorsUnionSelector(experimentParameters);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
