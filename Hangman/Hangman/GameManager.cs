using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class GameManager
    {
        private string[] dictionary;
        private Random r;
        private string[] wordDisplay;
        private string[] guessedLetters;
        private int guessIndex; // keep track of where to write the next guess
        private int guessesLeft;
        private string answer;
        private int lettersFound;
        private bool victoryOrDeath;

        public void PlayGame()
        {
            bool stopPlaying = false;
            LoadDictionary();
            r = new Random();

            while (!stopPlaying)
            {
                Setup();

                while (!victoryOrDeath)
                {
                    DisplayScreen();
                    PromptUser();
                }

                Console.WriteLine("Play again (Y/N)?");
                stopPlaying = Console.ReadLine().ToUpper() != "Y";
            }
        }

        private void Setup()
        {
            LoadRandomWord();
            guessedLetters = new string[26];
            guessIndex = 0;
            victoryOrDeath = false;
            guessesLeft = 5;

            wordDisplay = new string[answer.Length];

            for (int i = 0; i < wordDisplay.Length; i++)
            {
                wordDisplay[i] = "_";
            }
        }

        private void DisplayScreen()
        {
            Console.Clear();
            Console.WriteLine("Guesses Remaining: {0}", guessesLeft);
            DisplayLettersUsed();
            DisplayPuzzle();
        }

        private void DisplayLettersUsed()
        {
            Console.Write("Letters Used: ");
            for (int i = 0; i < guessIndex; i++)
            {
                Console.Write("{0} ", guessedLetters[i]);
            }

            Console.WriteLine();
        }

        private void PromptUser()
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.Write("Guess a letter or the word: ");
                validInput = ParseInput(Console.ReadLine().ToUpper());
            }

            Console.WriteLine("Enter to continue.");
            Console.ReadLine();
        }

        private bool ParseInput(string input)
        {
            if (input.Length > 1)
            {
                if (input == answer)
                {
                    Console.WriteLine("You guessed it!");
                    victoryOrDeath = true;
                    return true;
                }

                Console.WriteLine("Wrong!");
                guessesLeft--;
            }
            else
            {
                if (guessedLetters.Contains(input))
                {
                    Console.WriteLine("You already guessed {0}", input);
                    return false;
                }

                // see if the letter is in the word
                bool foundLetter = false;
                for (int i = 0; i < answer.Length; i++)
                {
                    if (input == answer[i].ToString())
                    {
                        foundLetter = true;
                        lettersFound += 1;
                        wordDisplay[i] = input;
                    }
                }

                if (foundLetter)
                {
                    Console.WriteLine("That was a good letter!");
                }
                else
                {
                    Console.WriteLine("Nope!");
                    guessesLeft--;
                }

                guessedLetters[guessIndex] = input;
                guessIndex++;

                CheckForVictoryOrDeath();
            }

            return true;
        }

        private void CheckForVictoryOrDeath()
        {
            if (lettersFound == answer.Length)
            {
                Console.WriteLine("You guessed all the letters!");
                victoryOrDeath = true;
            }

            if (guessesLeft == 0)
            {
                Console.WriteLine("No guesses left, you are dead!");
                Console.WriteLine("The word was " + answer);
                victoryOrDeath = true;
            }
        }

        private void DisplayPuzzle()
        {
            Console.WriteLine("\nPuzzle: ");
            for (int i = 0; i < wordDisplay.Length; i++)
            {
                Console.Write("{0} ", wordDisplay[i]);
            }

            Console.WriteLine();
        }

        private void LoadRandomWord()
        {
            answer = dictionary[r.Next(dictionary.Length)].ToUpper();
        }

        private void LoadDictionary()
        {
            dictionary = File.ReadAllLines(@"Dictionary\dictionary.txt");
        }
    }
}
