using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    class PredictAndLearn
    {
        public int[] predict(int totaldepth, int totalballs)
        {

            string learningfile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\LearnToPredict.txt";


            List<int> pred = new List<int>();
            if (File.Exists(learningfile))
            {
                StreamReader sr = new StreamReader(learningfile);
                string line = "";

                while ((line = sr.ReadLine()) != null)
                {
                    string[] getdata = line.Split(',');
                    if (Convert.ToInt32(getdata[0]) == totaldepth && Convert.ToInt32(getdata[1]) == totalballs)
                    {
                        for (int i = 2; i < getdata.Length; i++)
                            pred.Add(Convert.ToInt32(getdata[i]));


                        break;
                    }
                }

                sr.Close();
            }

            int[] records = new int[pred.Count];
            int j = 0;
            foreach (var dt in pred)
            {
                records[j] = dt;
                j++;
            }

            return records;
        }

        public void Learn(int totaldepth, int totalballs, int[] EmptyContainers)
        {
            string learningfile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\LearnToPredict.txt";
            StreamWriter sw = new StreamWriter(learningfile, true);
            string output = Convert.ToString(totaldepth) + "," + Convert.ToString(totalballs) + ",";

            for (int i = 0; i < EmptyContainers.Length; i++)
            {
                if (EmptyContainers[i] == 0)
                {
                    output = output + Convert.ToString(i);
                    if (i != EmptyContainers.Length - 1)
                        output = output + ",";

                }

            }

            sw.WriteLine(output);
            sw.Close();
        }
    }
}
