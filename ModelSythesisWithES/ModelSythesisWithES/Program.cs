namespace ModelSythesisWithES
{
    class Program
    {
        static void Main(string[] args)
        {
            //const int numberOfMeasurePoints = 100;
            //const int numberOfDimensions = 2;
            //const int numberOfRestrictions = 5;
            //const int numberOfRestrictionCoefficients = numberOfDimensions + 1;
            //const int numberOfIterations = 100;

            //var objectVectorSize = numberOfRestrictionCoefficients * numberOfRestrictions;
            //var globalLearningRate = 1 / Math.Sqrt(2 * objectVectorSize);
            //var individualLearningRate = 1 / Math.Sqrt(2 * Math.Sqrt(objectVectorSize));
            //var stepThreshold = 0.005;
            //var rotationAngle = 5 * Math.PI / 180;          
            //var typeOfMutation = AlgorithmParameters.MutationType.UncorrelatedNSteps;
            //var populationSize = 100;
            //var numberOfParentsSolutionsToSelect = populationSize;
            //var numberOfSurvivorsSolutionsToSelect = populationSize;

            //var algorithmParameters = new AlgorithmParameters(globalLearningRate, individualLearningRate, stepThreshold,
            //    rotationAngle, objectVectorSize, populationSize, numberOfParentsSolutionsToSelect,
            //    numberOfSurvivorsSolutionsToSelect, typeOfMutation);        
               
            //var measurePoints = new double[numberOfMeasurePoints][];

            //for (var i = 0; i < numberOfMeasurePoints; i++)
            //{
            //    measurePoints[i] = new double[numberOfDimensions];

            //    for (var j = 0; j < numberOfDimensions; j++)
            //    {
            //        measurePoints[i][j] = MersenneTwister.Instance.NextDouble();
            //    }
            //}

            //var engine = new EvolutionaryStrategyEngine.EvolutionaryStrategyEngine(algorithmParameters, measurePoints);

            //engine.RunExperiment(numberOfIterations);

            //var streamWriter = new StreamWriter("results.csv");

            //foreach (var measurePoint in measurePoints)
            //{
            //    foreach (var coordinate in measurePoint)
            //    {
            //        streamWriter.Write(coordinate);
            //        streamWriter.Write(";");
            //    }

            //    streamWriter.Write("\n");
            //}

            //var bestSolution = engine.Population[0];

            //for (var j = 0; j < numberOfRestrictions * numberOfRestrictionCoefficients; j += numberOfRestrictionCoefficients)
            //{
            //    for (var k = j; k < numberOfRestrictionCoefficients + j; k++)
            //    {
            //        streamWriter.Write(bestSolution.ObjectCoefficients[k]);
            //        streamWriter.Write(";");
            //    }

            //    streamWriter.Write("\n");
            //}

            //streamWriter.Close();

            //Console.WriteLine("DONE!");
            //Console.ReadKey();
        }
    }
}
