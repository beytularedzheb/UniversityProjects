namespace SBM_Amortization
{
    using System;
    using System.IO;

    public static class AmortizationIO
    {
        public static InputDataAmortization Read(String filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {               
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (InputDataAmortization)binaryFormatter.Deserialize(stream);
            }
        }

        public static void Write(String filePath, InputDataAmortization objectToWrite)
        {
            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
    }
}
