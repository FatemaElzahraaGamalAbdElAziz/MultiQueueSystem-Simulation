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
namespace MultiQueueSimulation
{
    public partial class Stable : Form
    {
        SimulationSystem System;
        //SimulationCase casee;
        public Stable(SimulationSystem system)
        {
            System = system;
            InitializeComponent();
        }

        private void Stable_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Customer No");
            dt.Columns.Add("Random InterArrival");
            dt.Columns.Add("Interval Time");
            dt.Columns.Add("Arrival Time");
            dt.Columns.Add("Random Service");
            dt.Columns.Add("Service Time ");
            dt.Columns.Add("Server Index");
            dt.Columns.Add("Begining of Time Service");
            dt.Columns.Add("End of Time Service ");
            dt.Columns.Add("Time in Queue");
            for (int i = 0; i < System.StoppingNumber; i++)
            {
                dt.Rows.Add(System.SimulationTable[i].CustomerNumber, System.SimulationTable[i].RandomInterArrival, System.SimulationTable[i].InterArrival, System.SimulationTable[i].ArrivalTime, System.SimulationTable[i].RandomService,System.SimulationTable[i].ServiceTime, System.SimulationTable[i].ServerIndex, System.SimulationTable[i].StartTime, System.SimulationTable[i].EndTime, System.SimulationTable[i].TimeInQueue);
               
            }
            dataGridView1.DataSource = dt;

        }
    }
}
    

