using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab12
{
    abstract class AbstractPhoneIO
    {
        public abstract List<Phone> phones_ { get; set; }
        public abstract string path_ { get; set; }
        public abstract List<Phone> Read(string path);
        public abstract bool Write(string path, List<Phone> phones);
    }
}
