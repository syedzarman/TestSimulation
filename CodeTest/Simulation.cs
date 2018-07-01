using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    class Simulation
    {
        public int[] SimulateToGetEmptyContainer(int totaldepth, int totalballs, int totalgates, int totalcontainers)
        {
            int[] gate = new int[totalgates];
            int[] containers = new int[totalcontainers];

            for (int i = 0; i < totalgates; i++)
                gate[i] = 0;

            if (totaldepth == 0)
                return containers;

            for (int i = 0; i < totalballs; i++)
            {
                int current_gate = 0;
                for (int j = 0; j <= totaldepth; j++)
                {
                    if (gate[current_gate] == 0)
                    {
                        gate[current_gate] = 1;
                        current_gate = current_gate * 2;
                        if (current_gate == 0)
                            current_gate = 1;
                    }
                    else
                    {
                        gate[current_gate] = 0;
                        current_gate = (current_gate * 2) + 1;
                    }

                }

                containers[current_gate - totalcontainers] = 1;

            }

            return containers;
        }
    }
}
