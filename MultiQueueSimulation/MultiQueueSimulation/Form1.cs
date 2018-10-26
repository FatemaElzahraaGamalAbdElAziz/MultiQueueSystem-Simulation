using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        public SimulationSystem System;
        public ReadFile Reader;

        public Form1()
        {
            InitializeComponent();
            System = new SimulationSystem();
            Reader = new ReadFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reader.Read("E:\\FCIS 4th Year\\1st Sem\\Simulation\\Template\\MultiQueueSimulation\\MultiQueueSimulation\\TestCases\\TestCase1.txt");
            System.NumberOfServers = Reader.Input.NumberOfServers;
            System.StoppingNumber = Reader.Input.StoppingNumber;
            System.StoppingCriteria =(MultiQueueModels.Enums.StoppingCriteria) Reader.Input.StoppingCriterea;
            System.SelectionMethod =(MultiQueueModels.Enums.SelectionMethod)Reader.Input.SelectionMethod;
            System.InterarrivalDistribution = Reader.InterarrivalDistribution;
            //System.Servers = Reader.Input.service;
            System.GenerateDistribution(System.InterarrivalDistribution);
            System.ServerDataGenerator(System.Servers);
            Simulate();

        }
        public void Simulate()
        {
            if (System.StoppingCriteria == (MultiQueueModels.Enums.StoppingCriteria.NumberOfCustomers))
            {
                int CurrentCustomer=1;
                int BusyServers = 0;
                int CurrentServiceTime = 0;
                SimulationCase OldCase = new SimulationCase();
                Random random = new Random();
                Random ServiceRandom = new Random();
                Random ServerRandom = new Random();
                OldCase.ArrivalTime = 0;
                OldCase.InterArrival = 0;
                while (CurrentCustomer <= System.StoppingNumber)
                {
                    //Our Main code!
                    SimulationCase NewCase = new SimulationCase();
                    NewCase.CustomerNumber = CurrentCustomer;
                    NewCase.RandomInterArrival = random.Next(1, 100);
                    NewCase.InterArrival = System.GetWithinRange(System.InterarrivalDistribution,NewCase.RandomInterArrival);
                    NewCase.ArrivalTime = OldCase.ArrivalTime + NewCase.InterArrival;
                    //Server
                    NewCase.RandomService = ServiceRandom.Next(1, 100);
                    int ServerIndex = 0;
                    if (BusyServers < System.NumberOfServers)
                    {
                        NewCase.TimeInQueue = 0;
                        if (System.SelectionMethod == Enums.SelectionMethod.HighestPriority)
                        {
                            for(int i = 0; i < System.Servers.Count; i++)
                            {
                                if(System.Servers[i].LastFinishTime < NewCase.ArrivalTime)
                                {
                                    NewCase.AssignedServer = System.Servers[i];
                                    ServerIndex = i;
                                    break;
                                }
                            }
                        }
                        else if(System.SelectionMethod == Enums.SelectionMethod.Random)
                        {
                            int RandomServer = ServerRandom.Next(0, System.NumberOfServers-1);
                            NewCase.AssignedServer = System.Servers[RandomServer];
                            ServerIndex = RandomServer;
                        }
                        NewCase.StartTime = NewCase.ArrivalTime;
                        NewCase.ServiceTime = System.GetWithinRange(NewCase.AssignedServer.TimeDistribution,NewCase.RandomService);
                        NewCase.EndTime = NewCase.StartTime + NewCase.ServiceTime;
                        System.Servers[ServerIndex].LastFinishTime = NewCase.EndTime;
                    }
                    else
                    {
                        //Time in queue
                        ServerIndex = System.GetFirstFinishServer();
                        NewCase.AssignedServer = System.Servers[ServerIndex];
                        NewCase.TimeInQueue = NewCase.AssignedServer.LastFinishTime-NewCase.ArrivalTime;
                        NewCase.StartTime = NewCase.AssignedServer.LastFinishTime;
                        NewCase.ServiceTime = System.GetWithinRange(NewCase.AssignedServer.TimeDistribution, NewCase.RandomService);
                        NewCase.EndTime = NewCase.StartTime + NewCase.ServiceTime;
                        System.Servers[ServerIndex].LastFinishTime = NewCase.EndTime;
                    }
                    System.SimulationTable.Add(NewCase);
                    CurrentServiceTime = NewCase.EndTime + 1;
                    OldCase = NewCase;
                    CurrentCustomer++;
                }
            }
            else //Where is the time limit input
            {

            }
            //Don't forget PerformanceMeasures
            //System.PerformanceMeasures
        }
    }

}
