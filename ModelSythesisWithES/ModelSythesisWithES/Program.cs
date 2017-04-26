using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvolutionaryStrategyEngine.Constraints;
using EvolutionaryStrategyEngine.DistanceMeasuring;
using EvolutionaryStrategyEngine.Engine;
using EvolutionaryStrategyEngine.Evaluation;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.PointsGeneration;
using EvolutionaryStrategyEngine.Solutions;
using EvolutionaryStrategyEngine.Utils;
using EvolutionaryStrategyEngine.Visualization;
using OxyPlot;

namespace ModelSythesisWithES
{
    class Program
    {
        private const string ResultsPath = "../../TestsResults/";

        static void Main(string[] args)
        {
            //var plotThread = new Thread(() =>
            //{
            //    Application.EnableVisualStyles();
            //    Application.Run(new PlotForm());
            //});

            //plotThread.SetApartmentState(ApartmentState.STA);
            //plotThread.Start();

            var experimentParameters = new ExperimentParameters(2, 10, 
                typeOfMutation: ExperimentParameters.MutationType.UncorrelatedNSteps,
                stepThreshold: 0.1, numberOfGenerations: 100,
                basePopulationSize: 60,
                offspringPopulationSize: 400,
                globalLerningRate: 1 / Math.Sqrt(2 * 2),
                //globalLerningRate: 0.7,
                individualLearningRate: 1 / Math.Sqrt(2 * Math.Sqrt(2)));
                //individualLearningRate: 0.8);

            var constraints = new List<Constraint>
            {
                //new LinearConstraint(new []{1.0, 0}, 10.0),
                //new LinearConstraint(new []{0, -1.0}, 10.0),
                new LinearConstraint(new []{-1.0, 1.0}, 20.0),
                new LinearConstraint(new []{1.0, -1.0}, 20.0),

                new LinearConstraint(new []{-1.0, -1.0}, 20.0),
                new LinearConstraint(new []{1.0, 1.0}, 20.0)
            };

            var constraints2 = new List<Constraint>
            {
                new LinearConstraint(new []{1.0, 0}, 20),
                new LinearConstraint(new []{-1.0, 0}, 20),
                new LinearConstraint(new []{0, 1.0}, 20),
                new LinearConstraint(new []{0, -1.0}, 20)
            };

            experimentParameters.ConstraintsToPointGeneration = constraints;

            //var engine = new EngineFactory().GetEngine<NStepsMutationSolution>(experimentParameters);
            var engine = EngineFactory.GetEngine(experimentParameters);
            engine.RunExperiment();

            var bestSolutionConstraints = engine.BasePopulation.First().GetConstraints(experimentParameters);
            var bestSolutionSamples = new PositiveMeasurePointsGenerator(new Domain(experimentParameters)).GeneratePoints(100, bestSolutionConstraints);

            var initialSolutionConstraints = engine.InitialPopulation.First().GetConstraints(experimentParameters);
            //var initialSolutionSamples = new PositiveMeasurePointsGenerator(new Domain(experimentParameters)).GeneratePoints(100, bestSolutionConstraints);        

            var evaluator = (Evaluator)engine.Evaluator;
            var visualization = new Visualization();

            Console.WriteLine("Before plot!");

            //visualization.AddClusters(evaluator.PositiveMeasurePoints, evaluator.NegativeMeasurePoints).AddModelPlot(bestSolutionConstraints, "asd").AddModelPlot(constraints, "asd").Show();
            visualization
                .AddNextPlot()
                .AddPoints(evaluator.PositiveMeasurePoints, OxyColors.Green)
                .AddPoints(evaluator.NegativeMeasurePoints, OxyColors.Red)
                .AddConstraints(constraints, OxyPalettes.Rainbow)
                .AddNextPlot()
                .AddPoints(evaluator.PositiveMeasurePoints, OxyColors.Green)
                .AddPoints(evaluator.NegativeMeasurePoints, OxyColors.Red)
                .AddConstraints(bestSolutionConstraints, OxyPalettes.Rainbow)
                .Show();

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
