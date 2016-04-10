namespace OS_Process_Management_FIFO
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class FormMain : Form
    {
        Queue<Process> ready;
        Queue<Process> blocked;
        Process currentProcess;
        int processCounter;

        public FormMain()
        {
            InitializeComponent();

            ready = new Queue<Process>();
            blocked = new Queue<Process>();
            currentProcess = null;
            processCounter = 0;
        }

        private void Repaint(int update)
        {
            // 1 - ready
            // 2 - blocked
            // != 1 and 2 - both
            BindingSource bsReady = new BindingSource();
            BindingSource bsBlocked = new BindingSource();

            switch (update)
            {
                case 1:
                    bsReady.DataSource = ready;
                    dataGridView1.DataSource = bsReady;
                    break;
                case 2:
                    bsBlocked.DataSource = blocked;
                    dataGridView2.DataSource = bsBlocked;
                    break;
                default:
                    bsReady.DataSource = ready;
                    dataGridView1.DataSource = bsReady;

                    bsBlocked.DataSource = blocked;
                    dataGridView2.DataSource = bsBlocked;
                    break;
            }           
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string processName = textBoxProcessName.Text.Trim();
            if (!String.IsNullOrEmpty(processName))
            {
                ready.Enqueue(new Process(++processCounter, processName));
                buttonDispatch.Enabled = true;
                Repaint(1);
            }
        }

        private void buttonDispatch_Click(object sender, EventArgs e)
        {
            if (currentProcess == null && ready.Count > 0)
            {
                currentProcess = ready.Dequeue();
                buttonDispatch.Enabled = false;
                labelCurrentProcess.Text = currentProcess.Id + ", " + currentProcess.Name;
                buttonFinish.Enabled = true;
                buttonBlock.Enabled = true;
                Repaint(1);
            }
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            if (currentProcess != null)
            {
                currentProcess = null;
                labelCurrentProcess.Text = "~";
                buttonBlock.Enabled = false;
                if (ready.Count > 0)
                {
                    buttonDispatch.Enabled = true;
                }
                buttonFinish.Enabled = false;
            }
        }

        private void buttonBlock_Click(object sender, EventArgs e)
        {
            if (currentProcess != null)
            {
                blocked.Enqueue(currentProcess);
                Repaint(2);
                buttonBlock.Enabled = false;
                buttonFinish.Enabled = false;
                if (ready.Count > 0)
                {
                    buttonDispatch.Enabled = true;
                }
                buttonUnblock.Enabled = true;
                labelCurrentProcess.Text = "~";
                currentProcess = null;
            }
        }

        private void buttonUnblock_Click(object sender, EventArgs e)
        {
            if (blocked.Count > 0)
            {
                ready.Enqueue(blocked.Dequeue());
                if (currentProcess == null)
                {
                    buttonDispatch.Enabled = true;
                }
                if (blocked.Count == 0)
                {
                    buttonUnblock.Enabled = false;
                }
                Repaint(0);
            }
        }
    }
}
