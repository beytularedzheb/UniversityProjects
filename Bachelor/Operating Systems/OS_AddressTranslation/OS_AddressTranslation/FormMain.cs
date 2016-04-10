namespace OS_AddressTranslation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class FormMain : Form
    {
        /* 
            приемаме, че ОС е 16 битова, а размера на една страница
            в паметта е 512 B (т.е 9 бита за offset).
            16 - 9 = 7
            2 ^ 7 = 128 т.е може да имаме 128 адреса в PAT таблицата
        */
        const int VPTSize = 128;
        private Frame[] VPT;
        private List<Page> memory;
        private string memorySize;

        public FormMain()
        {
            InitializeComponent();
            VPT = new Frame[VPTSize];
            //MessageBox.Show(Math.Ceiling(Math.Log(65536, 2)).ToString()); 
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (radioButton32.Checked)
            {
                memorySize = radioButton32.Text;
                memory = new List<Page>(15); // 32 = 2 ^ 15;
            }
            else if (radioButton64.Checked)
            {
                memorySize = radioButton64.Text;
                memory = new List<Page>(16); // 64 = 2 ^ 16;
            }
            for (int i = 0; i < memory.Capacity; i++)
            {
                memory.Add(new Page());
            }
            Random rnd = new Random();
            var numbers = Enumerable.Range(0, memory.Capacity).OrderBy(x => rnd.Next()).Take(memory.Capacity).ToList();
            int indC = 0;
            for (int i = 0; i < VPT.Length; i++)
            {
                if (indC < numbers.Count)
                {
                    VPT[i] = new Frame(numbers[indC++]);
                }
                else
                {
                    VPT[i] = new Frame(null);
                }
            }

            numericUpDownBlock.Maximum = VPT.Length - 1;
            numericUpDownOffset.Maximum = (int)Math.Pow(2, 9) - 1;

            toolStripStatusLabelRAM.Text += (" " + memorySize);
            panelTop.Enabled = false;
            panel1.Enabled = true;

            BindingSource bsp = new BindingSource();
            bsp.DataSource = memory;
            dataGridViewPages.DataSource = bsp;

            BindingSource bsv = new BindingSource();
            bsv.DataSource = VPT;
            dataGridViewVPT.DataSource = bsv;

            dataGridViewPages.Rows[0].Selected = false;
            dataGridViewVPT.Rows[0].Selected = false;
        }

        private void dataGridViewVPT_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void buttonMMU_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewPages.Rows.Count; i++)
            {
                dataGridViewPages.Rows[i].Selected = false;
            }           

            for (int i = 0; i < dataGridViewVPT.Rows.Count; i++)
            {
                dataGridViewVPT.Rows[i].Selected = false;
            }

            Frame frm = VPT[(int)numericUpDownBlock.Value];
            if (frm.Page != null)
            {
                labelResultR.Text = "Страничен кадър " + 
                    memory[(int)frm.Page].Info[(int)numericUpDownOffset.Value] + 
                    " на страница " + frm.Page;
                dataGridViewPages.Rows[(int)frm.Page].Selected = true;
                dataGridViewVPT.Rows[(int)numericUpDownBlock.Value].Selected = true;
            }
            else
            {
                labelResultR.Text = "~";
                MessageBox.Show("Няма записана информация на този адрес от виртуалната памет!");
            }
        }
    }
}
