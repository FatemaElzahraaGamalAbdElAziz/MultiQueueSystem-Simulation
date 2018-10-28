namespace MultiQueueSimulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.criterea_cmb = new System.Windows.Forms.ComboBox();
            this.method_cmb = new System.Windows.Forms.ComboBox();
            this.txt_servernum = new System.Windows.Forms.TextBox();
            this.txt_stoppnum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Inter_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inter_Probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.server_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.server_probabilty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "ReadFile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 381);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Simulation Table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(617, 381);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "Test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of Servers :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selection Method :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stopping Criteria :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stopping Number :";
            // 
            // criterea_cmb
            // 
            this.criterea_cmb.FormattingEnabled = true;
            this.criterea_cmb.Items.AddRange(new object[] {
            "Number of Customers",
            "Simulation Time"});
            this.criterea_cmb.Location = new System.Drawing.Point(108, 100);
            this.criterea_cmb.Name = "criterea_cmb";
            this.criterea_cmb.Size = new System.Drawing.Size(121, 21);
            this.criterea_cmb.TabIndex = 7;
            // 
            // method_cmb
            // 
            this.method_cmb.FormattingEnabled = true;
            this.method_cmb.Items.AddRange(new object[] {
            "Highest Priority",
            "Random"});
            this.method_cmb.Location = new System.Drawing.Point(108, 140);
            this.method_cmb.Name = "method_cmb";
            this.method_cmb.Size = new System.Drawing.Size(121, 21);
            this.method_cmb.TabIndex = 8;
            // 
            // txt_servernum
            // 
            this.txt_servernum.Location = new System.Drawing.Point(119, 28);
            this.txt_servernum.Name = "txt_servernum";
            this.txt_servernum.Size = new System.Drawing.Size(100, 20);
            this.txt_servernum.TabIndex = 9;
            // 
            // txt_stoppnum
            // 
            this.txt_stoppnum.Location = new System.Drawing.Point(119, 65);
            this.txt_stoppnum.Name = "txt_stoppnum";
            this.txt_stoppnum.Size = new System.Drawing.Size(100, 20);
            this.txt_stoppnum.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "InterArrival Table :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Inter_Time,
            this.Inter_Probability});
            this.dataGridView1.Location = new System.Drawing.Point(15, 216);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 12;
            // 
            // Inter_Time
            // 
            this.Inter_Time.HeaderText = "Time";
            this.Inter_Time.Name = "Inter_Time";
            // 
            // Inter_Probability
            // 
            this.Inter_Probability.HeaderText = "Probability";
            this.Inter_Probability.Name = "Inter_Probability";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Server Time Distribution :";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.server_time,
            this.server_probabilty});
            this.dataGridView2.Location = new System.Drawing.Point(452, 28);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 14;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // server_time
            // 
            this.server_time.HeaderText = "Time";
            this.server_time.Name = "server_time";
            // 
            // server_probabilty
            // 
            this.server_probabilty.HeaderText = "Probability";
            this.server_probabilty.Name = "server_probabilty";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(261, 381);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 32);
            this.button4.TabIndex = 15;
            this.button4.Text = "Read From Form";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(530, 186);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 32);
            this.button5.TabIndex = 16;
            this.button5.Text = "Add Server";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(617, 338);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 28);
            this.button6.TabIndex = 17;
            this.button6.Text = "Graph";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(704, 416);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_stoppnum);
            this.Controls.Add(this.txt_servernum);
            this.Controls.Add(this.method_cmb);
            this.Controls.Add(this.criterea_cmb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox criterea_cmb;
        private System.Windows.Forms.ComboBox method_cmb;
        private System.Windows.Forms.TextBox txt_servernum;
        private System.Windows.Forms.TextBox txt_stoppnum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inter_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inter_Probability;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn server_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn server_probabilty;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

