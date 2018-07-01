using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    class GetDataRecords
    {
        public int GetTotalGates(int totaldepth)
        {
            int totalgates = 0;
            int tempgate = 1;
            for (int i = 1; i <= totaldepth; i++)
            {
                tempgate = tempgate * 2;
                totalgates = totalgates + tempgate;
            }

            if (totaldepth >= 1)
                totalgates = totalgates + 1;


            return totalgates;
        }

        public int GetTotalContainers(int totaldepth)
        {
            int container = 1;
            for (int i = 0; i < totaldepth; i++)
                container = container * 2;

            if (totaldepth == 0)
                return 0;
            else
                return container;
        }

    }
}
