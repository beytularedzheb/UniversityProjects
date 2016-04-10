namespace OS_AddressTranslation
{
    public class Frame
    {
        private int? page;

        public int? Page
        {
            get
            {
                return page;
            }

            set
            {
                page = value;
            }
        }

        public Frame(int? page)
        {
            this.Page = page;
        }
    }
}
