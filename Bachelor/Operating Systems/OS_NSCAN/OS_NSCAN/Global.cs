namespace OS_NSCAN
{
    public class Global
    {
        private static decimal numberOfCylinders;
        private static decimal headerPosition = 0;
        private static decimal numberOfSteps;
        private static bool direction;

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

        public static decimal NumberOfSteps
        {
            get
            {
                return numberOfSteps;
            }

            set
            {
                numberOfSteps = value;
            }
        }

        public static bool Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }
    }
}
