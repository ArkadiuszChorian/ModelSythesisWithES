using System;
using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.DistanceMeasuring;
using EvolutionaryStrategyEngine.Engine;
using EvolutionaryStrategyEngine.Evaluation;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.PointsGeneration;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;

namespace ModelSythesisWithES
{
    class Program
    {
        private const string ResultsPath = "../../TestsResults/";

        static void Main(string[] args)
        {
            var experimentParameters = new ExperimentParameters(2, 10, 
                typeOfMutation: ExperimentParameters.MutationType.UncorrelatedNSteps,
                stepThreshold: 0.0001);

            var constraints = new List<Constraint>
            {
                //new LinearConstraint(new []{1.0, 0}, 10.0),
                //new LinearConstraint(new []{0, -1.0}, 10.0),
                new LinearConstraint(new []{-1.0, 1.0}, 20.0),
                new LinearConstraint(new []{1.0, -1.0}, 20.0)
            };

            var constraints2 = new List<Constraint>
            {
                new LinearConstraint(new []{1.0, 0}, 20),
                new LinearConstraint(new []{-1.0, 0}, 20),
                new LinearConstraint(new []{0, 1.0}, 20),
                new LinearConstraint(new []{0, -1.0}, 20)
            };

            experimentParameters.ConstraintsToPointGeneration = constraints;

            var engine = new EngineFactory().GetEngine<NStepsMutationSolution>(experimentParameters);
            engine.RunExperiment();

            var bestSolutionConstraints = engine.Population.First().GetConstraints(experimentParameters);
            var bestSolutionSamples = new PositiveMeasurePointsGenerator(new Domain(experimentParameters)).GeneratePoints(100, bestSolutionConstraints);
            var evaluator = (Evaluator)engine.Evaluator;

            Plotter.Plot(evaluator.PositiveMeasurePoints, evaluator.NegativeMeasurePoints);
            Plotter.Plot(bestSolutionSamples);

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        private static void PointsGenerationTest()
        {
            var algorithmParameters = new ExperimentParameters(2, 10);
            var domain = new Domain(algorithmParameters);
            var positiveMeasurePointsGenerator = new PositiveMeasurePointsGenerator(domain);

            //Constraints fits the triangle on the plot
            var constraints = new List<Constraint>
            {
                //new LinearConstraint(new []{1.0, 0}, 10.0),
                //new LinearConstraint(new []{0, -1.0}, 10.0),
                new LinearConstraint(new []{-1.0, 1.0}, 20.0),
                new LinearConstraint(new []{1.0, -1.0}, 20.0)
            };

            var constraints2 = new List<Constraint>
            {
                new LinearConstraint(new []{1.0, 0}, 20),
                new LinearConstraint(new []{-1.0, 0}, 20),
                new LinearConstraint(new []{0, 1.0}, 20),
                new LinearConstraint(new []{0, -1.0}, 20)
            };

            var positiveMeasurePoints = positiveMeasurePointsGenerator.GeneratePoints(100, constraints);
            //var negativeMeasurePointsGenerator = new NegativeMeasurePointsGenerator(positiveMeasurePoints, new CanberraDistanceCalculator(), domain);
            var negativeMeasurePointsGenerator = new NegativeMeasurePointsGenerator(positiveMeasurePoints, new EuclideanDistanceCalculator(), domain);

            negativeMeasurePointsGenerator.CalculateNearestNeighbourDistances();
            var negativeMeasurePoints = negativeMeasurePointsGenerator.GeneratePoints(300);

            Plotter.Plot(positiveMeasurePoints, negativeMeasurePoints);


            //var streamWriter = new StreamWriter(ResultsPath + "PositivePoints.txt");

            //var positiveMeasurePoints = positiveMeasurePointsGenerator.GeneratePoints(100, constraints);

            //foreach (var positiveMeasurePoint in positiveMeasurePoints)
            //{
            //    foreach (var coordinate in positiveMeasurePoint.Coordinates)
            //    {
            //        streamWriter.Write(coordinate + ";");
            //    }
            //    streamWriter.Write("\n");
            //}

            //streamWriter.Close();

            //var positiveMeasurePointsPlot = new Scatterplot();
            //var x = new double[positiveMeasurePoints.Length];
            //var y = new double[positiveMeasurePoints.Length];

            //for (var i = 0; i < positiveMeasurePoints.Length; i++)
            //{
            //    x[i] = positiveMeasurePoints[i].Coordinates[0];
            //    y[i] = positiveMeasurePoints[i].Coordinates[1];
            //}

            //positiveMeasurePointsPlot.Compute(x, y);

            //ScatterplotBox.Show(positiveMeasurePointsPlot);

            //streamWriter = new StreamWriter(ResultsPath + "NegativePoints.txt");

            //var negativeMeasurePointsGenerator = new NegativeMeasurePointsGenerator(positiveMeasurePoints, new CanberraDistanceCalculator(), domain);
            //var negativeMeasurePointsGenerator = new NegativeMeasurePointsGenerator(positiveMeasurePoints, new EuclideanDistanceCalculator(), domain);

            //negativeMeasurePointsGenerator.CalculateNearestNeighbourDistances();
            //var negativeMeasurePoints = negativeMeasurePointsGenerator.GeneratePoints(300);

            //foreach (var negativeMeasurePoint in negativeMeasurePoints)
            //{
            //    foreach (var coordinate in negativeMeasurePoint.Coordinates)
            //    {
            //        streamWriter.Write(coordinate + ";");
            //    }
            //    streamWriter.Write("\n");
            //}

            //streamWriter.Close();

            //var negativeMeasurePointsPlot = new Scatterplot();
            //var x2 = new double[negativeMeasurePoints.Length];
            //var y2 = new double[negativeMeasurePoints.Length];

            //for (var i = 0; i < negativeMeasurePoints.Length; i++)
            //{
            //    x2[i] = negativeMeasurePoints[i].Coordinates[0];
            //    y2[i] = negativeMeasurePoints[i].Coordinates[1];
            //}

            //negativeMeasurePointsPlot.Compute(x2, y2);

            //ScatterplotBox.Show(negativeMeasurePointsPlot);
        }
    }
}
