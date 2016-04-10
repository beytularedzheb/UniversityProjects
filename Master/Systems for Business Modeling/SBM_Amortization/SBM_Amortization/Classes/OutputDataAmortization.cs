namespace SBM_Amortization
{
    public class OutputDataAmortization
    {
        private uint numberOfYear; // n
        private double balance; // Dn
        private double amortizationSum; // Rn

        public uint NumberOfYear
        {
            get { return numberOfYear; }
            set { numberOfYear = value; }
        }

        public double AmortizationSum
        {
            get { return amortizationSum; }
            set { amortizationSum = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public OutputDataAmortization() { }

        public OutputDataAmortization(uint numberOfYear, double balance, double amortizationSum)
        {
            this.numberOfYear = numberOfYear;
            this.balance = balance;
            this.amortizationSum = amortizationSum;
        }
        
    }
}
