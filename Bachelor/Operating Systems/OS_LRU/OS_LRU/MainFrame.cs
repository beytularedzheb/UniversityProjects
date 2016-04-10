using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OS_LRU
{
    public partial class MainFrame : Form
    {
        private int interruptCount;
        private int memorySize;
        private List<Frame> memory;

        public MainFrame()
        {
            InitializeComponent();
            this.dataGridView1.Columns[1].DefaultCellStyle.Format = "mm/dd/yyyy HH:mm:ss";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            memorySize = (int)numericUpDown1.Value;
            memory = new List<Frame>(memorySize);
            panel1.Enabled = false;
            panel2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int currentSelectedRowIndex = 0;

            if (memory.Count > 0)
            {
                bool contains = false;
                for (int i = 0; i < memory.Count; i++)
                {
                    if (memory[i].Id == (int)numericUpDown2.Value)
                    {
                        memory[i].AccessTime = DateTime.Now;
                        currentSelectedRowIndex = i;
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                {
                    Frame frame = new Frame((int)numericUpDown2.Value, DateTime.Now);
                    

                    if (memory.Count >= memorySize)
                    {
                        interruptCount++;
                        label4.Text = interruptCount.ToString();

                        DateTime min = memory[0].AccessTime;
                        int index = 0;

                        for (int i = 1; i < memory.Count; i++)
                        {
                            if (memory[i].AccessTime < min)
                            {
                                min = memory[i].AccessTime;
                                index = i;
                            }
                        }

                        memory[index] = frame;
                        currentSelectedRowIndex = index;
                    }
                    else
                    {
                        memory.Add(frame);
                        currentSelectedRowIndex = memory.Count - 1;
                    }
                }
            }
            else
            {
                memory.Add(new Frame((int)numericUpDown2.Value, DateTime.Now));
                currentSelectedRowIndex = 0;
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = memory;
            dataGridView1.DataSource = bs;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
            dataGridView1.Rows[currentSelectedRowIndex].Selected = true;
        }
    }
}
