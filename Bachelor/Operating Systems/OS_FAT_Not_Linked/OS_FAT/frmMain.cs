using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OS_FAT
{
    public partial class frmMain : Form
    {
        private const int MAX_BLOCKS_ON_ROW = 20;

        private uint memorySize;
        private uint blockSize;
        private uint freeMemorySize;

        private int[] blockMemory;

        private List<Directory> files;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSetMemory_Click(object sender, EventArgs e)
        {
            // init
            files = new List<Directory>();
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

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbFileName.Text))
            {
                Directory file = new Directory();
                file.FileName = tbFileName.Text;
                uint size = (uint)Math.Round(nudFileSize.Value / nudBlockSize.Value, MidpointRounding.AwayFromZero);
                if (size == 0)
                {
                    size = 1;
                }
                file.Size = (uint)nudFileSize.Value;
                file.BlockNumber = SaveFile(size);
                if (file.BlockNumber >= 0)
                {
                    KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                    bool same = false;
                    do
                    {
                        same = false;
                        file.Color = Color.FromKnownColor(colors[new Random().Next(0, colors.Length)]);
                        for (int i = 0; i < files.Count; i++)
                        {
                            if (files[i].Color == file.Color)
                            {
                                same = true;
                                break;
                            }
                        }
                    } while (file.Color == Color.White || file.Color == Color.DarkGray || file.Color == Color.Transparent || file.Color == Color.GhostWhite || same);

                    files.Add(file);
                    tbFileName.Text = "";
                    nudFileSize.Value = nudFileSize.Minimum;
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
            for (int f = 0; f < files.Count; f++)
            {
                counter = 0;
                int end = (int)(files[f].BlockNumber + files[f].Size);
                for (int i = 0; i < tableLayoutPanel6.RowCount; i++)
                {
                    for (int j = 0; j < tableLayoutPanel6.ColumnCount; j++)
                    {
                        if (counter >= end)
                        {
                            break;
                        }
                        if (files[f].BlockNumber <= counter && counter < end)
                        {
                            tableLayoutPanel6.GetControlFromPosition(j, i).BackColor = files[f].Color;
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
            bs.DataSource = files;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;
        }

        private int SaveFile(uint size)
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
                Directory d = files[dataGridView1.SelectedRows[0].Index];
                for (int i = d.BlockNumber; i < (d.BlockNumber + d.Size); i++)
                {
                    freeMemorySize++;
                    blockMemory[i] = 0;
                }
                files.RemoveAt(dataGridView1.SelectedRows[0].Index);
                Repaint();
                btnDelete.Enabled = files.Count > 0 ? true : false;
            }
            else
            {
                MessageBox.Show("Моля изберете елемент от FAT таблицата!");
            }
        }
    }
}
