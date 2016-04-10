using System;
using System.Windows.Forms;

namespace OS_SSTF
{
    public partial class frmInput : Form
    {
        public frmInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.NumberOfCylinders = numericUpDown1.Value;
            Global.HeaderPosition = numericUpDown2.Value;
            this.Hide();
            frmMain frm = new frmMain();
            frm.numericUpDown1.Maximum = Global.NumberOfCylinders - 1;
            frm.Show();
        }
    }
}
