using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Utils
{
    public static class Extensions
    {
        public static double[][] ToDoublesArray(this Point[] points)
        {
            var array = new double[points.Length][];

            for (var i = 0; i < points.Length; i++)
            {
                array[i] = points[i].Coordinates;
            }

            return array;
        }
    }
}
