using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Manager.View
{
    public class EventManagementView
    {
        public static bool ValidDate = false;
        public static bool ValidTime = false;

        public void Show()
        {
            while (true)
            {
                Event_Manager.Tool.EventManagementEnum choice = RenderMenu();

                try
                {
                    switch (choice)
                    {
                        case Event_Manager.Tool.EventManagementEnum.Select:
                            {
                                GetAll();
                                break;
                            }
                        case Event_Manager.Tool.EventManagementEnum.View:
                            {
                                View();
                                break;
                            }
                        case Event_Manager.Tool.EventManagementEnum.Insert:
                            {
                                Add();
                                break;
                            }
                        case Event_Manager.Tool.EventManagementEnum.Update:
                            {
                                Update();
                                break;
                            }
                        case Event_Manager.Tool.EventManagementEnum.Delete:
                            {
                                Delete();
                                break;
                            }
                        case Event_Manager.Tool.EventManagementEnum.Exit:
                            {
                                return;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey(true);
                }
            }
        }

        private Event_Manager.Tool.EventManagementEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("[G]et all Events");
                Console.WriteLine("[V]iew Event");
                Console.WriteLine("[A]dd Event");
                Console.WriteLine("[E]dit Event");
                Console.WriteLine("[D]elete Event");
                Console.WriteLine("E[x]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "G":
                        {
                            return Event_Manager.Tool.EventManagementEnum.Select;
                        }
                    case "V":
                        {
                            return Event_Manager.Tool.EventManagementEnum.View;
                        }
                    case "A":
                        {
                            return Event_Manager.Tool.EventManagementEnum.Insert;
                        }
                    case "E":
                        {
                            return Event_Manager.Tool.EventManagementEnum.Update;
                        }
                    case "D":
                        {
                            return Event_Manager.Tool.EventManagementEnum.Delete;
                        }
                    case "X":
                        {
                            return Event_Manager.Tool.EventManagementEnum.Exit;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        private void GetAll()
        {
            Console.Clear();

            Repository.EventRepository eventsRepository = new Repository.EventRepository("events.txt");
            List<Event> events = eventsRepository.GetAll();

            foreach (Event Event in events)
            {
                Console.WriteLine("ID:" + Event.Id);
                Console.WriteLine("Username :" + Event.Name);
                Console.WriteLine("Password :" + Event.Location);
                Console.WriteLine("Start Date and Time :" + Event.StartDateInput + " " + Event.StartTimeInput);
                Console.WriteLine("End Date and Time :" + Event.EndDateInput + " " + Event.EndTimeInput);

                Console.WriteLine("---------------------------------");
            }

            Console.ReadKey(true);
        }

        private void View()
        {
            Console.Clear();

            Console.Write("Event ID: ");
            int eventId = Convert.ToInt32(Console.ReadLine());

            Repository.EventRepository eventsRepository = new Repository.EventRepository("events.txt");

            Event events = eventsRepository.GetById(eventId);
            if (events == null)
            {
                Console.Clear();
                Console.WriteLine("Event not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("ID:" + events.Id);
            Console.WriteLine("Username :" + events.Name);
            Console.WriteLine("Password :" + events.Location);
            Console.WriteLine("Start Date and Time :" + events.StartDateInput + " " + events.StartTimeInput);
            Console.WriteLine("End Date and Time :" + events.EndDateInput + " " + events.EndTimeInput);


            Console.ReadKey(true);
        }

        private void Add()
        {
            Console.Clear();

            Event events = new Event();

            Console.WriteLine("Add new Event:");

            Console.Write("Name: ");
            events.Name = Console.ReadLine();

            Console.Write("Location: ");
            events.Location = Console.ReadLine();

            while (!ValidDate)
            {
                Console.Write("Please enter Start Date in format DD.MM.YYYY: ");
                events.StartDateInput = Console.ReadLine();
                ValidDate = ValidateDate.ValidateData(events.StartDateInput);

                Console.Write("Please enter End Date in format DD.MM.YYYY: ");
                events.EndDateInput = Console.ReadLine();
                ValidDate = ValidateDate.ValidateData(events.EndDateInput);
            }
            while (!ValidTime)
            {
                Console.Write("Please enter Start Time in format HH:mm:ss: ");
                events.StartTimeInput = Console.ReadLine();
                ValidTime = ValidateTime.ValidatingTime(events.StartTimeInput);

                Console.Write("Please enter End Time in format HH:mm:ss: ");
                events.EndTimeInput = Console.ReadLine();
                ValidTime = ValidateTime.ValidatingTime(events.EndTimeInput);
            }

            Repository.EventRepository eventsRepository = new Repository.EventRepository("events.txt");
            eventsRepository.Save(events);

            Console.WriteLine("Event saved successfully.");
            Console.ReadKey(true);
        }

        private void Update()
        {
            Console.Clear();

            Console.Write("Event ID: ");
            int eventId = Convert.ToInt32(Console.ReadLine());

            Repository.EventRepository eventsRepository = new Repository.EventRepository("events.txt");
            Event events = eventsRepository.GetById(eventId);

            if (events == null)
            {
                Console.Clear();
                Console.WriteLine("Event not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Editing Event (" + events.Name + ")");
            Console.WriteLine("ID:" + events.Id);

            Console.WriteLine("Name :" + events.Name);
            Console.Write("New Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Location :" + events.Location);
            Console.Write("New Location:");
            string location = Console.ReadLine();

            Console.WriteLine("Start Date :" + events.StartDateInput);
            Console.Write("New Start Date in format DD.MM.YYYY: ");
            string startDate = Console.ReadLine();
            ValidDate = ValidateDate.ValidateData(startDate);

           Console.WriteLine("End Date :" + events.EndDateInput);
           Console.Write("New End Date in format DD.MM.YYYY: ");
           string endDate = Console.ReadLine();
           ValidDate = ValidateDate.ValidateData(endDate);

           Console.WriteLine("Start Time :" + events.StartTimeInput);
           Console.Write("New Start Time in format HH:mm:ss: ");
           string startTime = Console.ReadLine();
           ValidTime = ValidateTime.ValidatingTime(startTime);

           Console.WriteLine("End Time :" + events.EndTimeInput);
           Console.Write("New End Time in format HH:mm:ss: ");
           string endTime = Console.ReadLine();
           ValidTime = ValidateTime.ValidatingTime(endTime);

            if (!string.IsNullOrEmpty(name))
                events.Name = name;
            if (!string.IsNullOrEmpty(location))
                events.Location = location;
            if (!string.IsNullOrEmpty(startDate))
                events.StartDateInput = startDate;
            if (!string.IsNullOrEmpty(endDate))
                events.EndDateInput = endDate;
            if (!string.IsNullOrEmpty(startTime))
                events.StartTimeInput = startTime;
            if (!string.IsNullOrEmpty(endTime))
                events.EndTimeInput = endTime;

            eventsRepository.Save(events);

            Console.WriteLine("Event saved successfully.");
            Console.ReadKey(true);
        }

        private void Delete()
        {
            Repository.EventRepository eventsRepository = new Repository.EventRepository("events.txt");

            Console.Clear();

            Console.WriteLine("Delete Event:");
            Console.Write("Event Id: ");
            int eventId = Convert.ToInt32(Console.ReadLine());

            Event events = eventsRepository.GetById(eventId);
            if (events == null)
            {
                Console.WriteLine("Event not found!");
            }
            else
            {
                eventsRepository.Delete(events);
                Console.WriteLine("Event deleted successfully.");
            }
            Console.ReadKey(true);
        }
    }
}
