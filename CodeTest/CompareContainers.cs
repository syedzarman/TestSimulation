using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    class CompareContainers
    {
        public void CompareEmptyContainers(int[] containers, int[] predictions)
        {
            bool NoContainer = false;
            bool NoEmptyContainer = false;
            Console.WriteLine("Following is the Resule of Simulation:");

            if (containers.Length > 0)
            {
                Console.WriteLine("Container Numbers that are Empty:");
                bool emptycontainerexists = false;
                for (int i = 0; i < containers.Length; i++)
                {
                    if (containers[i] == 0)
                    {
                        //char c = Convert.ToChar(i + 65);
                        Console.Write(i);
                        if (containers.Length - 1 != i)
                            Console.Write(",");

                        emptycontainerexists = true;
                    }

                }

                Console.WriteLine("");

                if (emptycontainerexists == false)
                {
                    Console.WriteLine("NONE. All Containers Gets a Ball.");
                    NoEmptyContainer = true;
                }

            }
            else
            {
                Console.WriteLine("No Containers Exists");
                NoContainer = true;
            }


            bool predictionmatches = true;
            Console.WriteLine("Following are the Predictions:");

            if (predictions.Length > 0)
            {
                Console.WriteLine("Container Numbers that are Predicted Empty:");
                bool emptycontainerexists = false;
                for (int i = 0; i < predictions.Length; i++)
                {

                    //char c = Convert.ToChar(i + 65);
                    Console.Write(predictions[i]);
                    if (predictions.Length - 1 != i)
                        Console.Write(",");

                    if (containers[predictions[i]] != 0)
                        predictionmatches = false;

                    emptycontainerexists = true;


                }
                Console.WriteLine("");
                if (emptycontainerexists == false)
                {
                    Console.WriteLine("NONE. All Containers Gets a Ball.");
                    predictionmatches = NoEmptyContainer;
                }

            }
            else
            {
                Console.WriteLine("No Containers Exists");
                predictionmatches = NoContainer;
            }


            Console.WriteLine("Prediction Matches with Result: " + predictionmatches);

            Console.ReadLine();
        }
    }
}
