using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterCalculator
{
    internal class EasterDate
    {
        static void Main(string[] args)
        {
            RunApplication();
        }

        // Controls overall application lifecycle
        static void RunApplication()
        {
            Console.WriteLine("=== This program calculates what day Easter falls on for a given year. ===\n");

            bool running = true;

            while (running)
            {
                running = RunCycle();
            }

            Console.WriteLine("\nGoodbye!");
        }

        // One full cycle of the program
        static bool RunCycle()
        {
            int year = GetValidYear();

            DateTime easterDate = GetEasterDate(year);

            DisplayResult(year, easterDate);

            return AskToContinue();
        }

        // Handles validated input
        static int GetValidYear()
        {
            while (true)
            {
                Console.Write("Year: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int year) && year >= 1583 && year <= 9999)
                {
                    return year;
                }

                Console.WriteLine("Invalid input. Enter a valid year (1583–9999).\n");
            }
        }

        // Pure computation (unit-testable)
        public static DateTime GetEasterDate(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(year, month, day);
        }

        // Output formatting
        static void DisplayResult(int year, DateTime easterDate)
        {
            Console.WriteLine($"\nIn {year}, Easter falls on {easterDate:MMMM dd}");
            Console.WriteLine("\n============================================================================");
        }

        // Menu control
        static bool AskToContinue()
        {
            while (true)
            {
                Console.WriteLine("Would you like to enter another year?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.Write("\nChoice: ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("\n============================================================================");
                    return true;
                }

                if (input == "2")
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    return false;
                }

                Console.WriteLine("\nInvalid choice. Please enter 1 or 2.\n");
            }
        }
    }
}
