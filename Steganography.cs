using System;
using System.IO;
using System.Collections;


    class Steganography
    {


       public static void Main(string[] args)
        {
            byte[] bmpBytes = new byte[] {
                0x42,0x4D,0x4C,0x00,0x00,0x00,0x00,0x00,
                0x00,0x00,0x1A,0x00,0x00,0x00,0x0C,0x00,
                0x00,0x00,0x04,0x00,0x04,0x00,0x01,0x00,
                0x18,0x00,0x00,0x00,0xFF,0xFF,0xFF,0xFF,
                0x00,0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,
                0xFF,0x00,0x00,0x00,0xFF,0xFF,0xFF,0x00,
                0x00,0x00,0xFF,0x00,0x00,0xFF,0xFF,0xFF,
                0xFF,0x00,0x00,0xFF,0xFF,0xFF,0xFF,0xFF,
                0xFF,0x00,0x00,0x00,0xFF,0xFF,0xFF,0x00,
                0x00,0x00
                };
            
            //Convert.ToByte("", 16) //16 represents the string we are converting from
            // take string and convert to byte
            // take 1 byte of hidingData and hide it in 4 bytes of data
            // 8 bits in 1 byte of hidingData with 2 bits hidden in each byte of image data gives
            // 4 bytes of image data to hide 1 byte of hidingData

            // take input from console. Convert string to byte. Perform XOR "^" with last two bits of each byte
            // print results of new bytes to console.
            string inputString = string.Join("", args);
            string[] commandData = inputString.Split(null);
            byte[] byteHidden = new byte[commandData.Length];
            int byteIndex = 26;

            for (int i = 0; i < commandData.Length; i++)
            {
                byteHidden[i] = Convert.ToByte(commandData[i], 16);
            }

            for (int i = 0; i < byteHidden.Length; i++)
            {
                string bitsHidden = Convert.ToString(byteHidden[i], 2).PadLeft(8, '0');

                for (int j = 0; j < 4; j++) 
                {
                    string partialBit = bitsHidden.Substring(j*2, 2).PadLeft(8, '0');
                    string bitsBMP = Convert.ToString(bmpBytes[byteIndex], 2).PadLeft(8, '0');
                    string c = "";
                    for (int k = 0; k < 8; k++) 
                    {
                        if (partialBit[k] == bitsBMP[k])
                            c += "0";
                        else
                            c += "1";
                    }
                    bmpBytes[byteIndex] = Convert.ToByte(c, 2);
                    byteIndex++;
                }
            }

            Console.WriteLine(BitConverter.ToString(bmpBytes).Replace("-", " "));

        }
    }

