using System;
using System.Linq;
using zad1;

namespace zad4
{
    public class HomeworkLinqQueries
    {
        // strings[0] = "Broj 1 ponavlja se 1 puta" 
        public static string[] Linq1(int[] intArray)
        {
            string[] strArray = new string[intArray.Distinct().Count()];

            for (int i = 0; i < intArray.Distinct().Count(); i++)
            {
                strArray[i] = "Broj " + intArray.OrderBy(n => n).GroupBy(n => n).ElementAt(i).First() + " ponavlja se " + intArray.OrderBy(n => n).GroupBy(n => n).ElementAt(i).Count() + " puta";
                Console.WriteLine(strArray[i]);
            }

            return strArray;
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            University[] males = universityArray.Where(n => n.Students.All(m => m.Gender == Gender.Male)).ToArray();
            return males;
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            University[] belowAverage = universityArray.Where(y =>
                y.Students.Length < universityArray.SelectMany(x => x.Students).ToArray().Length / universityArray.Length).ToArray();
            return belowAverage;
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            Student[] croatians = universityArray.SelectMany(x => x.Students).Distinct().ToArray();
            return croatians;
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            Student[] onlyMaleorFemale = universityArray
                .Where(n => n.Students.All(m => m.Gender == Gender.Male) ||
                            n.Students.All(l => l.Gender == Gender.Female))
                .SelectMany(x => x.Students).Distinct().ToArray();

            return onlyMaleorFemale;
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            Student[] duplicate = universityArray.SelectMany(x => x.Students).GroupBy(stu => stu)
                .Where(y => y.Count() > 1).Select(bla => bla.Key).Distinct().ToArray();
            return duplicate;
        }
    }
}
