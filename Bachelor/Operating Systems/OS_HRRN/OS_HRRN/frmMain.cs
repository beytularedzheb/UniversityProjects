using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OS_HRRN
{
    public partial class frmMain : Form
    {
        private List<Process> startedProcesses;
        private Queue<int> processSeq;
        private Process currentProcess;
        private int processCounter = 0;

        public frmMain()
        {
            InitializeComponent();
            startedProcesses = new List<Process>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processCounter++;
            startedProcesses.Add(new Process(processCounter, (int)numericUpDown2.Value, (int)numericUpDown1.Value));
            startedProcesses = startedProcesses.OrderBy(item => item.ArrivalTime).ToList();
            Repaint();
            button4.Enabled = true;
        }

        private void Repaint()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = startedProcesses;
            dataGridView1.DataSource = bs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = true;
            if (processSeq == null)
            {
                HRRN();
            }
            int index = processSeq.Dequeue();
            currentProcess = startedProcesses[index];
            label4.Text = "No: " + currentProcess.Number.ToString();

            dataGridView1.Rows[index].Selected = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (processSeq.Count == 0)
            {
                button2.Enabled = false;
                MessageBox.Show("Няма други процеси!");
            }
            button3.Enabled = false;
            currentProcess = null;
            label4.Text = "~";
        }

        private void HRRN()
        {
            if (startedProcesses.Count > 0)
            {
                processSeq = new Queue<int>();
                bool[] finishedProcesses = new bool[startedProcesses.Count];
                int curPos = startedProcesses[0].ServiceTime;
                finishedProcesses[0] = true;
                processSeq.Enqueue(0);

                while(true)
                {
                    double highestResponceRatio = double.MinValue;
                    int highestResponceRatioIndex = int.MinValue;

                    bool done = true;
                    int k;
                    for (k = 0; k < finishedProcesses.Length; k++)
                    {
                        if (finishedProcesses[k] == false)
                        {
                            done = false;
                            break;
                        }
                    }

                    if (done)
                    {
                        break;
                    }

                    for (int i = k; i < startedProcesses.Count; i++)
                    {
                        if (finishedProcesses[i] == false && startedProcesses[i].ArrivalTime <= curPos)
                        {
                            double responceRatio = ((curPos - startedProcesses[i].ArrivalTime) + startedProcesses[i].ServiceTime) / (double)startedProcesses[i].ServiceTime;
                            if (highestResponceRatio < responceRatio)
                            {
                                highestResponceRatio = responceRatio;
                                highestResponceRatioIndex = i;
                            }
                        }
                    }

                    processSeq.Enqueue(highestResponceRatioIndex);
                    finishedProcesses[highestResponceRatioIndex] = true;
                    curPos += startedProcesses[highestResponceRatioIndex].ServiceTime;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = false;
            button2.Enabled = true;
            dataGridView1.Rows[0].Selected = false;
        }
    }
}
