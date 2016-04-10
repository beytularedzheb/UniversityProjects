using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OS_NSCAN
{
    public partial class frmMain : Form
    {
        Queue<Request> requests;
        List<Request> currentSub;

        public frmMain()
        {
            InitializeComponent();
            requests = new Queue<Request>();
            currentSub = new List<Request>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            requests.Enqueue(new Request(numericUpDown1.Value));
            button2.Enabled = true;
            Repaint();
        }

        private void Repaint()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = requests;
            dataGridView1.DataSource = bs;

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = currentSub;
            dataGridView2.DataSource = bs1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentSub.Count == 0)
            {
                for (int i = 0; i < Global.NumberOfSteps && requests.Count > 0; i++)
                {
                    currentSub.Add(requests.Dequeue());
                }
                currentSub.Sort((r1, r2) => r1.Cylinder.CompareTo(r2.Cylinder));
            }
            if (currentSub.Count > 0)
            {
                if (!Global.Direction)
                { // Right
                    if (currentSub[0].Cylinder >= Global.HeaderPosition)
                    {
                        Global.HeaderPosition = currentSub[0].Cylinder;
                        label4.Text = currentSub[0].Cylinder.ToString();
                        currentSub.RemoveAt(0);
                    }
                    else
                    {
                        Global.Direction = true;
                        labelDir.Text = "Наляво";
                        labelDir.ForeColor = Color.Green;
                        Global.HeaderPosition = currentSub[currentSub.Count - 1].Cylinder;
                        label4.Text = currentSub[currentSub.Count - 1].Cylinder.ToString();
                        currentSub.RemoveAt(currentSub.Count - 1);
                    }
                }
                else
                { // Left
                    if (currentSub[currentSub.Count - 1].Cylinder <= Global.HeaderPosition)
                    {
                        Global.HeaderPosition = currentSub[currentSub.Count - 1].Cylinder;
                        label4.Text = currentSub[currentSub.Count - 1].Cylinder.ToString();
                        currentSub.RemoveAt(currentSub.Count - 1);
                    }
                    else
                    {
                        Global.Direction = false;
                        labelDir.Text = "Надясно";
                        labelDir.ForeColor = Color.Red;
                        Global.HeaderPosition = currentSub[0].Cylinder;
                        label4.Text = currentSub[0].Cylinder.ToString();
                        currentSub.RemoveAt(0);
                    }
                }
                if (currentSub.Count == 0)
                {
                    Global.Direction = !Global.Direction;
                    if (Global.Direction)
                    {
                        Global.HeaderPosition = numericUpDown1.Maximum;
                        labelDir.Text = "Наляво";
                        labelDir.ForeColor = Color.Green;
                    }
                    else
                    {
                        Global.HeaderPosition = numericUpDown1.Minimum;
                        labelDir.Text = "Надясно";
                        labelDir.ForeColor = Color.Red;
                    }
                }
            }
            else if (requests.Count == 0 && currentSub.Count == 0)
            {
                button2.Enabled = false;
                label4.Text = "~";
                MessageBox.Show("Няма други заявки!");
            }
            Repaint();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
