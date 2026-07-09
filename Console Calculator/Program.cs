using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static object Calculator(int num1, int num2, string s_str)
    {
        switch (s_str)
        {
            case "+":
                return num1 + num2;

            case "-":
                return num1 - num2;

            case "*":
                return num1 * num2;

            case "/":
                if (num2 == 0)
                    return "Number cann't be divided by 0.";
                return num1 / num2;

            case "**":
                return (int)Math.Pow(num1, num2);

            case "%":
                return num1 * num2 / 100;

            default:
                return "Invalid operator entry.";

        }
    }

    static string[] History(int line_quantity, string file_path)
    {
        
        string[] filedata = File.ReadAllLines(file_path).TakeLast(line_quantity).ToArray();

        return filedata;
    }
    static void Main(string[] args)
    {
        string f_num, s_num;
        string sign, filepath = @"C:\Users\User\Desktop\HistoryFile.txt", content;
        string input = "N";

        while (input == "N")
        {
            Console.WriteLine("First Number: ");
            f_num = Console.ReadLine();

            Console.WriteLine("Second Number: ");
            s_num = Console.ReadLine();

            Console.WriteLine("Sign {+, -, *, /, **, %}: ");
            sign = Console.ReadLine();

            if (int.TryParse(f_num, out int first_num) && int.TryParse(s_num, out int second_num))
            {
                var result = Calculator(first_num, second_num, sign);
                Console.WriteLine(result);
                Console.WriteLine("\n");

                if (result is int)
                {
                    content = $"{f_num} {sign} {s_num} = {result}\n";
                    File.AppendAllText(filepath, content);
                }


                Console.WriteLine("History\n");
                string[] lastCalculations = History(5, filepath);
                foreach(string line in lastCalculations)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("\n");
                Console.WriteLine(" 'N' for new calculation\n 'Q' for end");
                input = Console.ReadLine();
                Console.WriteLine("\n");
            }
            else
                Console.WriteLine("Check your numbers validation.\n");
        }

        
    }
}
