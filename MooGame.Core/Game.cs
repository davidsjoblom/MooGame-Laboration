using System;
using System.Collections.Generic;

namespace MooGame.Core
{
   public class Game
   {
      public IUserInputHandler _userInputHandler { get; }
      public IGameOutputHandler _gameOutputHandler { get; }
      public Game(IUserInputHandler userInputHandler, IGameOutputHandler gameOutputHandler)
      {
         _gameOutputHandler = gameOutputHandler;
         _userInputHandler = userInputHandler;
      }

      public void Run()
      {
         _gameOutputHandler.AskForUserName();
         var name = _userInputHandler.GetUsername();

         while (true)
         {
            _gameOutputHandler.DisplayInitialMessage();
            var goal = generateGoal();
            System.Console.WriteLine("Dev mode, goal generated: " + goal); //FIXME temp dev line

            var numberOfGuesses = 0;
            var guessIsCorrect = false;
            do
            {
               var guess = Console.ReadLine();
               Console.WriteLine(guess ?? "null");
               numberOfGuesses++;
               var goalCheckResult = checkGuess(goal, guess);
               Console.WriteLine(goalCheckResult + "\n");
               if (goalCheckResult == "BBBB,") guessIsCorrect = true;
            } while (!guessIsCorrect);
            System.Console.WriteLine("Correct! It only took: " + numberOfGuesses + " guesses noob");
            return;
         }
      }

      private string checkGuess(string goal, string? guess)
      {
         int bulls = 0, cows = 0;
         guess = (guess ?? "").PadRight(4);
         var duplicateTracker = new HashSet<char>();
         for (int i = 0; i < 4; i++)
         {
            if (goal[i] == guess[i])
            {
               bulls++;
               duplicateTracker.Add(guess[i]);
            }
         }
         for (int i = 0; i < 4; i++)
         {
            if (goal.Contains(guess[i]) && !duplicateTracker.Contains(guess[i]))
            {
               cows++;
               duplicateTracker.Add(guess[i]);
            }
         }
         return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
      }

      private string generateGoal()
      {
         var rg = new Random();
         var goal = "";
         for (int i = 0; i < 4; i++)
         {
            var isUnique = false;
            while (!isUnique)
            {
               var random = rg.Next(10);
               if (!goal.Contains(random + ""))
               {
                  isUnique = true;
                  goal += random + "";
               }
            }
         }
         return goal;
      }
   }
}