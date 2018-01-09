using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Manager.Repository
{
    public class EventRepository
    {
        private readonly string filePath;

        public EventRepository(string filePath)
        {
            this.filePath = filePath;
        }

        private int GetNextId()
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            int id = 1;
            try
            {
                while (!sr.EndOfStream)
                {
                    Event events = new Event();
                    events.Id = Convert.ToInt32(sr.ReadLine());
                    events.Name = sr.ReadLine();
                    events.Location = sr.ReadLine();
                    events.StartDateInput = sr.ReadLine();
                    events.StartTimeInput = sr.ReadLine();
                    events.EndDateInput = sr.ReadLine();
                    events.EndTimeInput = sr.ReadLine();

                    if (id <= events.Id)
                    {
                        id = events.Id + 1;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return id;
        }

        private void Insert(Event item)
        {
            item.Id = GetNextId();

            FileStream fs = new FileStream(filePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                sw.WriteLine(item.Id);
                sw.WriteLine(item.Name);
                sw.WriteLine(item.Location);
                sw.WriteLine(item.StartDateInput);
                sw.WriteLine(item.StartTimeInput);
                sw.WriteLine(item.EndDateInput);
                sw.WriteLine(item.EndTimeInput);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        private void Update(Event item)
        {
            string tempFilePath = "temp." + filePath;

            FileStream ifs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(ifs);

            FileStream ofs = new FileStream(tempFilePath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(ofs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Event events = new Event();
                    events.Id = Convert.ToInt32(sr.ReadLine());
                    events.Name = sr.ReadLine();
                    events.Location = sr.ReadLine();
                    events.StartDateInput = sr.ReadLine();
                    events.StartTimeInput = sr.ReadLine();
                    events.EndDateInput = sr.ReadLine();
                    events.EndTimeInput = sr.ReadLine();

                    if (events.Id != item.Id)
                    {
                        sw.WriteLine(events.Id);
                        sw.WriteLine(events.Name);
                        sw.WriteLine(events.Location);
                        sw.WriteLine(events.StartDateInput);
                        sw.WriteLine(events.StartTimeInput);
                        sw.WriteLine(events.EndDateInput);
                        sw.WriteLine(events.EndTimeInput);
                    }
                    else
                    {
                        sw.WriteLine(item.Id);
                        sw.WriteLine(item.Name);
                        sw.WriteLine(item.Location);
                        sw.WriteLine(item.StartDateInput);
                        sw.WriteLine(item.StartTimeInput);
                        sw.WriteLine(item.EndDateInput);
                        sw.WriteLine(item.EndTimeInput);
                    }
                }
            }
            finally
            {
                sw.Close();
                ofs.Close();
                sr.Close();
                ifs.Close();
            }

            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

        public Event GetById(int id)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Event events = new Event();
                    events.Id = Convert.ToInt32(sr.ReadLine());
                    events.Name = sr.ReadLine();
                    events.Location = sr.ReadLine();
                    events.StartDateInput = sr.ReadLine();
                    events.StartTimeInput = sr.ReadLine();
                    events.EndDateInput = sr.ReadLine();
                    events.EndTimeInput = sr.ReadLine();

                    if (events.Id == id)
                    {
                        return events;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }

        public List<Event> GetAll()
        {
            List<Event> result = new List<Event>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Event events = new Event();
                    events.Id = Convert.ToInt32(sr.ReadLine());
                    events.Name = sr.ReadLine();
                    events.Location = sr.ReadLine();
                    events.StartDateInput = sr.ReadLine();
                    events.StartTimeInput = sr.ReadLine();
                    events.EndDateInput = sr.ReadLine();
                    events.EndTimeInput = sr.ReadLine();

                    result.Add(events);
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }

        public void Delete(Event item)
        {
            string tempFilePath = "temp." + filePath;

            FileStream ifs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(ifs);

            FileStream ofs = new FileStream(tempFilePath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(ofs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Event events = new Event();
                    events.Id = Convert.ToInt32(sr.ReadLine());
                    events.Name = sr.ReadLine();
                    events.Location = sr.ReadLine();
                    events.StartDateInput = sr.ReadLine();
                    events.StartTimeInput = sr.ReadLine();
                    events.EndDateInput = sr.ReadLine();
                    events.EndTimeInput = sr.ReadLine();

                    if (events.Id != item.Id)
                    {
                        sw.WriteLine(events.Id);
                        sw.WriteLine(events.Name);
                        sw.WriteLine(events.Location);
                        sw.WriteLine(events.StartDateInput);
                        sw.WriteLine(events.StartTimeInput);
                        sw.WriteLine(events.EndDateInput);
                        sw.WriteLine(events.EndTimeInput);
                    }
                }
            }
            finally
            {
                sw.Close();
                ofs.Close();
                sr.Close();
                ifs.Close();
            }

            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

        public void Save(Event item)
        {
            if (item.Id > 0)
            {
                Update(item);
            }
            else
            {
                Insert(item);
            }
        }
    }
}
