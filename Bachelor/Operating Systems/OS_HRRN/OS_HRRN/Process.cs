namespace OS_HRRN
{
    public class Process
    {
        private int number;
        private int arrivalTime;
        private int serviceTime;

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public int ArrivalTime
        {
            get
            {
                return arrivalTime;
            }

            set
            {
                arrivalTime = value;
            }
        }

        public int ServiceTime
        {
            get
            {
                return serviceTime;
            }

            set
            {
                serviceTime = value;
            }
        }

        public Process(int number, int arrivalTime, int serviceTime)
        {
            this.Number = number;
            this.ArrivalTime = arrivalTime;
            this.ServiceTime = serviceTime;
        }
    }
}
