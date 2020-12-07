using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace lab12
{
    class PhonesIOText : AbstractPhoneIO
    {
        public override List<Phone> phones_ { get; set; }
        public override string path_ { get; set; }

        public override List<Phone> Read(string path)
        {
            List<Phone> answer = new List<Phone>();
            path_ = path;
            StreamReader ostream = new StreamReader(path);
            string next_line;
            while ((next_line = ostream.ReadLine()) != null)
            {
                next_line.Replace("\n", "");
                answer.Add(new Phone(next_line));
            }
            return answer;
        }
        
        public override bool Write(string path, List<Phone> phones)
        {
            path_ = path;
            phones_ = phones;
            StreamWriter fstream = new StreamWriter(path);
                
            foreach (Phone phone in phones)
            {
                fstream.WriteLine(phone.Key);
            }

            fstream.Flush();
            fstream.Close();
            return true;
        }
    }
}
