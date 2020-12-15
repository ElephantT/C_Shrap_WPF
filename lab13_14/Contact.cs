using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13_14
{
    class Contact
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public Contact(string Name, string Number)
        {
            this.Name = Name;
            this.Number = Number;
        }
    }
}
