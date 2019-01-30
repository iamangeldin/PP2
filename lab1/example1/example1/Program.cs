using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example1
{
    class Program
    {
        public static bool isPrime(int a) 
        {
            bool ok = true;
            if(a == 1)
            {
                ok = false;
            }
            for(int i = 2; i <= Math.Sqrt(a); i++)
            {
                if(a%i == 0)
                {
                    ok = false;
                    
                }
            }
            return ok;
 
        }
        static void Main(string[] args)
        {
            string res = "";
            int x = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(' ');
            for(int i = 0; i < a.Count(); i++)
            {
                if (isPrime(int.Parse(a[i])) == true)
                {
                    res += a[i] + " ";
                }
            }
            Console.WriteLine(res.Length/2);
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
