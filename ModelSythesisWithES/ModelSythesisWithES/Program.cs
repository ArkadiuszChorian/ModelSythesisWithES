using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using OxyPlot;

namespace ModelSythesisWithES
{
    class Program
    {
        static void Main(string[] args)
        {
            var stoper = new Stopwatch();
            stoper.Start();

            var experimentParameters = new ExperimentParameters(2, 10,
                typeOfMutation: ExperimentParameters.MutationType.Correlated,
                typeOfBenchmark: ExperimentParameters.BenchmarkType.Simplexn,
                stepThreshold: 0.1, numberOfGenerations: 300,
                basePopulationSize: 15,
                //basePopulationSize: 3,
                offspringPopulationSize: 100,
                //offspringPopulationSize: 20,
                globalLerningRate: 1 / Math.Sqrt(2 * 2),
                //globalLerningRate: 0.7,
                individualLearningRate: 1 / Math.Sqrt(2 * Math.Sqrt(2)),
                //individualLearningRate: 0.8,
                numberOfPositiveMeasurePoints: 300,
                numberOfNegativeMeasurePoints: 300,
                ballnBoundaryValue: 10
                );

            var experimentParameters3 = new ExperimentParameters(2, 10, 
                typeOfMutation: ExperimentParameters.MutationType.Correlated,
                stepThreshold: 0.1, numberOfGenerations: 300,
                basePopulationSize: 30,
                //basePopulationSize: 3,
                offspringPopulationSize: 200,
                //offspringPopulationSize: 20,
                globalLerningRate: 1 / Math.Sqrt(2 * 2),
                //globalLerningRate: 0.7,
                individualLearningRate: 1 / Math.Sqrt(2 * Math.Sqrt(2)),
                //individualLearningRate: 0.8,
                numberOfPositiveMeasurePoints: 300,
                numberOfNegativeMeasurePoints: 300
                );           

            var experimentParameters2 = new ExperimentParameters(2, 10,
                typeOfMutation: ExperimentParameters.MutationType.Correlated,
                stepThreshold: 0.1, numberOfGenerations: 10,
                basePopulationSize: 15,
                //basePopulationSize: 3,
                offspringPopulationSize: 100,
                //offspringPopulationSize: 20,
                globalLerningRate: 1 / Math.Sqrt(2 * 2),
                //globalLerningRate: 0.7,
                individualLearningRate: 1 / Math.Sqrt(2 * Math.Sqrt(2)),
                numberOfPositiveMeasurePoints: 100,
                numberOfNegativeMeasurePoints: 100
                );

            var visualization = new Visualization();

            var constraints = new List<Constraint>
            {
                new Linear2DConstraint(1, 60, Linear2DConstraint.InequalityValues.UnderLine),
                new Linear2DConstraint(1, 0, Linear2DConstraint.InequalityValues.OverLine),
                new Linear2DConstraint(-2, 60, Linear2DConstraint.InequalityValues.UnderLine),
                new Linear2DConstraint(-2, 0, Linear2DConstraint.InequalityValues.OverLine)
            };

            var constraints2 = new List<Constraint>
            {
                //new LinearConstraint(new []{1.0, 0}, 10.0),
                //new LinearConstraint(new []{0, -1.0}, 10.0),
                new LinearConstraint(new []{-1.0, 1.0}, 20.0),
                new LinearConstraint(new []{1.0, -1.0}, 20.0),

                new LinearConstraint(new []{-1.0, -1.0}, 20.0),
                new LinearConstraint(new []{1.0, 1.0}, 20.0)
            };

            var constraints3 = new List<Constraint>
            {
                new LinearConstraint(new []{1.0, 0}, 20),
                new LinearConstraint(new []{-1.0, 0}, 20),
                new LinearConstraint(new []{0, 1.0}, 20),
                new LinearConstraint(new []{0, -1.0}, 20)
            };

            experimentParameters.ConstraintsToPointsGeneration = constraints;
            
            var engine = EngineFactory.GetEngine(experimentParameters);
            engine.RunExperiment();

            var bestSolutionConstraints = engine.BasePopulation.First().GetConstraints(experimentParameters);

            var evaluator = (Evaluator)engine.Evaluator;

            visualization
                .AddNextPlot()
                .AddPoints(evaluator.PositiveMeasurePoints, OxyColors.Green)
                .AddPoints(evaluator.NegativeMeasurePoints, OxyColors.Red)
                //.AddConstraints(constraints, OxyPalettes.Rainbow)
                .AddConstraints(engine.Benchmark.Constraints, OxyPalettes.Rainbow)
                .AddNextPlot()
                .AddPoints(evaluator.PositiveMeasurePoints, OxyColors.Green)
                .AddPoints(evaluator.NegativeMeasurePoints, OxyColors.Red)
                .AddConstraints(bestSolutionConstraints, OxyPalettes.Rainbow)
                //.AddNextPlot()
                //.AddPoints(evaluator.PositiveMeasurePoints, OxyColors.Green)
                //.AddPoints(evaluator.NegativeMeasurePoints, OxyColors.Red)
                //.AddConstraints(engine.InitialPopulation.First().GetConstraints(experimentParameters), OxyPalettes.Rainbow)
                .Show();

            //var engine2 = engine as CmEngineWithoutRecombination;

            //for (var i = 0; i < engine2.OneSolutionHistory.Count; i++)
            //{
            //    visualization
            //        .AddNextPlot(title: "Step " + i)
            //        .AddPoints(evaluator.PositiveMeasurePoints, OxyColors.Green)
            //        .AddConstraints(engine2.OneSolutionHistory[i].GetConstraints(experimentParameters), OxyPalettes.Rainbow);
            //}

            //visualization.Show();

            stoper.Stop();
            Console.WriteLine("Done!");
            Console.WriteLine("=== Time ===");
            Console.WriteLine("SEC = " + stoper.Elapsed.TotalSeconds);
            Console.WriteLine("MIN = " + stoper.Elapsed.TotalMinutes);
            Console.WriteLine("MIN = " + stoper.Elapsed.Minutes);
            Console.ReadKey();
        }
    }
}
