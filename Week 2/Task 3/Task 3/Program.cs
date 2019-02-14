using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


    class Program
{
    public static void Level(int level) // это для пробелов
    {
        for (int i = 0; i < level; i++)
        {
            Console.Write("   ");
        }
    }

    public static void FILE(DirectoryInfo dir, int level)
    {
        foreach (FileInfo f in dir.GetFiles()) // это чтобы вывести вайлы
        {
            Level(level);
            Console.WriteLine(f.Name);
        }
        foreach (DirectoryInfo d in dir.GetDirectories()) // это чтобы вывести папки,и через рекурсию заходим в каждую папку
        {
            Level(level);
            Console.WriteLine(d.Name);
            FILE(d, level + 1);
        }
    }
    static void Main(string[] args)
    {
        DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Админ\Desktop\PP2\Week 1");
        FILE(dir, 0);
        Console.ReadKey();
    }
}

