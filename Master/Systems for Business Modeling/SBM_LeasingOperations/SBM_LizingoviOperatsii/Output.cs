namespace SBM_LizingoviOperatsii
{

    public class Output
    {
        private int numberOfPayment;
        public int NumberOfPayment
        {
            get { return numberOfPayment; }
            set { numberOfPayment = value; }
        }

        private double sizeOfPayment;
        public double SizeOfPayment
        {
            get { return sizeOfPayment; }
            set { sizeOfPayment = value; }
        }

        private double updatedPayment;
        public double UpdatedPayment
        {
            get { return updatedPayment; }
            set { updatedPayment = value; }
        }

        public Output() { }

        public Output(int numberOfPayment, double sizeOfPayment, double updatedPayment)
        {
            this.NumberOfPayment = numberOfPayment;
            this.SizeOfPayment = sizeOfPayment;
            this.updatedPayment = updatedPayment;
        }
    }
}
