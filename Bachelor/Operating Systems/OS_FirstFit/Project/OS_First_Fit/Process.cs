using System;
using System.Drawing;

namespace OS_First_Fit
{
    public class Process
    {
        private String processId;
        private int startBlock;
        private uint size;
        private Color color;

        public string ProcessId
        {
            get
            {
                return processId;
            }

            set
            {
                processId = value;
            }
        }

        public int StartBlock
        {
            get
            {
                return startBlock;
            }

            set
            {
                startBlock = value;
            }
        }

        public uint Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }
    }
}
