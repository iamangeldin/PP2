using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task_2
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\Админ\Desktop\lecture 1\prime.txt"); // input
            string s = sr.ReadToEnd();  //это читает все
            string[] arr = s.Split();

            List<int> List = new List<int>();
            Console.WriteLine(s);
            for (int i = 0; i < arr.Length; i++)
            {
                int sum = 0;
                if ((int.Parse(arr[i])) == 1)
                {
                    continue;
                }
                for (int j = 2; j < (int.Parse(arr[i])); j++)
                {
                    if ((int.Parse(arr[i])) % j == 0)
                    {
                        sum++;
                    }
                }
                if (sum < 1)
                {
                    List.Add((int.Parse(arr[i])));
                }
            }
            sr.Close();
            StreamWriter sw = new StreamWriter(@"C:\Users\Админ\Desktop\lecture 1\primesol.txt");//output
            for (int i = 0; i < List.Count; i++)
            {
                sw.Write(List[i] + " ");

            }
            sw.Close();
            Console.ReadKey();
        }
    }
}