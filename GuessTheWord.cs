using System;
using CrypticWizard.RandomWordGenerator;
namespace GuessTheWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to guess the word\n");
            Console.WriteLine("-----------------------\n");
            WordGenerator realWordGenerator = new WordGenerator();
            string realWord = realWordGenerator.GetWord();
            char[] guessedWord = new char[realWord.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_'; 
            }

            while (true)
            {
                Console.WriteLine("\nCurrent word: " + new string(guessedWord));
                Console.WriteLine("Enter a letter and guess the word:");

                char userLetter;
                try
                {
                    string? input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Invalid input. Please enter a letter.");
                        continue; // Ask for input again
                    }

                    userLetter = input.ToLower()[0];
                }
                catch (Exception)
                {
                    Console.WriteLine(" Please enter a single letter.");
                    continue;
                }

                GuessWord(userLetter, realWord, guessedWord);

                // Check if the user has guessed the entire word
                if (new string(guessedWord) == realWord)
                {
                    Console.WriteLine("Congratulations! You've guessed the word: " + realWord);
                    break;
                }
            }
        }

        static void GuessWord(char letter, string realWord, char[] guessedWord)
        {
            bool found = false;

            for (int j = 0; j < realWord.Length; j++)
            {
                if (letter == realWord[j])
                {
                    guessedWord[j] = letter; 
                    found = true;
                }
            }

            if (found)
            {
                Console.WriteLine($"Correct! The letter '{letter}' is in the word.");
            }
            else
            {
                Console.WriteLine($"Incorrect! The letter '{letter}' is not in the word. Try again.");
            }
        }
    }
}
