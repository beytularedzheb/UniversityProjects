namespace SBM_Amortization
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;

    public partial class frmMain : Form
    {
        private int operationType = OperationTypes.ACQUISITION;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            InputDataAmortization input = GetInputData();

            UpdateData(input);
        }

        private InputDataAmortization GetInputData()
        {
            InputDataAmortization input = null;
            double value = (double)nudValue.Value;
            uint years = (uint)nudYears.Value;
            double currencyRate = (double)nudCurrencyRate.Value;
            double digression = (double)nudDigression.Value;

            if (!nudPercentageRate.Enabled)
            {
                input = new InputDataAmortization(value, currencyRate, years, digression, null);
            }
            else
            {
                input = new InputDataAmortization(value, currencyRate, years, digression, (float)nudPercentageRate.Value);
            }
            return input;
        }

        private void SetInputData(InputDataAmortization input)
        {
            nudValue.Value = (decimal)input.Value;
            nudYears.Value = input.NumberOfYears;
            nudCurrencyRate.Value = (decimal)input.CurrencyRate;
            if (input.PercentageRate != null)
            {
                nudPercentageRate.Value = (decimal)input.PercentageRate;
                nudPercentageRate.Enabled = true;
                chbPercentageRate.Checked = true;
                nudCurrencyRate.Enabled = false;
            }
            else
            {
                nudPercentageRate.Value = nudPercentageRate.Minimum;
                nudPercentageRate.Enabled = false;
                chbPercentageRate.Checked = false;
                nudCurrencyRate.Enabled = true;
            }
            if (input.Digression == 0)
            {
                this.operationType = OperationTypes.ACQUISITION;
                chbDigression.Checked = false;
                nudDigression.Enabled = false;
                nudDigression.Value = 0;
            }
            else
            {
                operationType = OperationTypes.BALANCE_AND_RESIDUAL;
                chbDigression.Checked = true;
                nudDigression.Enabled = true;
                nudDigression.Value = (decimal)input.Digression;
            }
        }

        private void UpdateData(InputDataAmortization input)
        {
            ClearChart();
            Amortization a = new Amortization(input);
            List<OutputDataAmortization> listResult = null;
            if (this.operationType == OperationTypes.ACQUISITION)
            {
                listResult = a.calculateValueOfAcquisitions();
                this.lblP.Text = "";
                this.chartAmortization.Titles.Add("Отчисления от стойността на придобиване");
            }
            else if (this.operationType == OperationTypes.BALANCE_AND_RESIDUAL)
            {
                listResult = a.calculateBalanceAndResidual();
                this.lblP.Text = String.Format("p = {0:N2} %", input.PercentageRate);
                this.chartAmortization.Titles.Add("Отчисления на балансовата или остатъчната стойност");
            }
            this.dataGridView1.DataSource = listResult;

            Series seriesAmortizationSum = this.chartAmortization.Series[0];
            Series seriesBalance = this.chartAmortization.Series[1];
            

            if (seriesAmortizationSum.Enabled || seriesBalance.Enabled)
            {
                foreach (OutputDataAmortization oda in listResult)
                {
                    seriesAmortizationSum.Points.AddXY(oda.NumberOfYear, oda.AmortizationSum.ToString("C"));
                    seriesBalance.Points.AddXY(oda.NumberOfYear, oda.Balance.ToString("C"));
                }
            }
        }

        private void chbAmortizationSum_CheckedChanged(object sender, EventArgs e)
        {
            Series seriesAmortizationSum = this.chartAmortization.Series[0];
            seriesAmortizationSum.Enabled = ((CheckBox)sender).Checked;
        }

        private void chbBalance_CheckedChanged(object sender, EventArgs e)
        {
            Series seriesBalance = this.chartAmortization.Series[1];
            seriesBalance.Enabled = ((CheckBox)sender).Checked;
        }

        private void chbShowValues_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Series series in this.chartAmortization.Series)
            {
                series.IsValueShownAsLabel = ((CheckBox)sender).Checked;
            }
        }

        private void ClearChart()
        {
            this.chartAmortization.Titles.Clear();
            foreach (Series series in this.chartAmortization.Series)
            {
                series.Points.Clear();
            }
        }

        private void chbPercentageRate_CheckedChanged(object sender, EventArgs e)
        {
            bool state = ((CheckBox)sender).Checked;
            nudPercentageRate.Enabled = state;
            nudCurrencyRate.Enabled = !state;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK && this.openFileDialog1.FileName != "")
            {
                InputDataAmortization input = AmortizationIO.Read(this.openFileDialog1.FileName);
                SetInputData(input);
                UpdateData(input);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK && this.saveFileDialog1.FileName != "")
            { 
                AmortizationIO.Write(this.saveFileDialog1.FileName, GetInputData());
            }
        }

        private void chbDigression_CheckedChanged(object sender, EventArgs e)
        {
            bool state = ((CheckBox)sender).Checked;
            this.operationType = state ? OperationTypes.BALANCE_AND_RESIDUAL : OperationTypes.ACQUISITION;
            nudDigression.Enabled = state;
        }

        private void rbPaToP_CheckedChanged(object sender, EventArgs e)
        {
            this.lblPercentage.Text = "p = ";
            this.lblFormula.Text = "Pa = (100 * p) / (100 - p) =";
            this.lblResult.Text = "x,xxx %";
        }

        private void rbPToPa_CheckedChanged(object sender, EventArgs e)
        {
            this.lblPercentage.Text = "Pa = ";
            this.lblFormula.Text = "p = (100 * Pa) / (100 + Pa) =";
            this.lblResult.Text = "x,xxx %";
        }

        private void btnCalculateAnticipative_Click(object sender, EventArgs e)
        {
            if (this.rbPToPa.Checked)
            {
                this.lblResult.Text = ((100 * nudPercentage.Value) / (100 + nudPercentage.Value)).ToString("N3") + " %";
            }
            else if (this.rbPaToP.Checked) 
            {
                this.lblResult.Text = ((100 * nudPercentage.Value) / (100 - nudPercentage.Value)).ToString("N3") + " %";
            }
        }

    }
}
