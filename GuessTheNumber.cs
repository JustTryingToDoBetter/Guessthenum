using System;
using System.Security.Cryptography;

namespace GuessTheNumber
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to guess the number\n");
            Console.WriteLine("-----------------------\n");

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter a number between 0 and 100:");
                    int userNumber = Convert.ToInt32(Console.ReadLine());

                    if (userNumber < 0 || userNumber > 100)
                    {
                        throw new ArgumentOutOfRangeException("Number must be between 0 and 100.");
                    }

                    GuessNum(userNumber);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number between 0 and 100.");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An unexpected error occurred: " + e.Message);
                }
            }
        }

        static void GuessNum(int num)
        {
            int randomNum = RandomNumberGenerator.GetInt32(0, 101);
            while (true)
            {
                if (num == randomNum)
                {
                    Console.WriteLine("Correct!");
                    break;
                }
                else if (num > randomNum)
                {
                    Console.WriteLine("Too high!\n");
                }
                else
                {
                    Console.WriteLine("Too low!\n");
                }

                Console.WriteLine("Enter another value:");
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());

                    if (num < 0 || num > 100)
                    {
                        throw new ArgumentOutOfRangeException("Number must be between 0 and 100.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number between 0 and 100.");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
