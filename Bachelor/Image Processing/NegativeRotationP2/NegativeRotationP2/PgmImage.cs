﻿namespace NegativeRotationP2
{
    using System;
    using System.IO;

    public class PgmImage
    {
        private int width;
        private int height;
        private int maxVal;
        private byte[][] data;
        private string magicNumber;
        private string comment;

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public int MaxVal
        {
            get
            {
                return maxVal;
            }

            set
            {
                maxVal = value;
            }
        }

        public byte[][] Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public string MagicNumber
        {
            get
            {
                return magicNumber;
            }

            set
            {
                magicNumber = value;
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }

            set
            {
                comment = value;
            }
        }

        public string Header
        {
            get
            {
                return this.MagicNumber + Convert.ToChar(10) +
                       '#' + this.comment + Convert.ToChar(10) +
                        this.width.ToString() + " " + this.height.ToString() + Convert.ToChar(10) +
                        this.maxVal.ToString() + Convert.ToChar(10);
            }
        }

        public PgmImage(int width, int height, string magicNumber, string comment, int maxVal)
        {
            this.width = width;
            this.height = height;
            this.data = new byte[height][];
            for (int i = 0; i < height; i++)
            {
                this.data[i] = new byte[width];
            }
            this.magicNumber = magicNumber;
            this.comment = comment;
            this.maxVal = maxVal;
        }

        public PgmImage(string filePath)
        {
            ReadPGM(filePath);
        }

        public void Save(string filePath)
        {
            WritePGM(filePath);
        }

        private void ReadPGM(string filePath)
        {
            /*
              P2
              # feep.ascii.pgm
              24 7
              15
              [data]

            OR

              P2
              24 7
              15
              [data]
            */


            string line;
            FileStream InputStream = File.OpenRead(filePath);
            using (StreamReader PGMReader = new StreamReader(InputStream))
            {
                this.magicNumber = PGMReader.ReadLine().Trim();
                if (this.magicNumber != "P2")
                {
                    throw new InvalidDataException("Invalid magic number " + magicNumber);
                }
                this.comment = PGMReader.ReadLine().Trim();
                if (!this.comment.StartsWith("#"))
                {
                    line = this.comment;
                    this.comment = null;
                }
                else
                {
                    line = PGMReader.ReadLine().Trim();
                }

                int[] size = Array.ConvertAll(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
                this.width = size[0];
                this.height = size[1];
                this.data = new byte[height][];
                for (int i = 0; i < height; i++)
                {
                    this.data[i] = new byte[width];
                }
                this.maxVal = int.Parse(PGMReader.ReadLine().Trim());

                // read data
                int row = 0, column = 0;

                while ((line = PGMReader.ReadLine()) != null)
                {
                    byte[] textRow = Array.ConvertAll(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), byte.Parse);

                    for (int i = 0; i < textRow.Length; i++)
                    {
                        if (column == this.Width)
                        {
                            row++;
                            column = 0;
                        }

                        this.data[row][column++] = textRow[i];
                    }
                }

            }
            InputStream.Close();
        }

        private void WritePGM(string filePath)
        {
            FileStream OutputStream = File.Create(filePath);
            BinaryWriter PGMWriter = new BinaryWriter(OutputStream);

            string PGMInfo = this.Header;
            byte[] PGMInfoBuffer = System.Text.ASCIIEncoding.Default.GetBytes(PGMInfo);
            PGMWriter.Write(PGMInfoBuffer);

            if (this.magicNumber != "P2")
            {
                throw new InvalidDataException("Invalid magic number " + magicNumber);
            }

            byte NewLineAsciiCode = 10;
            byte SpaceAsciiCode = 32;
            int Temp;

            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    //File is text based, convert every byte to text representation followed by "space"
                    Temp = this.data[i][j];
                    byte[] TempByteArray = System.Text.ASCIIEncoding.Default.GetBytes(Temp.ToString());
                    PGMWriter.Write(TempByteArray);
                    PGMWriter.Write(SpaceAsciiCode);
                }
                PGMWriter.Write(NewLineAsciiCode);
            }
            PGMWriter.Close();

        }
    }
}
