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
        ReadFile inp = new ReadFile();
        List<Server> servers = new List<Server>();

        public Form1()
        {
            InitializeComponent();
            System = new SimulationSystem();
            Reader = new ReadFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.ReadInput(Reader);
            System.Simulate();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Stable(System).Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string TestingResults = TestingManager.Test(System, Constants.FileNames.TestCase2);
            MessageBox.Show(TestingResults);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            inp.Input.NumberOfServers = int.Parse(txt_servernum.Text);
            inp.Input.StoppingNumber = int.Parse(txt_stoppnum.Text);
            
            inp.Input.SelectionMethod = method_cmb.SelectedIndex + 1;
            inp.Input.StoppingCriterea = criterea_cmb.SelectedIndex + 1;
            List<TimeDistribution> InterArrival = new List<TimeDistribution>();
            for (int i = 0; i < dataGridView1.RowCount-1; i++) {

                TimeDistribution t = new TimeDistribution();
                t.Time = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                t.Probability = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value.ToString());
                InterArrival.Add(t);
            }
            inp.InterarrivalDistribution = InterArrival;
            
            



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            int j = int.Parse(txt_servernum.Text);
            j--;
            txt_servernum.Text = j.ToString();
            if (j == 0) {
                inp.Input.ServersList = servers;
                button5.Enabled = false; }
            List<TimeDistribution> ServerDistribution = new List<TimeDistribution>();
            Server S = new Server();
            for (int i = 0; i < dataGridView2.RowCount-1; i++)
            {
               
                TimeDistribution t = new TimeDistribution();
                t.Time = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                t.Probability = Convert.ToDecimal(dataGridView2.Rows[i].Cells[1].Value.ToString());
                ServerDistribution.Add(t);
                S.TimeDistribution = ServerDistribution;
                    
                
            }
            servers.Add(S);
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Graph(System).Show();
        }
    }

}
