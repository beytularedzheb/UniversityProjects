using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Priority
{
    public partial class frmMain : Form
    {
        private const int MAX_PRIORITY_LEVEL = 5;
        private Queue<Process>[] startedProcesses;
        private Process currentProcess;

        public frmMain()
        {
            InitializeComponent();
            this.numericUpDown1.Maximum = MAX_PRIORITY_LEVEL - 1;
            this.numericUpDown1.Value = 0;

            startedProcesses = new Queue<Process>[MAX_PRIORITY_LEVEL];
            for (int i = 0; i < startedProcesses.Length; i++)
            {
                startedProcesses[i] = new Queue<Process>();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                int index = (int)numericUpDown1.Value;
                startedProcesses[index].Enqueue(new Process(textBox1.Text, index));
                Repaint();
                if (currentProcess == null)
                {
                    button2.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Моля въведете името на процеса!");
            }
        }

        private void Repaint()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = getAsList(startedProcesses);
            dataGridView1.DataSource = bs;
        }

        private List<Process> getAsList(Queue<Process>[] array)
        {
            List<Process> result = new List<Process>();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Count; j++)
                {
                    result.Add(array[i].ElementAt(j));
                }
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = startedProcesses.Length - 1; i >= 0; i--)
            {
                if (startedProcesses[i].Count > 0)
                {
                    currentProcess = startedProcesses[i].Dequeue();
                    label4.Text = currentProcess.Name + ", " + currentProcess.Priority;
                    Repaint();
                    button2.Enabled = false;
                    button3.Enabled = true;
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = startedProcesses.Length - 1; i >= 0; i--)
            {
                if (startedProcesses[i].Count > 0)
                {
                    button2.Enabled = true;
                    break;
                }
            }
            button3.Enabled = false;
            currentProcess = null;
            label4.Text = "~";
        }
    }
}
