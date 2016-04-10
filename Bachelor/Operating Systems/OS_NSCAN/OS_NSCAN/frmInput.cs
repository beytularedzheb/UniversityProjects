using System;
using System.Windows.Forms;

namespace OS_NSCAN
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
            Global.NumberOfSteps = numericUpDown3.Value;
            frmMain frm = new frmMain();
            frm.numericUpDown1.Maximum = Global.NumberOfCylinders - 1;
            this.Hide();
            frm.Show();
        }
    }
}
