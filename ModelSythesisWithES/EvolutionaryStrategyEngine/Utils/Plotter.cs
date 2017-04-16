using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Accord.Controls;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.PointsGeneration;

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

        public static void Plot(Point[] points)
        {
            ScatterplotBox.Show(points.ToDoublesArray());
        }

        public static void PlotLines(List<Constraint> constraints, int minValue, int maxValue)
        {
            ScatterplotBox.Show(constraints.Get2DLinesFromConstraints(minValue, maxValue));
        }

        public static void PlotLinesWithPointsInside(Point[] points, List<Constraint> constraints, int minValue,
            int maxValue)
        {
            var mergedPoints = points.ToDoublesArray().Concat(constraints.Get2DLinesFromConstraints(minValue, maxValue));

            ScatterplotBox.Show(mergedPoints.ToArray());
        }
    }
}
