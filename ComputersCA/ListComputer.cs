using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComputersCA
{
    public class ListComputer
    {
        List<Computers> computers = new List<Computers>()
        {
            new Computers {iIndex = 0, iModel = "Asus", iPrice = 13800.90, iCPU = "Intel", iRAM = 8 },
            new Computers {iIndex = 1, iModel = "Asus", iPrice = 15734.00, iCPU = "Intel", iRAM = 8 },
            new Computers {iIndex = 2, iModel = "Asus", iPrice = 13455.00, iCPU = "Intel", iRAM = 8 }
        };
        public void display()
        {
            Console.WriteLine("Items in list: {0}", computers.Count);
            foreach (Computers c in computers)
                Console.WriteLine(c);
        }

        public void addElement()
        {
            Console.WriteLine("Add new computer: Index, Model, Price, CPU, RAM.");
            computers.Insert(3, new Computers
            {
                iIndex = Convert.ToInt32(Console.ReadLine()),
                iModel = Console.ReadLine(),
                iPrice = Convert.ToDouble(Console.ReadLine()),
                iCPU = Console.ReadLine(),
                iRAM = Convert.ToInt32(Console.ReadLine())
            });
            foreach (Computers c in computers)
                Console.WriteLine(c);
        }
        public void removeElement()
        {
            Console.WriteLine("Remove element: enter index.");
            computers.RemoveAt(Convert.ToInt32(Console.ReadLine()));
            foreach (Computers c in computers)
                Console.WriteLine(c);
        }
        public void updateElement()
        {
            Console.WriteLine("Enter index element which you would like to change.");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter index where you would like to write.");
            int b = Convert.ToInt32(Console.ReadLine());
            computers[i].iIndex = b;
            foreach (Computers c in computers)
                Console.WriteLine(c);
        }
        public void Save()
        {
            Console.WriteLine("Write to file");
            string writePath = @"C:\Users\Дарья\source\repos\ComputersDBCW\ComputersCA\data.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (Computers c in computers)
                    sw.WriteLine(c);
            }
        }
        public void Load()
        {
            Console.WriteLine("Read from file:");
            string readPath = @"C:\Users\Дарья\source\repos\ComputersDBCW\ComputersCA\data.txt";
            using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}
