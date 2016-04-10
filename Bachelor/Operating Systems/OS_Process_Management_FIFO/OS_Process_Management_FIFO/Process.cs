namespace OS_Process_Management_FIFO
{
    public class Process
    {
        int id;
        string name;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

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

        public Process(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
