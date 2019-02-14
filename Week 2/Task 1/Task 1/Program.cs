using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task_1
{
    class Program
    {
        public static void Palindrome()
        {
            StreamReader sr = new StreamReader(@"C: \Users\Админ\Desktop\lecture 1\text.txt");
            string s = sr.ReadToEnd();
            sr.Close();
            string s2 = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                s2 += s[i];
            }
            if (s == s2)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
        static void Main(string[] args)

        {
            Palindrome();
            Console.ReadKey();
        }
    }
}
