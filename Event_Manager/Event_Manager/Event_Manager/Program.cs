using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Manager
{
    class Program
    {
        static void Main(string[] args)
        {

            View.EventManagementView eventManagerView = new View.EventManagementView();
            eventManagerView.Show();
        }
    }
}
