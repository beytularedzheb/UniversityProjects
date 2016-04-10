using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OS_First_Fit
{
    public partial class frmMain : Form
    {
        private const int MAX_BLOCKS_ON_ROW = 20;

        private uint memorySize;
        private uint blockSize;
        private uint freeMemorySize;

        private int[] blockMemory;

        private List<Process> processes;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSetMemory_Click(object sender, EventArgs e)
        {
            // init
            processes = new List<Process>();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            memorySize = (uint)this.nudMemorySize.Value;
            blockSize = (uint)this.nudBlockSize.Value;

            blockMemory = new int[(int)Math.Round(memorySize / (float)blockSize, MidpointRounding.AwayFromZero)];
            freeMemorySize = (uint)blockMemory.Length;

            float d = blockMemory.Length / (float)MAX_BLOCKS_ON_ROW;
            tableLayoutPanel6.RowCount = (d - (int)d) > 0 ? (int)(d + 1) : (int)d;
            tableLayoutPanel6.RowStyles.Clear();

            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel6.Controls.Clear();
            for (int i = 0; i < tableLayoutPanel6.RowCount; i++)
            {
                tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }

            tableLayoutPanel6.ColumnCount = blockMemory.Length < MAX_BLOCKS_ON_ROW ? blockMemory.Length : MAX_BLOCKS_ON_ROW;
            tableLayoutPanel6.ColumnStyles.Clear();

            for (int j = 0; j < tableLayoutPanel6.ColumnCount; j++)
            {
                tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }

            int counter = 0;
            for (int i = 0; i < tableLayoutPanel6.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel6.ColumnCount; j++)
                {
                    if (counter >= blockMemory.Length)
                    {
                        break;
                    }
                    Panel backgroundColorPanel = new Panel();
                    backgroundColorPanel.BackColor = Color.White;
                    backgroundColorPanel.Dock = DockStyle.Fill;
                    Label cellNumber = new Label();
                    cellNumber.ForeColor = Color.DarkGray;
                    cellNumber.Text = counter.ToString();
                    backgroundColorPanel.Controls.Add(cellNumber);

                    tableLayoutPanel6.Controls.Add(backgroundColorPanel, j, i);
                    counter++;
                }
            }

            tableLayoutPanel6.ResumeLayout();
            Repaint();

            this.lblMemorySizeStatusValue.Text = blockMemory.Length.ToString();
            this.lblFreeMemoryStatusValue.Text = freeMemorySize.ToString();

            scContent.Enabled = true;

        }

        private void btnSaveProcess_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbProcessId.Text))
            {
                Process process = new Process();
                process.ProcessId = tbProcessId.Text;
                uint size = (uint)Math.Round(nudProcessSize.Value / nudBlockSize.Value, MidpointRounding.AwayFromZero);
                if (size == 0)
                {
                    size = 1;
                }
                process.Size = (uint)nudProcessSize.Value;
                process.StartBlock = SaveProcess(size);
                if (process.StartBlock >= 0)
                {
                    KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                    bool same = false;
                    do
                    {
                        same = false;
                        process.Color = Color.FromKnownColor(colors[new Random().Next(0, colors.Length)]);
                        for (int i = 0; i < processes.Count; i++)
                        {
                            if (processes[i].Color == process.Color)
                            {
                                same = true;
                                break;
                            }
                        }
                    } while (process.Color == Color.White || process.Color == Color.DarkGray || process.Color == Color.Transparent || process.Color == Color.GhostWhite || same);

                    processes.Add(process);
                    tbProcessId.Text = "";
                    nudProcessSize.Value = nudProcessSize.Minimum;
                    btnDelete.Enabled = true;
                    Repaint();
                }
            }
            else
            {
                MessageBox.Show("Моля въведете името на файла!");
            }
        }

        private void Repaint()
        {
            this.lblFreeMemoryStatusValue.Text = freeMemorySize.ToString();
            tableLayoutPanel6.SuspendLayout();
            int counter = 0;
            for (int f = 0; f < processes.Count; f++)
            {
                counter = 0;
                int end = (int)(processes[f].StartBlock + processes[f].Size);
                for (int i = 0; i < tableLayoutPanel6.RowCount; i++)
                {
                    for (int j = 0; j < tableLayoutPanel6.ColumnCount; j++)
                    {
                        if (counter >= end)
                        {
                            break;
                        }
                        if (processes[f].StartBlock <= counter && counter < end)
                        {
                            tableLayoutPanel6.GetControlFromPosition(j, i).BackColor = processes[f].Color;
                        }
                        counter++;
                    }
                }
            }

            counter = 0;
            for (int i = 0; i < tableLayoutPanel6.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel6.ColumnCount; j++)
                {
                    if (counter >= blockMemory.Length)
                    {
                        break;
                    }

                    if (blockMemory[counter] == 0)
                    {
                        tableLayoutPanel6.GetControlFromPosition(j, i).BackColor = Color.White;
                    }
                    counter++;
                }
            }

            tableLayoutPanel6.ResumeLayout();
            BindingSource bs = new BindingSource();
            bs.DataSource = processes;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;
        }

        private int SaveProcess(uint size)
        {
            int firstAddress = checkSize(size);

            if (firstAddress >= 0)
            {
                freeMemorySize -= size;

                for (int i = firstAddress; i < (firstAddress + size); i++)
                {
                    blockMemory[i] = 1;
                }                
            }
            else
            {
                MessageBox.Show("Файлът не може да се запише!");
            }
            return firstAddress;
        }

        private int checkSize(uint size)
        {
            if (freeMemorySize < size)
            {
                return -1;
            }
            int sizeCounter = 0;
            int firstAddress = -1;
            int nextTest = 0;
            bool result = false;

            while(true)
            {
                for (int i = nextTest; i < blockMemory.Length && sizeCounter < size; i++)
                {
                    if (blockMemory[i] == 0)
                    {
                        if (firstAddress < 0)
                        {
                            firstAddress = i;
                        }
                        sizeCounter++;
                    }
                    else if (firstAddress >= 0 && sizeCounter <= size)
                    {
                        firstAddress = -1;
                        nextTest = i + 1;
                        sizeCounter = 0;
                        break;
                    }
                }
                if (nextTest >= blockMemory.Length)
                {
                    result = false;
                    break;
                }
                else if (firstAddress >= 0 && sizeCounter == size)
                {
                    result = true;
                    break;
                }
            }
            if (result)
            {
                return firstAddress;
            }
            return -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Process process = processes[dataGridView1.SelectedRows[0].Index];
                for (int i = process.StartBlock; i < (process.StartBlock + process.Size); i++)
                {
                    freeMemorySize++;
                    blockMemory[i] = 0;
                }
                processes.RemoveAt(dataGridView1.SelectedRows[0].Index);
                Repaint();
                btnDelete.Enabled = processes.Count > 0 ? true : false;
            }
            else
            {
                MessageBox.Show("Моля изберете елемент от FAT таблицата!");
            }
        }

        private void buttonGarbageCollector_Click(object sender, EventArgs e)
        {
            List<int> blocks = new List<int>(blockMemory.Length);
            for (int i = 0; i < processes.Count; i++)
            {
                int[] subArray = new int[processes[i].Size];
                Array.Copy(blockMemory, processes[i].StartBlock, subArray, 0, processes[i].Size);
                processes[i].StartBlock = blocks.Count;
                blocks.InsertRange(blocks.Count, subArray);
            }
            Array.Clear(blockMemory, 0, blockMemory.Length);
            Array.Copy(blocks.ToArray(), 0, blockMemory, 0, blocks.Count);
            Repaint();
        }
    }
}
