using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool correct_value = true;
            int totalDepth = 0;
            int totalballs = 0;
            string getinput = "";
            
            //Loop that will Exit once Correct values are Entered:
            while (correct_value)
            {
                Console.WriteLine("Please Enter Total Depth: ");
                getinput = Console.ReadLine();

                if (int.TryParse(getinput, out totalDepth))
                {
                    while (correct_value)
                    {
                        Console.WriteLine("Please Enter Total Balls: ");
                        getinput = Console.ReadLine();

                        if (int.TryParse(getinput, out totalballs))
                        {
                            correct_value = false;
                        }
                        else
                        {
                            Console.WriteLine("Please Enter Valid Value.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Value.");
                }
            }

            string TestTimeFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\TestTime.txt";
            StreamWriter sw = new StreamWriter(TestTimeFile);
            sw.WriteLine("Start of Test: " + DateTime.Now.ToString("dd/MM/yyyy HHmmss"));

            GetDataRecords getdata = new GetDataRecords(); //Object that contains Functions of all data calculations.
            PredictAndLearn predlearn = new PredictAndLearn(); //Object that contains Functions of Predict & Learn.
            Simulation sim = new Simulation(); //Object that contains Simulation of Depth VS Balls
            CompareContainers compc = new CompareContainers(); //Object to compare Prediction with Simulation.
                
            int totalgates = getdata.GetTotalGates(totalDepth); //Calculate total number of Gates, as per the Depth.
            int totalcontainers = getdata.GetTotalContainers(totalDepth); //Calculate total number of Containers. Containers will be represented by Numbers
                                                                           // instead of Alphabets.

            int[] predictedrecords = predlearn.predict(totalDepth, totalballs); //Get Predictions by considering any old Simulations/Records.

            bool predictionfound = predictedrecords.Length > 0; //Check if any prediction was found.
            int[] allcontainsers = sim.SimulateToGetEmptyContainer(totalDepth, totalballs, totalgates, totalcontainers);

            if(predictionfound == false)
                predlearn.Learn(totalDepth, totalballs, allcontainsers); //If Prediction not found, then Learn the current simulation
                                                                        // for Future Predictions.

            compc.CompareEmptyContainers(allcontainsers, predictedrecords); //Compare the Simulation Results with the Predictions

            sw.WriteLine("End of Test: " + DateTime.Now.ToString("dd/MM/yyyy HHmmss"));
            sw.Close();
        }
        
    }
}
