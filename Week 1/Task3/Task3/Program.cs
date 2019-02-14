using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine(); // Reading string 
            int a = int.Parse(s); // We converted to int
            string d = Console.ReadLine(); // Creating sequence of numbers
            string[] num = d.Split(); // Creating array and spliting numbers by space

            for (int i = 0; i < num.Length; i++)
            {
                Console.Write(num[i] + " " + num[i] + " "); // Just duplicate that numbers
            }
        }
    }
}
