namespace SBM_Amortization
{
    [System.Serializable]
    public class InputDataAmortization
    {
        private double value; // A
        private double? percentageRate; // p
        private uint numberOfYears; // t
        private double currencyRate; // S
        private double digression; // B

        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public double? PercentageRate
        {
            get { return percentageRate; }
            set { percentageRate = value; }
        }

        public uint NumberOfYears
        {
            get { return numberOfYears; }
            set {
                if (value < 1)
                {
                    numberOfYears = 1;
                }
                else
                {
                    numberOfYears = value;
                }
            }
        }

        public double Digression
        {
            get { return digression; }
            set { digression = value; }
        }

        public double CurrencyRate
        {
            get { return currencyRate; }
            set { currencyRate = value; }
        }

        public InputDataAmortization(double value, double currencyRate, uint numberOfYears, double digression, double? percentageRate)
        {
            this.Value = value;
            this.CurrencyRate = currencyRate;
            this.NumberOfYears = numberOfYears;
            this.Digression = digression;
            this.PercentageRate = percentageRate;
        }
    }
}
