
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VIN_LIB.dll
{
    public  class VIN
    {

        public static Boolean CheckVin(string vin)
        {

            try
            {
                int count = 0;
                if (!Regex.IsMatch(vin, "^[A-HJ-NPR-Z0-9]{17}$"))
                {
                    return false;
                }
                else
                {
                    if (vin.Length == 17)
                    {
                        count++;

                    }
                    return true;
                }
            }
            catch
            {
                return false;

            }

        }
        public static String GetVINCountry(String vin)
        {
            if (CheckVin(vin))
            {
                //A BCDEH
                if (vin[0] == 'A' || vin[0] == 'B' || vin[0] == 'C' || vin[0] == 'D' || vin[0] == 'E' || vin[0] == 'H')
                {
                    return "Африка";
                }
                // 'J', 'K', 'L', 'M', 'N', 'P', 'R'
                if (vin[0] == 'J' || vin[0] == 'K' || vin[0] == 'L' || vin[0] == 'M' || vin[0] == 'N' || vin[0] == 'P' || vin[0] == 'R')
                {
                    return "Азия";
                }
                //'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
                if (vin[0] == 'S' || vin[0] == 'T' || vin[0] == 'U' || vin[0] == 'V' || vin[0] == 'W' || vin[0] == 'X' || vin[0] == 'Y' || vin[0] == 'Z')
                {
                    return "Европа";
                }
                if (vin[0] == '1' || vin[0] == '2' || vin[0] == '3' || vin[0] == '4' || vin[0] == '5')
                {
                    return "Северная Америка";
                }
                if (vin[0] == '6' || vin[0] == '7')
                {
                    return "Океания";   
                }
                if (vin[0] == '8' || vin[0] == '9')
                {
                    return "Южная Америка";
                }
            }
          
            return null;

        }
    }
}