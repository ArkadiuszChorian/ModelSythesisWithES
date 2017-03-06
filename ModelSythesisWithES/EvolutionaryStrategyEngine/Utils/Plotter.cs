using System;
using Accord.Controls;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Utils
{
    public static class Plotter
    {
        public static void Plot(Point[] positivePoints, Point[] negativePoints)
        {
            var points = new double[positivePoints.Length + negativePoints.Length][];

            Array.Copy(positivePoints.ToDoublesArray(), points, positivePoints.Length);
            Array.Copy(negativePoints.ToDoublesArray(), 0, points, positivePoints.Length, negativePoints.Length);

            var classes = new int[positivePoints.Length + negativePoints.Length];

            for (var i = 0; i < positivePoints.Length; i++)
            {
                classes[i] = 1;
            }

            for (var i = positivePoints.Length; i < classes.Length; i++)
            {
                classes[i] = -1;
            }

            ScatterplotBox.Show(points, classes);
        }
    }
}
