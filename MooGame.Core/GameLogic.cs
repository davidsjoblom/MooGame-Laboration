using System;
using System.Collections.Generic;

namespace MooGame.Core;

public class GameLogicHandler : IGameLogicHandler
{
   public string CheckGuess(string goal, string guess)
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

   public string GenerateGoal()
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

   public bool IsGuessCorrect(string checkedGuessResult)
   {
      return checkedGuessResult == "BBBB,";
   }
}

