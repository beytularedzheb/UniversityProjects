namespace OS_PageReplacement_FIFO
{
    using System;

    class Frame
    {
        private int id;
        private DateTime loadTime;

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

        public DateTime LoadTime
        {
            get
            {
                return loadTime;
            }

            set
            {
                loadTime = value;
            }
        }

        public Frame(int id, DateTime loadTime)
        {
            this.Id = id;
            this.LoadTime = loadTime;
        }
    }
}
