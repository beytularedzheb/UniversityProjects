namespace OS_SSTF
{
    public class Global
    {
        private static decimal numberOfCylinders;
        private static decimal headerPosition;

        public static decimal NumberOfCylinders
        {
            get
            {
                return numberOfCylinders;
            }

            set
            {
                numberOfCylinders = value;
            }
        }

        public static decimal HeaderPosition
        {
            get
            {
                return headerPosition;
            }

            set
            {
                if (value >= numberOfCylinders)
                {
                    headerPosition = numberOfCylinders - 1;
                }
                else
                {
                    headerPosition = value;
                }
            }
        }
    }
}
