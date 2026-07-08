using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static object Calculator(int num1, int num2, string s_str)
    {
        if (!(num1 is int) || !(num2 is int))
        {
            throw new Exception("Check your numbers type.");
        }

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
                return num1 % num2;

            default:
                return "Invalid operator entry.";

        }
    }
    static void Main(string[] args)
    {
        int f_num, s_num;
        string sign, filepath = @"C:\Users\User\Desktop\HistoryFile.txt", content;


        Console.WriteLine("First Number: ");
        f_num = int.Parse(Console.ReadLine());

        Console.WriteLine("Second Number: ");
        s_num = int.Parse(Console.ReadLine());

        Console.WriteLine("Sign {+, -, *, /, **, %}: ");
        sign = Console.ReadLine();

        var result = Calculator(f_num, s_num, sign);
        Console.WriteLine(result);
        

        if (result is int)
        {
            content = $"{f_num} {sign} {s_num} = {result}";
            File.AppendAllText(filepath, content);
        }
    }
}
