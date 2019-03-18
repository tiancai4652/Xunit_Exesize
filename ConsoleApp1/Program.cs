using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 4;
            double b = 0;
            var c = a / b;

            int a1 = 4;
            int b1 = 0;
            var c1 = a1 / b1;

            var c2 = a / b1;
            var c3 = a1 / b;
        }
    }
}
