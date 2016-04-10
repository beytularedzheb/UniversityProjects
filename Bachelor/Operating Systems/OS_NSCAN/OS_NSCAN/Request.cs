namespace OS_NSCAN
{
    class Request
    {
        private decimal cylinder;

        public decimal Cylinder
        {
            get
            {
                return cylinder;
            }

            set
            {
                cylinder = value;
            }
        }

        public Request(decimal cylinder)
        {
            this.Cylinder = cylinder;
        }
    }
}
