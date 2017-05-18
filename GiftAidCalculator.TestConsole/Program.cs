using GiftAidCalculator.TestConsole.Models;
using System;
using System.Text;

namespace GiftAidCalculator.TestConsole
{
    class Program
    {
        static void Main()
        {
            int userInput = 0;
            var calculator = new Calculator(new User());

            do
            {
                DisplayMenu();
                userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.Write("donation amount > ");
                        Console.WriteLine($"aid amount: {calculator.Calculate(decimal.Parse(Console.ReadLine()))}");
                        continue;
                    case 2:
                        calculator.Login(new Admin());
                        continue;
                    case 3:
                        Console.Write("new tax rate > ");
                        calculator.ChangeTaxRate(decimal.Parse(Console.ReadLine()));
                        calculator.Login(new User());
                        continue;
                    case 4:
                        DisplayPromoterMenu();
                        calculator.AddEvent(GetEventType(int.Parse(Console.ReadLine())));
                        continue;
                    default:
                        continue;
                }
            } while (userInput != 5);

        }

        static Event GetEventType(int eventType)
        {
            switch (eventType)
            {
                case 1:
                    return new Running();
                case 2:
                    return new Swimming();
                default:
                    return new Event();
            }
        }

        static void DisplayMenu()
        {
            var output = new StringBuilder();
            output.Append(Environment.NewLine);
            output.Append("1 calculate\n");
            output.Append("2 login as admin\n");
            output.Append("3 change tax rate\n");
            output.Append("4 add event\n");
            output.Append("5 exit");
            Console.WriteLine(output);
        }

        static void DisplayPromoterMenu()
        {
            var output = new StringBuilder();
            output.Append("1 Running\n");
            output.Append("2 Swimming\n");
            output.Append("3 Other\n");
            Console.WriteLine(output);
        }
    }
}
