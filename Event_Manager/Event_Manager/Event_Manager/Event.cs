using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Manager
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string StartDateInput { get; set; }
        public string EndDateInput { get; set; }
        public string StartTimeInput { get; set; }
        public string EndTimeInput { get; set; }

    //    public Event(string name, string location)
    //    {
    //        this.Name = name;
    //        this.Location = location;
    //    }
    }
}
