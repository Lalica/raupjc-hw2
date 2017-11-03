using System;
using System.Threading.Tasks;

namespace zad6zad7
{
    public class FactDigSum
    {
        //Ignore this part.
        public static void MainFactDigSUm()
        {
            // Main method is the only method that 
            // can’t be marked with async. 
            // What we are doing here is just a way for us to simulate
            // async-friendly environment you usually have with
            // other .NET application types (like web apps, win apps etc.)
            // Ignore main method, you can just focus on LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in the call hierarchy.
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static async Task<int> FactorialDigitSumAsync(int n)
        {
            Task<int> task = Task.Run(() => n = FactorialDigitSum(n));
            await task;
            return n;
        }

        private static int FactorialDigitSum(int n)
        {
            int fact = 1;
            int sum = 0;

            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }

            while (fact != 0)
            {
                sum += fact % 10;
                fact /= 10;
            }
            return sum;
        }

        private static async void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(5);
        }

        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSumAsync(n);
        }
    }
}
