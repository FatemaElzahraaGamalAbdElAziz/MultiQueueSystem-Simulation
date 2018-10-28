using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
            LastFinishTime = 0;
            AverageServiceTime = 0;
            Utilization = 0;
        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; }
        public decimal Utilization { get; set; }
        public int LastFinishTime { get; set; }
        public List<TimeDistribution> TimeDistribution;
        //optional
        public int TotalServedCustomers;
        public int TotalIdleTime;
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }

        public void CalcTotalWorkingTime(SimulationSystem system)
        {
            for (int i = 0; i < system.SimulationTable.Count; i++)
            {

                if (system.SimulationTable[i].ServerIndex == ID)
                {
                    TotalWorkingTime += system.SimulationTable[i].ServiceTime;
                    TotalServedCustomers++;
                }
            }

        }
        public void CalcAvgServiceTime()
        {
            if (TotalServedCustomers != 0)
            {
                AverageServiceTime = (decimal)TotalWorkingTime / TotalServedCustomers;
            }
            else { AverageServiceTime = 0; }
        }
        public void CalcIdleProb(SimulationSystem system)
        {
            TotalIdleTime = system.TotalSimulationTime - TotalWorkingTime;
            if (system.TotalSimulationTime != 0)
            {
                IdleProbability = (decimal)TotalIdleTime / system.TotalSimulationTime;
            }
            else { IdleProbability = 0; }



            
        
    }
        public void CalcUtilization(SimulationSystem system)
        {
            if (system.TotalSimulationTime != 0)
            {
                Utilization = (decimal)TotalWorkingTime / system.TotalSimulationTime;
            }
            else { Utilization = 0; }
            
        }
    }
}
