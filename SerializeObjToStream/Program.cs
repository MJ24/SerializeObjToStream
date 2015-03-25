using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializeObjToStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Test\MyObjTxt.txt";
            Person p = new Person("MJ", 24);

            using (FileStream fsWrite = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fsWrite, p);
            }

            using (FileStream fsRead = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Person receivedP = (Person)bf.Deserialize(fsRead);
                Console.WriteLine(receivedP.Name);
                Console.WriteLine(receivedP.Age);
            }
            Console.ReadLine();
        }
    }

    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
