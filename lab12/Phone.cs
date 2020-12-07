using System;
using System.Collections.Generic;
using System.Text;

namespace lab12
{
    class Phone
    {
        private static Phone phone;
        public string Key { get; private set; }

        public Phone(string key)
        {
            this.Key = key;
        }

    }
}
