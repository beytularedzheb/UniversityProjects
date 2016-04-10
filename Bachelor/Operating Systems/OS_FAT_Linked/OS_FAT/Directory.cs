using System;
using System.Drawing;

namespace OS_FAT
{
    public class Directory
    {
        private String fileName;
        private int blockNumber;
        private uint size;
        private Color color;

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        public int BlockNumber
        {
            get
            {
                return blockNumber;
            }

            set
            {
                blockNumber = value;
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
