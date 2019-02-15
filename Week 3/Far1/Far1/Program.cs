using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Far1
{
    class Far1
    {
        private int cursor;
        public int Cursor
        {
            get
            {
                return cursor;
            }
            set
            {
                if (value >= Vector.Count)
                {
                    cursor = 0;
                }
                else if (value < 0)
                {
                    cursor = Vector.Count - 1;
                }
                else
                {
                    cursor = value;
                }
            }
        }


        public List<FileSystemInfo> Vector
        {
            get;
            set;
        }
        public void Draw()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < Vector.Count; ++i)
            {
                if (i == Cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(Vector[i].Name);
            }
        }
        public void Delete()
        {
            FileSystemInfo fileSystemInfo = Vector[cursor];
            if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
            {
                Directory.Delete(fileSystemInfo.FullName, true);
            }
            else
            {
                File.Delete(fileSystemInfo.FullName);
            }
            Vector.RemoveAt(cursor);
            cursor--;
        }
    }
    enum Type
    {
        File,
        Directory
    }



    class Program
    {
        static void Main(string[] args)
        {
            Type typ = Type.Directory;
            string path = @"C:\Users\Админ\Desktop\PP2";
            DirectoryInfo dir = new DirectoryInfo(path);
            Stack<Far1> par = new Stack<Far1>();
            par.Push(
                new Far1
                {
                    Vector = dir.GetFileSystemInfos().ToList(),
                    Cursor = 0
                });
            while (true)
            {
                par.Peek().Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.F2:
                        int y = par.Peek().Cursor;
                        FileSystemInfo fos = par.Peek().Vector[y];
                        string chan = Console.ReadLine();
                        DirectoryInfo df = new DirectoryInfo(fos.FullName);
                        File.Move(fos.FullName, df.Parent.FullName + "/" + chan);
                        break;
                    case ConsoleKey.Delete:
                        par.Peek().Delete();
                        break;
                    case ConsoleKey.UpArrow:
                        par.Peek().Cursor--;
                        break;
                    case ConsoleKey.DownArrow:
                        par.Peek().Cursor++;
                        break;
                    case ConsoleKey.Backspace:
                        if (typ == Type.Directory)
                        {
                            par.Pop();
                        }
                        else
                        {
                            typ = Type.Directory;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        break;
                    case ConsoleKey.Enter:
                        int x = par.Peek().Cursor;
                        FileSystemInfo fileSystemInfo = par.Peek().Vector[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo as DirectoryInfo;
                            par.Push(
                                new Far1
                                {
                                    Vector = directoryInfo.GetFileSystemInfos().ToList(),
                                    Cursor = 0
                                });
                        }
                        else
                        {
                            Process.Start(fileSystemInfo.FullName);
                        }
                        break;
                }

            }
        }
    }
}