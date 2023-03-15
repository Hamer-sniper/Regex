using System.Text.RegularExpressions;

namespace MyToDouble
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string s = Console.ReadLine();

            double d = s.MyToDouble();

            Console.WriteLine("\nИсходная строка.");
            Console.WriteLine(s);

            Console.WriteLine("\nПреобразованная строка.");
            Console.WriteLine(d);

            Console.WriteLine("\nКонкотенация строк.");
            Console.WriteLine(s + s);

            Console.WriteLine("\nСложение чисел.");
            Console.WriteLine(d + d);            

            Console.ReadKey();
        }
    }
}