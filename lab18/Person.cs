using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab18
{
    class Person
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string City { get; set; }

        public Person(string name, string job, string city)
        {
            this.Name = name;
            this.Job = job;
            this.City = city;
        }

        public override string ToString()
        {
            return "Name: " + Name + "\nJob: " + Job + "\nCity: " + City;
        }
    }
}
