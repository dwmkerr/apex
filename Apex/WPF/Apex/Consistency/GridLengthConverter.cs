using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Apex.Consistency
{
    public class GridLengthConverter
    {
        /// <summary>
        /// Create a grid length from a string, consistently in WPF, WP7 and SL.
        /// </summary>
        /// <param name="gridLength">The grid length, e.g. 4*, Auto, 23 etc.</param>
        /// <returns>A gridlength.</returns>
        public GridLength ConvertFromString(string gridLength)
        {
            //  If we're NOT in silverlight, we have a gridlength converter
            //  we can use.
#if !SILVERLIGHT

            //  Create the standard windows grid length converter.
            System.Windows.GridLengthConverter gridLengthConverter = new System.Windows.GridLengthConverter();

            //  Return the converted grid length.
            return (GridLength)gridLengthConverter.ConvertFromString(gridLength);

#else

            //   We are in silverlight and do not have a grid length converter.
            //  We can do the conversion by hand.
            
            //  Auto is easy.
            if(gridLength == "Auto")
            {
                return new GridLength(1, GridUnitType.Auto);
            }
            else if (gridLength.Contains("*"))
            {
                //  It's a starred value, remove the star and get the coefficient as a double.
                double coefficient = 1;
                string starVal = gridLength.Replace("*", "");
            
                //  If there is a coefficient, try and convert it.
                //  If we fail, throw an exception.
                if (starVal.Length > 0 && double.TryParse(starVal, out coefficient) == false)
                    throw new Exception("'" + gridLength + "' is not a valid value."); 
            
                //  We've handled the star value.
                return new GridLength(coefficient, GridUnitType.Star);
            }
            else
            {
                //  It's not auto or star, so unless it's a plain old pixel 
                //  value we must throw an exception.
                double pixelVal = 0;
                if(double.TryParse(gridLength, out pixelVal) == false)
                    throw new Exception("'" + gridLength + "' is not a valid value.");
              
                //  We've handled the star value.
                return new GridLength(pixelVal, GridUnitType.Pixel);
            }
#endif
        }
    }
}
