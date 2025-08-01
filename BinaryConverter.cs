using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideInImage
{
    internal class BinaryConverter
    {
        public BinaryConverter() { }

        public BitArray ConvertStringToBitArray(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            BitArray output = new BitArray(bytes);

            return output;
        }

        public string ConvertBitArrayToString(BitArray input)
        {
            int numBytes = (input.Length + 7) / 8;
            byte[] bytes = new byte[numBytes];
            input.CopyTo(bytes, 0);

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
