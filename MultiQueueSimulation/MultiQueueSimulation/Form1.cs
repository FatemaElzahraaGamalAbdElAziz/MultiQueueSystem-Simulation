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
            // Function that generates everything for all servers(System.Servers)
        }
     
    }
}
