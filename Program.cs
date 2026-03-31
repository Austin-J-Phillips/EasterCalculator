using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Output program's purpose
            Console.WriteLine("===  This program calculates what day Easter falls on for a given year.  ===\n");

            // Get input from user and convert the input to integer
            Console.Write("Year:");
            double year = int.Parse(Console.ReadLine());

            // Anonymous Gregorian Computus algorithm
            double a = year % 19;
            double b = Math.Floor(year / 100);
            double c = year % 100;
            double d = Math.Floor(b / 4);
            double e = b % 4;
            double f = Math.Floor((b + 8) / 25);
            double g = Math.Floor((b - f + 1) / 3);
            double h = (19 * a + b - d - g + 15) % 30;
            double i = Math.Floor(c / 4);
            double k = c % 4;
            double l = (32 + 2 * e + 2 * i - h - k) % 7;
            double m = Math.Floor((a + 11 * h + 22 * l) / 451);
            double month = Math.Floor((h + l - 7 * m + 114) / 31);
            double day = ((h + l - 7 * m + 114) % 31) + 1;

            // Cast variables into intergers and assigned to a new varibale
            DateTime easterDate = new DateTime((int)year, (int)month, (int)day);

            // Ouput the easterDate variable in the format of month
            Console.WriteLine($"\nIn {year}, Easter falls on {easterDate:MMMM} {day}");
            Console.WriteLine("\n============================================================================");

            Console.ReadKey();
        }
    }
}
