namespace SBM_RentCalculation
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
    using SBM_RentCalculation.Classes;

    public partial class frmMain : Form
    {
        private int operationType;
        private const string radioButtonColor = "Control";

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string val = validateFields();
            if (val != null)
            {
                MessageBox.Show(val);
                return;
            }

            string result = null;

            switch (operationType)
            {
                case OperationType.POST_RENT:
                    result = calculatePostRent((uint)nudA.Value, (double)nudB.Value, (float)nudC.Value).ToString("C");
                    break;
                case OperationType.PRE_RENT:
                    result = calculatePreRent((uint)nudA.Value, (double)nudB.Value, (float)nudC.Value).ToString("C");
                    break;
                case OperationType.FIX_RENT_TIME:
                    result = calculateFixRentTime((double)nudA.Value, (double)nudB.Value, (float)nudC.Value).ToString();
                    break;
                case OperationType.P_TIME_RENT:
                    result = calculatePTimeRent((uint)nudA.Value, (double)nudB.Value, (float)nudC.Value, (uint)nudD.Value).ToString("C");
                    break;
                case OperationType.BIGGER_THAN_A_YEAR:
                    result = calculateRent_Bigger((double)nudA.Value, (uint)nudB.Value, (uint)nudD.Value, (float)nudC.Value).ToString("C");
                    break;
            }
            lblResult.Text = result;
        }

        private double calculatePostRent(uint n, double R, float i)
        {
            double q = (i / 100) + 1;
            return (R * ((Math.Pow(q, n) - 1) / (q - 1)));
        }

        private double calculatePreRent(uint n, double R, float i)
        {
            double q = (i / 100) + 1;
            return (R * q * ((Math.Pow(q, n) - 1) / (q - 1)));
        }

        private uint calculateFixRentTime(double Sn, double R, float i)
        {
            double q = i / 100;
            return (uint)Math.Round((Math.Log10(((Sn / R) * q ) + 1)) / Math.Log10(q + 1));
        }

        private double calculatePTimeRent(uint p, double R, float i, uint n)
        {
            double q = i / 100;
            return (R * (Math.Pow(1 + q, n) - 1) / (p * (Math.Pow(1 + q, (q / p)) - 1)));
        }

        private double calculateRent_Bigger(double Rr, uint r, uint n, float i)
        {
            double q = i / 100;
            return (Rr * (Math.Pow(1 + q, n) - 1) / (Math.Pow(1 + q, r) - 1));
        }
    
        private string validateFields()
        {
            string result = null;

            // има го във всички операции, на същата позиция
            if (nudC.Value <= 0 && nudC.Value > 100)
            {
                return "Годишната лихва (i) не може да е <= 0 или > 100.";
            }

            switch (operationType)
            {
                case OperationType.POST_RENT:
                case OperationType.PRE_RENT:

                    break;
                case OperationType.FIX_RENT_TIME:
                    if (nudB.Value <= 0)
                    {
                        result = "Сумата на всяко едно рентно плащане (R) не може да е <= 0.";
                    }
                    break;
                case OperationType.P_TIME_RENT:
                    if (nudA.Value <= 0)
                    {
                        result = "Срокът на рентата (p) не може да е <= 0.";
                    }
                    break;
                case OperationType.BIGGER_THAN_A_YEAR:
                    break;
            }
            return result;
        }
    
        private void preprocessing()
        {
            operationType = 0;
            lblResult.Text = "";

            if (rbPostNum.Checked)
            {
                tableLayoutPanel2.BackColor = Color.FromName("GradientActiveCaption");
                rbPostNum.BackColor = Color.FromName("GradientActiveCaption");
                rbPreNum.BackColor = Color.FromName(radioButtonColor);
                rbPTimeRent.BackColor = Color.FromName(radioButtonColor);
                rbBigger.BackColor = Color.FromName(radioButtonColor);
                rbFixRentTime.BackColor = Color.FromName(radioButtonColor);

                operationType = OperationType.POST_RENT;
                lblA.Text = "Продължителност на рентните плащания (n) в години:";
                lblB.Text = "Сумата на всяко едно рентно плащане (R):";
                lblC.Text = "Годишна лихва (i) в %:";
                lblD.Visible = false;
                lblResultLabel.Text = "Нарастналата сума Sn е:";
                nudA.Value = 0;
                nudB.Value = 0;
                nudC.Value = 0;
                nudD.Visible = false;
            }
            else if (rbPreNum.Checked)
            {
                tableLayoutPanel2.BackColor = Color.FromName("BlanchedAlmond");
                rbPostNum.BackColor = Color.FromName(radioButtonColor);
                rbPreNum.BackColor = Color.FromName("BlanchedAlmond");
                rbPTimeRent.BackColor = Color.FromName(radioButtonColor);
                rbBigger.BackColor = Color.FromName(radioButtonColor);
                rbFixRentTime.BackColor = Color.FromName(radioButtonColor);

                operationType = OperationType.PRE_RENT;
                lblA.Text = "Продължителност на рентните плащания (n) в години:";
                lblB.Text = "Сумата на всяко едно рентно плащане (R):";
                lblC.Text = "Годишна лихва (i) в %:";
                lblD.Visible = false;
                lblResultLabel.Text = "Нарастналата сума (Sn) е:";
                nudA.Value = 0;
                nudB.Value = 0;
                nudC.Value = 0;
                nudD.Visible = false;
            }
            else if (rbFixRentTime.Checked)
            {
                tableLayoutPanel2.BackColor = Color.FromName("DarkSeaGreen");
                rbPostNum.BackColor = Color.FromName(radioButtonColor);
                rbPreNum.BackColor = Color.FromName(radioButtonColor);
                rbPTimeRent.BackColor = Color.FromName(radioButtonColor);
                rbBigger.BackColor = Color.FromName(radioButtonColor);
                rbFixRentTime.BackColor = Color.FromName("DarkSeaGreen");

                operationType = OperationType.FIX_RENT_TIME;
                lblA.Text = "Нарастналата сума (Sn) на рентата след n-годишни плащания:";
                lblB.Text = "Сумата на всяко едно рентно плащане (R):";
                lblC.Text = "Годишна лихва (i) в %:";
                lblD.Visible = false;
                lblResultLabel.Text = "Срокът на рентата (n) е:";
                nudA.Value = 0;
                nudB.Value = 0;
                nudC.Value = 0;
                nudD.Visible = false;
            }
            else if (rbPTimeRent.Checked)
            {
                tableLayoutPanel2.BackColor = Color.FromName("Thistle");
                rbPostNum.BackColor = Color.FromName(radioButtonColor);
                rbPreNum.BackColor = Color.FromName(radioButtonColor);
                rbPTimeRent.BackColor = Color.FromName("Thistle");
                rbBigger.BackColor = Color.FromName(radioButtonColor);
                rbFixRentTime.BackColor = Color.FromName(radioButtonColor);

                operationType = OperationType.P_TIME_RENT;
                lblA.Text = "Срок на рентата (p) в месеци:";
                lblB.Text = "Сумата на всяко едно рентно плащане (R):";
                lblC.Text = "Годишна лихва (i) в %:";
                lblD.Visible = true;
                lblD.Text = "Продължителност на рентните плащания (n) в години:";
                lblResultLabel.Text = "Нарастналата сума Sn e:";
                nudA.Value = 0;
                nudB.Value = 0;
                nudC.Value = 0;
                nudD.Visible = true;
                nudD.Value = 0;
            }
            else if (rbBigger.Checked)
            {
                tableLayoutPanel2.BackColor = Color.FromName("Khaki");
                rbPostNum.BackColor = Color.FromName(radioButtonColor);
                rbPreNum.BackColor = Color.FromName(radioButtonColor);
                rbPTimeRent.BackColor = Color.FromName(radioButtonColor);
                rbBigger.BackColor = Color.FromName("Khaki");
                rbFixRentTime.BackColor = Color.FromName(radioButtonColor);

                operationType = OperationType.BIGGER_THAN_A_YEAR;
                lblA.Text = "Член на рентата, изплащана след r-години (Rr):";
                lblB.Text = "Период на рентата (r) в години:";
                lblC.Text = "Годишна лихва (i):";
                lblD.Visible = true;
                lblD.Text = "Срок на рентата (n) в години:";
                lblResultLabel.Text = "Нарастналата сума Sn e:";
                nudA.Value = 0;
                nudB.Value = 0;
                nudC.Value = 0;
                nudD.Visible = true;
                nudD.Value = 0;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            preprocessing();
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            preprocessing();
        }
    }
}
