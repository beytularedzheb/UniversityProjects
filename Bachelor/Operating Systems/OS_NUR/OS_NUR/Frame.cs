namespace OS_NUR
{
    public class Frame
    {
        private long id;
        private bool referenced;
        private bool modified;

        public long Id
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

        public bool Referenced
        {
            get
            {
                return referenced;
            }

            set
            {
                referenced = value;
            }
        }

        public bool Modified
        {
            get
            {
                return modified;
            }

            set
            {
                modified = value;
            }
        }

        public Frame(long id, bool referenced, bool modified)
        {
            this.Id = id;
            this.Referenced = referenced;
            this.Modified = modified;
        }
    }
}
