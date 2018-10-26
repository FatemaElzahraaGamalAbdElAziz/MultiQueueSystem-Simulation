using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }
        public void GenerateDistribution(List<TimeDistribution> TimeDistributionTable)
        {
            TimeDistribution Last = new TimeDistribution();
            Last.Probability = 0;
            Last.MaxRange = 0;
            for (int i = 0; i < TimeDistributionTable.Count; i++)
            {
                TimeDistributionTable[i].SetCummProp(Last.Probability);
                TimeDistributionTable[i].SetRanges(Last.MaxRange + 1);
                Last = TimeDistributionTable[i];
            }
        }
        public void ServerDataGenerator(List<Server> Servers)
        {
            for (int i = 0; i < Servers.Count; i++)
            {
                GenerateDistribution(Servers[i].TimeDistribution);
            }
        }
        public int GetWithinRange(List<TimeDistribution> Table,int Random)
        {
            int result = 0;
            for(int i = 0; i < Table.Count; i++)
            {
                if (Random <= Table[i].MaxRange)
                {
                    result = Table[i].Time;
                    break;
                }
            }
            return result;
        }

        public int GetFirstFinishServer()
        {
            int min = int.MaxValue;
            int result = 0;
            for(int i = 0; i < Servers.Count; i++)
            {
                if (Servers[i].LastFinishTime < min)
                {
                    result = i;
                    min = Servers[i].LastFinishTime;
                }
            }
            return result;
        }
    }
}
