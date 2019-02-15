using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FarManager
{
    class FarManager
    {
        public int cursor;
        public int size;
        public string path;
        DirectoryInfo DOP = null; //создаем пустую папку
        FileSystemInfo CUP = null;//создаем пустой файл
        public FarManager()// тут исползуем конструкторы
        {
            cursor = 0;
        }

        public FarManager(string path)
        {
            this.path = path;
            cursor = 0;
            DOP = new DirectoryInfo(path);
            size = DOP.GetFileSystemInfos().Length;
        }
        public void UP()
        {
            cursor--;
            if (cursor < 0)
            {
                cursor = size - 1;
            }
        }
        public void DOWN()
        {
            cursor++;
            if (cursor >= size)
            {
                cursor = 0;
            }
        }
        public void COLOR(FileSystemInfo fs, int index)
        {
            if (cursor == index)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                CUP = fs;

            }
            else if (fs.GetType() == typeof(FileInfo))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
        }
        public void ENTER()
        {
            DOP = new DirectoryInfo(path);
            FileSystemInfo[] files = DOP.GetFileSystemInfos();
            size = files.Length;
            int k = 0;
            foreach (FileSystemInfo fs in files)
            {
                COLOR(fs, k);
                Console.Write(k + 1 + ". ");
                Console.WriteLine(fs.Name);
                k++;
            }
        }
        public void FAR()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            while (true)
            {
                Console.Clear();
                ENTER();
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.UpArrow)
                {
                    UP();
                }
                if (consoleKey.Key == ConsoleKey.DownArrow)
                {
                    DOWN();
                }
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    if (CUP.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        path = CUP.FullName;
                    }
                    else
                    {

                    }
                }
                if (consoleKey.Key == ConsoleKey.Delete)
                {

                }
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    cursor = 0;
                    path = DOP.Parent.FullName;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = (@"C:\Users\Админ\Desktop");
            FarManager farManager = new FarManager(path);
            farManager.FAR();
        }
    }
}