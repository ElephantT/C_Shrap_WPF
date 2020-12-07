using System;
using System.Collections.Generic;
using System.Text;

namespace lab12
{
    class PhoneIOFactory
    {
        public string format_ { get; }

        public PhoneIOFactory(string format)
        {
            this.format_ = format;
        }
        
        public AbstractPhoneIO GetIO(string format)
        {
            if (format.Length == 0)
            {
                format = format_;
            } else
            {
                format = format.ToLower();
            }
            if (format == "text")
            {
                return new PhonesIOText();
            }
            if (format == "xml")
            {
                return new PhoneIOXML();
            }
            if (format == "bin")
            {
                return new PhoneIOBinary();
            }
            Console.WriteLine("wrong format type, you got IO Text");
            return new PhonesIOText();
        }
    }
}
