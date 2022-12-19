using MooGame.Core;

namespace MooGame.Tests;

public class GameLogicHandlerMock : IGameLogicHandler
{
   public string CheckGuess(string goal, string guess)
   {
      throw new System.NotImplementedException();
   }

   public string GenerateGoal()
   {
      throw new System.NotImplementedException();
   }

   public bool IsGuessCorrect(string checkedGuessResult)
   {
      throw new System.NotImplementedException();
   }
}