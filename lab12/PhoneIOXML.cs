using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace lab12
{
    class PhoneIOXML : AbstractPhoneIO
    {
        public override List<Phone> phones_ { get; set; }
        public override string path_ { get; set; }
        public override List<Phone> Read(string path)
        {
            path_ = path;
            XmlDocument xDoc = new XmlDocument();
            List<Phone> answer = new List<Phone>();
            try
            {
                xDoc.Load(path);
                XmlNode xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    string key = xnode.Attributes["key"].Value;
                    answer.Add(new Phone(key));
                }
                Console.Read();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return answer;
        }

        public override bool Write(string path, List<Phone> phones)
        {
            path_ = path;
            phones_ = phones;
                XmlDocument xDoc = new XmlDocument();
                XmlNode xRoot = xDoc.CreateElement("phones");
                xDoc.AppendChild(xRoot);
                foreach (Phone phone in phones)
                {
                    XmlElement phoneElem = xDoc.CreateElement("phone");
                    phoneElem.SetAttribute("key", phone.Key);
                    xRoot.AppendChild(phoneElem);
                }
                xDoc.Save(path);
            return true;
        }
    }
}
