namespace OS_Priority
{
    public class Process
    {
        private string name;
        private int priority;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
            }
        }

        public Process(string name, int priority)
        {
            this.Name = name;
            this.Priority = priority;
        }
    }
}
