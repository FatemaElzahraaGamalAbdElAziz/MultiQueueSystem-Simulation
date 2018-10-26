using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.AvailableList = new List<Server>();
        }

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }
        List<Server> AvailableList;
        public struct Waiting
        {
            public int Count;
            public int WaitingTime;
        }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }
        public void GenerateDistribution(List<TimeDistribution> TimeDistributionTable)
        {
            TimeDistribution Last = new TimeDistribution();
            Last.CummProbability = 0;
            Last.MaxRange = 0;
            for (int i = 0; i < TimeDistributionTable.Count; i++)
            {
                TimeDistributionTable[i].SetCummProp(Last.CummProbability);
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
        public void ReadInput(ReadFile Reader)
        {
            Reader.Read("E:\\FCIS 4th Year\\1st Sem\\Simulation\\Template\\MultiQueueSimulation\\MultiQueueSimulation\\TestCases\\TestCase1.txt");
            NumberOfServers = Reader.Input.NumberOfServers;
            StoppingNumber = Reader.Input.StoppingNumber;
            StoppingCriteria = (MultiQueueModels.Enums.StoppingCriteria)Reader.Input.StoppingCriterea;
            SelectionMethod = (MultiQueueModels.Enums.SelectionMethod)Reader.Input.SelectionMethod;
            InterarrivalDistribution = Reader.InterarrivalDistribution;
            Servers = Reader.Input.ServersList;
            GenerateDistribution(InterarrivalDistribution);
            ServerDataGenerator(Servers);
        }
        public bool CheckIdle(int ArrivalTime)
        {

            bool result = false;
            for(int i = 0; i < Servers.Count; i++)
            {
                if (ArrivalTime >= Servers[i].LastFinishTime)
                {
                    AvailableList.Add(Servers[i]);
                    result = true;
                }
            }
            return result;
        }
        public void Simulate()
        {
            if (StoppingCriteria == (MultiQueueModels.Enums.StoppingCriteria.NumberOfCustomers))
            {
                int CurrentCustomer = 1;
                SimulationCase OldCase = new SimulationCase();
                Random random = new Random();
                Random ServiceRandom = new Random();
                Random ServerRandom = new Random();
                OldCase.ArrivalTime = 0;
                OldCase.InterArrival = 0;
                while (CurrentCustomer <= StoppingNumber)
                {
                    //Our Main code!
                    SimulationCase NewCase = new SimulationCase();
                    NewCase.CustomerNumber = CurrentCustomer;
                    NewCase.RandomInterArrival = random.Next(1, 100);
                    NewCase.InterArrival = GetWithinRange(InterarrivalDistribution, NewCase.RandomInterArrival);
                    if (CurrentCustomer == 1)
                        NewCase.ArrivalTime = OldCase.ArrivalTime;
                    else 
                        NewCase.ArrivalTime = OldCase.ArrivalTime + NewCase.InterArrival;
                    //Server
                    int ServerIndex = 0;
                    if (CheckIdle(NewCase.ArrivalTime)) //Needs to change!!
                    {
                        NewCase.TimeInQueue = 0;
                        if (SelectionMethod == Enums.SelectionMethod.HighestPriority)
                        {
                            for (int i = 0; i < Servers.Count; i++)
                            {
                                if (Servers[i].LastFinishTime <= NewCase.ArrivalTime)
                                {
                                    NewCase.AssignedServer = Servers[i];
                                    ServerIndex = i;
                                    break;
                                }
                            }
                        }
                        else if (SelectionMethod == Enums.SelectionMethod.Random)
                        {
                            int RandomServer = ServerRandom.Next(0, AvailableList.Count - 1);
                            NewCase.AssignedServer = AvailableList[RandomServer];
                            ServerIndex = AvailableList[RandomServer].ID-1;
                        }
                        NewCase.ServerIndex = ServerIndex+1;
                        NewCase.StartTime = NewCase.ArrivalTime;
                        NewCase.RandomService = ServiceRandom.Next(1, 100);
                        NewCase.ServiceTime = GetWithinRange(NewCase.AssignedServer.TimeDistribution, NewCase.RandomService);
                        NewCase.EndTime = NewCase.StartTime + NewCase.ServiceTime;
                        Servers[ServerIndex].LastFinishTime = NewCase.EndTime;
                    }
                    else
                    {
                        //Time in queue
                        ServerIndex = GetFirstFinishServer();
                        NewCase.AssignedServer = Servers[ServerIndex];
                        NewCase.TimeInQueue = NewCase.AssignedServer.LastFinishTime - NewCase.ArrivalTime;
                        NewCase.StartTime = NewCase.AssignedServer.LastFinishTime;
                        NewCase.ServiceTime = GetWithinRange(NewCase.AssignedServer.TimeDistribution, NewCase.RandomService);
                        NewCase.EndTime = NewCase.StartTime + NewCase.ServiceTime;
                        Servers[ServerIndex].LastFinishTime = NewCase.EndTime;
                    }
                    SimulationTable.Add(NewCase);
                    OldCase = NewCase;
                    CurrentCustomer++;
                }
            }
            else //Where is the time limit input
            {

            }
            //Don't forget PerformanceMeasures
            //System.PerformanceMeasures
            MessageBox.Show("End of Simulation");
        }

        public Waiting WaitingCustomers()
        {
            int count = 0;
            int WaitingTime = 0;
            for(int i = 0; i < SimulationTable.Count; i++)
            {
                if (SimulationTable[i].TimeInQueue != 0)
                {
                    count++;
                    WaitingTime += SimulationTable[i].TimeInQueue;
                }
            }
            Waiting Result;
            Result.Count = count;
            Result.WaitingTime = WaitingTime;
            return Result;
        }
    }
}
