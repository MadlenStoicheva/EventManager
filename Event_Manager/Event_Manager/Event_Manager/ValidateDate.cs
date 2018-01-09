using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Manager
{
    class ValidateDate
    {
        public static bool ValidateData(string Date)
        {
            try
            {
                DateTime.ParseExact(Date, "dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo);
                Console.WriteLine("Date Valid.");
            }
            catch
            {
                Console.WriteLine("Date Invalid.");
                return false;
            }
            return true;
        }
    }
}