namespace OS_NUR
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private int interruptCount;
        private int memorySize;
        private List<Frame> memory;
        private int modifiedRowIndex;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            memorySize = (int)numericUpDown1.Value;
            memory = new List<Frame>(memorySize);
            panel1.Enabled = false;
            panel2.Enabled = true;
            interruptCount = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NUR((long)numericUpDown2.Value);
            
            label4.Text = interruptCount.ToString();

            BindingSource bs = new BindingSource();
            bs.DataSource = memory;
            dataGridView1.DataSource = bs;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
            dataGridView1.Rows[modifiedRowIndex].Selected = true;
        }

        private void NUR(long id)
        {
            bool found = false;
            for (int i = 0; i < memory.Count; i++)
            {
                if (memory[i].Id == id)
                {
                    memory[i].Referenced = true;
                    found = true;
                    modifiedRowIndex = i;
                }
            }

            if (!found)
            {
                if (memorySize > memory.Count)
                {
                    memory.Add(new Frame(id, false, false));
                    modifiedRowIndex = memory.Count - 1;
                }
                else
                {
                    bool r = false;
                    bool m = false;
                    bool replaced = false;
                    byte classNumber = 0;
                    List<int> candidates = new List<int>();
                    do {
                        switch (classNumber)
                        {
                            case 0:
                                r = false;
                                m = false;
                                break;
                            case 1:
                                r = false;
                                m = true;
                                break;
                            case 2:
                                r = true;
                                m = false;
                                break;
                            case 3:
                                r = true;
                                m = true;
                                break;
                        }
                        classNumber++;

                        for (int i = 0; i < memory.Count; i++)
                        {
                            if (memory[i].Referenced == r && memory[i].Modified == m)
                            {
                                candidates.Add(i);
                            }
                        }
                        if (candidates.Count > 0)
                        {
                            replaced = true;
                            int selected = new Random().Next(0, candidates.Count);
                            memory[candidates[selected]].Id = id;
                            memory[candidates[selected]].Modified = true;
                            interruptCount++;
                            modifiedRowIndex = candidates[selected];
                        }
                    } while (!replaced);
                }
            }

            // нулиране на referenced
            for (int i = 0; i < memory.Count; i++)
            {
                if (i != modifiedRowIndex)
                {
                    memory[i].Referenced = false;
                }
            }
        }
    }
}
