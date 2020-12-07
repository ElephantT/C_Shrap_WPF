using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab12
{
    class PhoneIOBinary : AbstractPhoneIO
    {
        public override List<Phone> phones_ { get; set; }
        public override string path_ { get; set; }
        public override List<Phone> Read(string path)
        {
            path_ = path;
            List<Phone> answer = new List<Phone>();
            FileStream readStream;
            readStream = new FileStream(path, FileMode.Open);
            BinaryReader readBinary = new BinaryReader(readStream);
            while (readBinary.PeekChar() != -1)
            {
                string key = readBinary.ReadString();
                answer.Add(new Phone(key));
            }
            readBinary.Close();
            return answer;
        }

        public override bool Write(string path, List<Phone> phones)
        {
            path_ = path;
            phones_ = phones;
            BinaryWriter fstream = new BinaryWriter(File.OpenWrite(path));
            foreach (Phone phone in phones)
            {

                fstream.Write(phone.Key);
            }
            fstream.Flush();
            fstream.Close();
            return true;
        }
    }
}
