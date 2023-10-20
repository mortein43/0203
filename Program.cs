using System;
using System.Threading;

namespace UkrainianAlphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            string abc = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
            Console.WriteLine("Введіть початкову букву українського алфавіту:");
            string first = Console.ReadLine();
            while (first.Length == 0)
            {
                Console.WriteLine("Ви ввели пустий рядок, спробуйте знову:");
                first = Console.ReadLine();
            }
            char startChar = char.ToLower(first[0]);
            int start = abc.IndexOf(startChar);
            while (true)
            {
                if (start == -1)
                {
                    Console.WriteLine("Такого символа немає в українському алфавіті.");
                    Console.WriteLine("Спробуйте знову.");
                    first = Console.ReadLine();
                    while (first.Length == 0)
                    {
                        Console.WriteLine("Ви ввели пустий рядок, спробуйте знову:");
                        first = Console.ReadLine();
                    }
                    startChar = char.ToLower(first[0]);
                    start = abc.IndexOf(startChar);
                }
                else break;

                
            }

            Console.WriteLine("Введіть кінцеву букву українського алфавіту:");
            string second = Console.ReadLine();
            while (second.Length == 0)
            {
                Console.WriteLine("Ви ввели пустий рядок, спробуйте знову:");
                second = Console.ReadLine();
            }
            char endChar = char.ToLower(second[0]);
            int end = abc.IndexOf(endChar);
            while (end == -1 || end<start)
            {
                if (end == -1 && end!<=start)
                {
                    Console.WriteLine("Такого символа немає в українському алфавіті.");
                    Console.WriteLine("Спробуйте знову.");
                    second = Console.ReadLine();
                    while (second.Length == 0)
                    {
                        Console.WriteLine("Ви ввели пустий рядок, спробуйте знову:");
                        second = Console.ReadLine();
                    }
                    endChar = char.ToLower(second[0]);
                    end = abc.IndexOf(endChar);
                }
                if (end<=start)
                {
                    Console.WriteLine("Початкова буква повинна бути перед кінцевою буквою, спробуйте знову.");
                    second = Console.ReadLine();
                    while (second.Length == 0)
                    {
                        Console.WriteLine("Ви ввели пустий рядок, спробуйте знову:");
                        second = Console.ReadLine();
                    }
                    endChar = char.ToLower(second[0]);
                    end = abc.IndexOf(endChar);
                }
            }

            Thread thread = new Thread(() => PrintUkrainianAlphabet(start, end, abc));
            thread.Start();
        }

        static void PrintUkrainianAlphabet(int start, int end, string abc)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(abc[i] + " ");
                Thread.Sleep(300); // Затримка 1 секунда
            }
        }
    }
}