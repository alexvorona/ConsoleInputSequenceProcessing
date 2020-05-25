using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Models;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor processor = new Processor();
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();

                processor.Process(keyInfo);
            }
            while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
