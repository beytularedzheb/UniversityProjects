using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OS_SSTF
{
    class Request
    {
        private decimal cylinder;

        public decimal Cylinder
        {
            get
            {
                return cylinder;
            }

            set
            {
                cylinder = value;
            }
        }

        public Request(decimal cylinder)
        {
            this.Cylinder = cylinder;
        }
    }

    public partial class frmMain : Form
    {
        List<Request> requests;

        public frmMain()
        {
            InitializeComponent();
            requests = new List<Request>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            requests.Add(new Request(numericUpDown1.Value));
            button2.Enabled = true;
            Repaint();
        }

        private void Repaint()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = requests;
            dataGridView1.DataSource = bs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Request r = SSTF();
            if (r != null)
            {
                label4.Text = r.Cylinder.ToString();
                Global.HeaderPosition = r.Cylinder;
                requests.Remove(r);
                Repaint();
            }
            if (requests.Count == 0)
            {
                button2.Enabled = false;
                label4.Text = "~";
                MessageBox.Show("Няма други заявки!");
            }
        }

        private Request SSTF()
        {
            Request result = null;
            decimal min = decimal.MaxValue;
            for (int i = 0; i < requests.Count; i++)
            {
                decimal buf = Math.Abs(Global.HeaderPosition - requests[i].Cylinder);
                if (buf < min)
                {
                    min = buf;
                    result = requests[i];
                }
            }

            return result;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
