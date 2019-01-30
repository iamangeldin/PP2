using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    class Student{
        public string name;
        public string id;
        public int year;

        public Student()
        {
            name = "noName";
            id = "0";
            year = 0;
        }
        public Student(string name, string id)
        {
            this.name = name;
            this.id = id;
            this.year = 1;
        }
        public string getName()
        {
            return this.name;
        }
        public string getId()
        {
            return this.id;
        }
        public void incYear()
        {
            this.year++;
        }
        public override string ToString()
        {
            return name + " " + id + " " + year;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Student s2 = new Student("Islam", "18BD110565");

            Console.WriteLine(s1);
            Console.WriteLine(s2);

            Console.WriteLine(s1.getName());
            Console.WriteLine(s2.getName());

            Console.WriteLine(s1.getId());
            Console.WriteLine(s2.getId());

            s1.incYear();
            s2.incYear();

            Console.WriteLine(s1);
            Console.WriteLine(s2);


            Console.ReadKey();
        }
    }
}
