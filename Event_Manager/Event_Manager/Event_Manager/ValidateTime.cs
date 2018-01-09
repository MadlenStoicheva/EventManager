using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Manager
{
    class ValidateTime
    {
        public static bool ValidatingTime(string Time)
        {
            try
            {
                DateTime.ParseExact(Time, "HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                Console.WriteLine("Time Valid.");
            }
            catch
            {
                Console.WriteLine("Time Invalid.");
                return false;
            }
            return true;
        }
    }
}
