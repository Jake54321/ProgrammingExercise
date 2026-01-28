using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] answer = new int[4];

            for (int i = 0; i < 4; i++)
            {
                answer[i] = rand.Next(1, 7);
            }

            int attempts = 10;

            Console.WriteLine("Guess the 4-digit code (digits must be 1–6). You have 10 trys.");

            int attemptTry = 1;
            while (attempts > 0)
            {
                Console.Write($"Attempt {attemptTry} out of 10 - Enter guess: ");
                string input = Console.ReadLine();


                if (input.Length != 4)
                {
                    Console.WriteLine("Invalid guess. Must be 4 digits in length.");
                    continue;
                }

                if (!int.TryParse(input, out _))
                {
                    Console.WriteLine("Invalid guess. Guess should have all numeric digits.");
                    continue;
                }


                int[] guess = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    guess[i] = input[i] - '0';
                    if (guess[i] < 1 || guess[i] > 6)
                    {
                        Console.WriteLine("Digits must be between 1 and 6.");
                        continue;
                    }
                }

                bool[] Used = new bool[4];
                bool[] Guessed = new bool[4];

                int totalPlus = 0;
                int totalMinus = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (guess[i] == answer[i])
                    {
                        totalPlus++;
                        Used[i] = true;
                        Guessed[i] = true;
                    }
                }


                for (int i = 0; i < 4; i++)
                {
                    if (Guessed[i]) continue;

                    for (int j = 0; j < 4; j++)
                    {
                        if (!Used[j] && guess[i] == answer[j])
                        {
                            totalMinus++;
                            Used[j] = true;
                            break;
                        }
                    }
                }

                string result = new string('+', totalPlus) + new string('-', totalMinus);
                Console.WriteLine("Result: " + result);


                if (totalPlus == 4)
                {
                    Console.WriteLine("Correct!");
                    Console.ReadLine();
                    return;
                }

                attemptTry++;
                attempts--;
            }

            // Loss condition
            Console.WriteLine("You lost!");
            Console.WriteLine($"The answer was:{string.Join(", ", answer)} ");
            Console.ReadLine();

        }
    }
}
