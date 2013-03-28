using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Apex.Consistency
{
    public static class ColorConverter
    {
        public static Color ConvertFromString(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
            {
                throw new ArgumentNullException("hexString");
            }

            // remove any "#" characters
            while (hexString.StartsWith("#"))
            {
                hexString = hexString.Substring(1);
            }

            int num = 0;
            // get the number out of the string 
            if (!Int32.TryParse(hexString, System.Globalization.NumberStyles.HexNumber, null, out num))
            {
                throw new ArgumentException("Color not in a recognized Hex format.");
            }

            int[] pieces = new int[4];
            if (hexString.Length > 7)
            {
                pieces[0] = ((num >> 24) & 0x000000ff);
                pieces[1] = ((num >> 16) & 0x000000ff);
                pieces[2] = ((num >> 8) & 0x000000ff);
                pieces[3] = (num & 0x000000ff);
            }
            else if (hexString.Length > 5)
            {
                pieces[0] = 255;
                pieces[1] = ((num >> 16) & 0x000000ff);
                pieces[2] = ((num >> 8) & 0x000000ff);
                pieces[3] = (num & 0x000000ff);
            }
            else if (hexString.Length == 3)
            {
                pieces[0] = 255;
                pieces[1] = ((num >> 8) & 0x0000000f);
                pieces[1] += pieces[1] * 16;
                pieces[2] = ((num >> 4) & 0x000000f);
                pieces[2] += pieces[2] * 16;
                pieces[3] = (num & 0x000000f);
                pieces[3] += pieces[3] * 16;
            }
            return Color.FromArgb((byte)pieces[0], (byte)pieces[1], (byte)pieces[2], (byte)pieces[3]);
        
        }
    }
}
