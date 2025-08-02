using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HideInImage
{
    internal class HiddenDataController
    {
        public HiddenDataController() { }

        public Bitmap InjectDataIntoImage(BitArray binaryToInject, Bitmap currentImageBitmap)
        {
            int bitCounter = 0;
            int remainingBits = binaryToInject.Length;

            for (int i = 0; i < currentImageBitmap.Height; i++)
            {
                for (int j = 0; j < currentImageBitmap.Width; j++)
                {                    
                    int bitsToTake = Math.Min(3, remainingBits);

                    string bits = "";

                    for(int k = 0; k < bitsToTake; k++)
                    {
                        bits += binaryToInject[bitCounter + k] ? "1" : "0";
                    }

                    bits = bits.PadRight(3, '0');

                    currentImageBitmap.SetPixel(j, i, InjectThreeBitsIntoPixel(currentImageBitmap.GetPixel(j, i), bits, (bitsToTake == remainingBits)));

                    bitCounter += bitsToTake;
                    remainingBits = binaryToInject.Length - bitCounter;

                    if (remainingBits == 0)
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

        public BitArray ExtractDataFromCurrentImage(Bitmap currentImageBitmap)
        {
            List<bool> data = new List<bool>();
            BitArray empty = new BitArray(0);


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
                                string threeBits = ExtractThreeBitsFromPixel(currentImageBitmap.GetPixel(j, i));

                                foreach(char bit in threeBits)
                                {
                                    if(bit == '1')
                                    {
                                        data.Add(true);
                                    }
                                    else
                                    {
                                        data.Add(false);
                                    }
                                }
                            }
                            else
                            {
                                BitArray bits = new BitArray(data.ToArray());
                                return bits;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Current image seems to have no data embedded!");                    
                    return empty;
                }
            }
            else
            {
                MessageBox.Show("Upload an image first!");
                return empty;
            }
            return empty;
        }

        private string ExtractThreeBitsFromPixel(Color pixel)
        {
            string red = fillUpByte(Convert.ToString(pixel.R, 2));
            string green = fillUpByte(Convert.ToString(pixel.G, 2));
            string blue = fillUpByte(Convert.ToString(pixel.B, 2));

            return red[7].ToString() + green[7] + blue[7];
        }

        public bool CurrentImageHasWatermark(Bitmap currentImageBitmap)
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
        
    }
}
