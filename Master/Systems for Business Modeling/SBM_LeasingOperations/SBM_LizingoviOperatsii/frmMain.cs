namespace SBM_LizingoviOperatsii
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;

    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Output> list = calculatePayment();
            dataGridView1.DataSource = list;
            Series series0 = this.chart1.Series[0];
            series0.Points.Clear();

            foreach (Output item in list)
            {
                series0.Points.AddXY(item.NumberOfPayment, item.UpdatedPayment.ToString("C"));
            }
        }

        private bool checkFields1()
        {
            if (numericUpDown4.Value <= 0)
                return false;
            return true;
        }

        private List<Output> calculatePayment()
        {
            List<Output> result = null;
            if (checkFields1())
            {
                result = new List<Output>();
                double i = (double)numericUpDown4.Value / 100;
                double P = (double)numericUpDown1.Value;
                int n = (int)numericUpDown2.Value;
                double s = (double)numericUpDown3.Value;
                double L = 1 + i;
                double Vin = Math.Pow(1 + i, -n);
                double a = (1 - Vin) / i;
                double R = (P - s * Vin) / a;
                int typeVN = 1;

                if (radioButton2.Checked)
                {
                    R = R / (1 + i);
                    typeVN = 2;
                }
                else if (radioButton3.Checked)
                {
                    R = (R / Math.Pow(1 + i, 1 / 12)) / 12;
                    typeVN = 3;
                    L = (L - 1) / 12 + 1;
                    n = 12 * n;
                }
                R = Math.Round(R * 100) / 100;
                int m = typeVN == 2 ? 1 : 0;

                for (int j = 1; j <= n; j++)
                {
                    Output output = new Output(j, R, Math.Round(R / Math.Pow(L, j - m) * 100) / 100);
                    result.Add(output);
                }
            }
            
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(calculateEffectiveness());            
        }

        private string calculateEffectiveness()
        {
            double v = ((double)numericUpDown10.Value / 100) + 1.0d;
            double na = (double)numericUpDown9.Value;
            double R = (double)numericUpDown5.Value;
            double P = (double)numericUpDown6.Value;
            double S = (double)numericUpDown7.Value;
            int n = (int)numericUpDown8.Value;
            int m = radioButton4.Checked ? 1 : 12;
            double Anie = (P - S * Math.Pow(v, (-n))) / (m * R);
            double A1 = ((1 - Math.Pow(1.24d, -n)) / (m * (Math.Pow(1.24d, 1d / m) - 1d))) * Math.Pow(1.24d, 1d / m);
            double A2 = ((1 - Math.Pow(1.25d, -n)) / (m * (Math.Pow(1.25d, 1d / m) - 1d))) * Math.Pow(1.25d, 1d / m);
            Anie = 0.24d + (Anie - A1) / (A2 - A1) * 0.01d;
            Anie = Math.Round(Anie * 10000d) / 100d - na;
            return "Действителната ефективност на лизинговата операция възлиза на " + Anie.ToString("N2") + "%.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double Lk = (double)numericUpDown13.Value / 100d;
            double i = (double)numericUpDown17.Value / 100d;
            double St = (double)numericUpDown16.Value;
            double Mvn = (double)numericUpDown15.Value;
            int Srk = (int)numericUpDown14.Value;
            double Ost = (double)numericUpDown12.Value;
            double Nvn = (double)numericUpDown11.Value;
            double R = (St - Nvn) / ((1d - Math.Pow(1d + Lk, -Srk)) / Lk);
            double P = Nvn + R * ((1d - Math.Pow(1d + i, -Srk)) / i) - Ost * Math.Pow(1d + i, -Srk);
            R = P / ((1d - Math.Pow(1d + Lk, -Srk)) / Lk);

            string msg = "";
            if (Mvn > (R / 12d))
            {
                msg = "Вариантът покупка е по-изгоден от лизинг!";
            }
            else
            {
                msg = "Вариантът лизинг е по-изгоден от покупката!";                
            }
            MessageBox.Show(msg + R);
        }
    }
}
