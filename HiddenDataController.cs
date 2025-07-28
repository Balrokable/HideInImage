using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideInImage
{
    internal class HiddenDataController
    {
        public HiddenDataController() { }

        public Bitmap InjectDataIntoImage(string binaryToInject, Bitmap currentImageBitmap)
        {
            int bitCounter = 0;
            int remainingBits = binaryToInject.Length;
            bool endOfData = false;

            for (int i = 0; i < currentImageBitmap.Height; i++)
            {
                for (int j = 0; j < currentImageBitmap.Width; j++)
                {
                    if (remainingBits <= 3)
                    {
                        endOfData = true;
                    }

                    int bitsToTake = Math.Min(3, remainingBits);
                    string bits = binaryToInject.Substring(bitCounter, bitsToTake).PadRight(3, '0');

                    currentImageBitmap.SetPixel(j, i, InjectThreeBitsIntoPixel(currentImageBitmap.GetPixel(j, i), bits, endOfData));

                    bitCounter += bitsToTake;
                    remainingBits = binaryToInject.Length - bitCounter;

                    if (endOfData)
                    {
                        return currentImageBitmap;
                    }
                }
            }
            return currentImageBitmap;
        }

        private Color InjectThreeBitsIntoPixel(Color pixel, string threeBits, bool setStopWatermark)
        {
            string redInBinary = fillUpByte(Convert.ToString(pixel.R, 2));
            string greenInBinary = fillUpByte(Convert.ToString(pixel.G, 2));
            string blueInBinary = fillUpByte(Convert.ToString(pixel.B, 2));

            if (threeBits.Length > 0)
            {
                redInBinary = redInBinary.Substring(0, 7) + threeBits[0];
            }
            if (threeBits.Length > 1)
            {
                greenInBinary = greenInBinary.Substring(0, 7) + threeBits[1];
            }
            if (threeBits.Length > 2)
            {
                blueInBinary = blueInBinary.Substring(0, 7) + threeBits[2];
            }

            int alpha = (setStopWatermark ? 254 : 255);

            Color modifiedPixel = Color.FromArgb(alpha, Convert.ToInt32(redInBinary, 2), Convert.ToInt32(greenInBinary, 2), Convert.ToInt32(blueInBinary, 2));

            return modifiedPixel;
        }

        private string fillUpByte(string toFillUp)
        {
            return toFillUp.PadLeft(8, '0');
        }

        public string ExtractDataFromCurrentImage(Bitmap currentImageBitmap)
        {
            string rawBinary = "";

            if (currentImageBitmap != null)
            {
                if (CurrentImageHasWatermark(currentImageBitmap))
                {
                    for (int i = 0; i < currentImageBitmap.Height; i++)
                    {
                        for (int j = 0; j < currentImageBitmap.Width; j++)
                        {
                            if (currentImageBitmap.GetPixel(j, i).A != 254)
                            {
                                rawBinary += ExtractThreeBitsFromPixel(currentImageBitmap.GetPixel(j, i));
                            }
                            else
                            {
                                return ConvertBinaryStringToString(rawBinary);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Current image seems to have no data embedded!");
                    return "";
                }
            }
            else
            {
                MessageBox.Show("Upload an image first!");
                return "";
            }
            return "";
        }

        private string ExtractThreeBitsFromPixel(Color pixel)
        {
            string red = fillUpByte(Convert.ToString(pixel.R, 2));
            string green = fillUpByte(Convert.ToString(pixel.G, 2));
            string blue = fillUpByte(Convert.ToString(pixel.B, 2));

            return red[7].ToString() + green[7] + blue[7];
        }

        private bool CurrentImageHasWatermark(Bitmap currentImageBitmap)
        {
            for (int i = 0; i < currentImageBitmap.Height; i++)
            {
                for (int j = 0; j < currentImageBitmap.Width; j++)
                {
                    if (currentImageBitmap.GetPixel(j, i).A == 254)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string ConvertStringToBinaryString(string input)
        {
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(input);
            StringBuilder sb = new StringBuilder();

            foreach (byte b in utf8Bytes)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        private string ConvertBinaryStringToString(string input)
        {
            List<byte> byteList = new List<byte>();
            int usableLength = input.Length - (input.Length % 8);

            for (int i = 0; i < usableLength; i += 8)
            {
                string byteString = input.Substring(i, 8);
                byteList.Add(Convert.ToByte(byteString, 2));
            }
            return Encoding.UTF8.GetString(byteList.ToArray());
        }

        private void imgPreviewBox_Click(object sender, EventArgs e)
        {

        }

    }
}
