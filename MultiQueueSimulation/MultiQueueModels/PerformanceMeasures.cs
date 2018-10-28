using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiQueueModels
{
    public class PerformanceMeasures
    {
        public decimal AverageWaitingTime { get; set; }
        public int MaxQueueLength { get; set; }
        public decimal WaitingProbability { get; set; }

        public void CalcServerPerformance(SimulationSystem system)
        {
            system.CalcTotalSimulationTime();
            for (int i = 0; i < system.Servers.Count; i++)
            {

                system.Servers[i].CalcTotalWorkingTime(system);
                system.Servers[i].CalcAvgServiceTime();
                system.Servers[i].CalcIdleProb(system);
                system.Servers[i].CalcUtilization(system);

            }

        }
        public void CalcSysPerformance(SimulationSystem system)
        {

            system.waitingInfo = system.WaitingCustomers();
            if (system.SimulationTable.Count!=0) {
                AverageWaitingTime = (decimal)system.waitingInfo.WaitingTime / system.SimulationTable.Count;
                WaitingProbability = (decimal)system.waitingInfo.Count / system.SimulationTable.Count; }
            else { AverageWaitingTime = 0;
                WaitingProbability = 0;
            }
            CalcMaxQueue(system);
            //MessageBox.Show("da fo2 " + MaxQueueLength.ToString());
        }

        public struct PAIR
        {
            public int first;
            public int second;
        }
        public void CalcMaxQueue(SimulationSystem system)
        {
            List<int> PartialSum = new List<int>();
            List<PAIR> Ranges = new List<PAIR>();
            
            int mx = -100000;
            for (int i = 0; i < system.SimulationTable.Count; i++)
            {
                int cur = system.SimulationTable[i].EndTime;
                if (mx < cur)
                {
                    mx = cur;
                }
                PAIR tmp;
                tmp.first = system.SimulationTable[i].ArrivalTime;
                tmp.second = system.SimulationTable[i].StartTime;
                if(tmp.first != tmp.second) Ranges.Add(tmp);
            }
            for (int i = 0; i <= mx; i++)
            {
                PartialSum.Add(0);
            }
            for (int i = 0; i < Ranges.Count; i++)
            {
                PartialSum[Ranges[i].first]++;
                PartialSum[Ranges[i].second + 1]--;
            }
             MaxQueueLength = -100000;
            for (int i = 1; i < PartialSum.Count; i++)
            {
                PartialSum[i] += PartialSum[i - 1];
                if (MaxQueueLength < PartialSum[i])
                {
                    MaxQueueLength = PartialSum[i];
                }
            }
            //MessageBox.Show("da ta7t " + MaxQueueLength.ToString());

        }

    }
}
