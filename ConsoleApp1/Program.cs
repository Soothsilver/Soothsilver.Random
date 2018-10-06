using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soothsilver.Random;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(R.Coin());
            List<int> a = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            a.Shuffle();
            var r = a.GetRandomWithoutReplacement(3);
            var s = a.GetRandomWithoutReplacementStrategy2(3);
            foreach(int i in r)
            {
                Console.WriteLine(i);
            }
            foreach (int i in s)
            {
                Console.WriteLine(i);
            }
            foreach (int i in a)
            {
                Console.WriteLine(i);
            }
        }
    }
}
