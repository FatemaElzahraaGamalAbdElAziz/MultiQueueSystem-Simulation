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
    public partial class Graph : Form
    {
        SimulationSystem System = new SimulationSystem();
        int x = -1;
        public Graph(SimulationSystem system)
        {
            InitializeComponent();
            System = system;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = System.TotalSimulationTime;
            MessageBox.Show(System.TotalSimulationTime.ToString());
            x++;
            int servernum = System.Servers[x].ID;

            for (int j = 0; j < System.StoppingNumber; j++)
            {
                if (System.SimulationTable[j].ServerIndex == servernum)
                {
                    int Start = System.SimulationTable[j].StartTime;
                    int End = System.SimulationTable[j].EndTime;


                    for (int c = Start; c <= End; c++)
                    {
                        this.chart1.Series["Series1"].Points.AddXY(c, 1);
                      //  chart1.Series[0]["PointWidth"] = "1";
                    }





                }
            }


        }
    }
}
