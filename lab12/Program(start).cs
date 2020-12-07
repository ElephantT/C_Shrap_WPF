using System;
using System.Collections.Generic;

namespace lab12
{
    /*Создать класс Phone для представления
информации о мобильном телефоне. Каждый объект этого класса должен содержать 
    уникальный ключ. Класс, генерирующий ключи, реализовать, используя
Singleton. Реализовать классы с операциями чтения и записи коллекций объектов Phone в файлы текстового, 
    бинарного и XML-формате. Организовать работу с
классами для хранения объектов, используя интерфейсы и порождающие шаблоны Factory Method и Abstract Factory.
    */
    class Program
    { 

    static bool AreEqual(List<Phone> left, List<Phone> right)
    {
        if (left.Count != right.Count)
        {
            Console.WriteLine("размер" + left.Count + " " + right.Count);
            return false;
        }
        for (int i = 0; i < left.Count; ++i)
        {
            // Console.WriteLine(left[i].Key);
            if (left[i].Key != right[i].Key)
            {
                return false;
            }
        }
        return true;
    }

    static bool TestFormat(List<Phone> left, string format, string path)
    {
        PhoneIOFactory factoryIO = new PhoneIOFactory(format);
        AbstractPhoneIO io = factoryIO.GetIO(format);
        io.Write(path, left);
        List<Phone> right = io.Read(path);
        return AreEqual(left, right);
    }

    static void Main(string[] args)
        {
            KeyGenerator generator_of_keys = KeyGenerator.GetKeyGenerator();
            List<Phone> phones = new List<Phone>();
            for (int i = 0; i < 5; ++i)
            {
                phones.Add(new Phone(generator_of_keys.GenerateKey()));
            }

            Console.WriteLine("text, binary, xml");
            Console.WriteLine("text ok? = " + TestFormat(phones, "text", "textt.txt"));
            Console.WriteLine("bin ok? = " + TestFormat(phones, "bin", "textb.bin"));
            Console.WriteLine("xml ok? = " + TestFormat(phones, "xml", "textx.xml"));

            Console.ReadLine();
        }
    }
}
