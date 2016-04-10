namespace OS_AddressTranslation
{
    using System;
    using System.Text;

    public class Page
    {
        private StringBuilder info;
        private static Random rand = new Random();

        public string Info
        {
            get
            {
                return info.ToString();
            }
        }

        public Page()
        {
            
            info = new StringBuilder();
             // 512 байта е големината на една страница
            for (int i = 0; i < 512; i++)
            {
                info.Append((char)rand.Next(33, 127));
            }
        }
    }
}
