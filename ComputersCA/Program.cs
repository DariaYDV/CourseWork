using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersCA
{
    class Program
    {
        static void Main(string[] args)
        {
            ListComputer list = new ListComputer();
            list.display();
            list.addElement();
            list.Save();
            list.Load();
            list.removeElement();
            list.updateElement();
            Console.ReadKey();
        }
    }
}
