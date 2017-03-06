using System;
using System.Collections.Generic;
using Accord.Controls;
using Accord.Statistics.Visualizations;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.PointsGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvolutionaryStrategyEngineTests
{
    [TestClass]
    public class PointsGeneration
    {
        [TestMethod]
        public void PositiveMeasurePointsGenerationTest()
        {
            var algorithmParameters = new AlgorithmParameters
            {
                DefaultDomainLimit = Tuple.Create(-100.0, 100.0),
                NumberOfDimensions = 2
            };
            var domain = new Domain(algorithmParameters);
            var positiveMeasurePointsGenerator = new PositiveMeasurePointsGenerator(domain);

            //Constraints fits the triangle on the plot
            var constraints = new List<Constraint>
            {
                new LinearConstraint(new []{1.0, 0}, 10),
                new LinearConstraint(new []{1.0, -1.0}, 0),
                new LinearConstraint(new []{0, -1.0}, 10)
            };

            var points = positiveMeasurePointsGenerator.GeneratePoints(50, constraints);

            var plot = new Scatterplot();
            var x = new double[points.Length];
            var y = new double[points.Length];

            for (var i = 0; i < points.Length; i++)
            {
                x[i] = points[i].Coordinates[0];
                y[i] = points[i].Coordinates[1];
            }

            plot.Compute(x, y);
            ScatterplotBox.Show(plot);

            //var streamWriter = new StreamWriter("PositivePointsGenerationTest.txt");

            //foreach (var point in points)
            //{
            //    foreach (var coordinate in point.Coordinates)
            //    {
            //        streamWriter.Write(coordinate + " ");
            //    }
            //    streamWriter.Write("\n");
            //}

            //streamWriter.Close();
        }
    }
}
