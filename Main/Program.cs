using System;
using System.Collections.Generic;
using System.Linq;
using zad1;
using static zad5.LongOperations;
using static zad6zad7.FactDigSum;
namespace Main
{
    class Program
    {
        public static void Main(String[] args)
        {
            //zad1 - uncomment below to test
            //Case1();
            //Case2();
            //Case3();

            //zad5 - uncomment below to test
            //Example1();
            //Example2();
            //Example3();
            //Example4();

            //zad6zad7 - uncomment below to test
            //MainFactDigSUm();
        }

        public static void Case1()
        {
            var topStudents = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Luka ", jmbag :" 3274272 ") ,
                new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            bool isIvanTopStudent = topStudents.Contains(ivan);
            if (isIvanTopStudent) Console.WriteLine("tru");
        }
        public static void Case2()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            // 2 :(
            var distinctStudentsCount = list.Distinct().Count();
            Console.WriteLine(distinctStudentsCount);
        }

        public static void Case3()
        {
            var topStudents = new List<Student>()
            {
                new Student(" Ivan ", jmbag: " 001234567 "),
                new Student(" Luka ", jmbag: " 3274272 "),
                new Student("Ana", jmbag: " 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            // == operator is a different operation from . Equals ()
            // Maybe it isn ’t such a bad idea to override it as well
            bool isIvanTopStudent = topStudents.Any(s => s == ivan);
            if (isIvanTopStudent) Console.WriteLine("tru");
        }
    }
}
