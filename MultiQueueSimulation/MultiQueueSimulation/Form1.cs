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
                SimulationCase OldCase = new SimulationCase();
                Random random = new Random();
                OldCase.ArrivalTime = 0;
                OldCase.InterArrival = 0;
                while (CurrentCustomer <= System.StoppingNumber)
                {
                    //Our Main code!
                    SimulationCase NewCase = new SimulationCase();
                    NewCase.CustomerNumber = CurrentCustomer;
                    NewCase.RandomInterArrival = random.Next(1, System.StoppingNumber);
                    NewCase.InterArrival = System.GetWithinRange(System.InterarrivalDistribution,NewCase.RandomInterArrival);
                    NewCase.ArrivalTime = OldCase.ArrivalTime + NewCase.InterArrival;
                    //To be continued 
                    //Server Table and Selection
                    //Time in queue
                    
                    System.SimulationTable.Add(NewCase);
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
