using System;

namespace OS_LRU
{
    class Frame
    {
        private int id;
        private DateTime accessTime;

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

        public DateTime AccessTime
        {
            get
            {
                return accessTime;
            }

            set
            {
                accessTime = value;
            }
        }

        public Frame(int id, DateTime accessTime)
        {
            this.Id = id;
            this.AccessTime = accessTime;
        }
    }
}
