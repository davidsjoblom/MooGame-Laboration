using MooGame.Core;

namespace MooGame.Tests;

public class MockGameLogicHandler : IGameLogicHandler
{
   private readonly string _checkGuessResult;
   private readonly string _generatedGoal;
   private readonly bool _guessCorrect;
   public MockGameLogicHandler(string checkGuessResult, string generatedGoal, bool guessCorrect)
   {
      _guessCorrect = guessCorrect;
      _generatedGoal = generatedGoal;
      _checkGuessResult = checkGuessResult;
   }

   public string CheckGuess(string goal, string guess)
   {
      return _checkGuessResult;
   }

   public string GenerateGoal()
   {
      return _generatedGoal;
   }

   public bool IsGuessCorrect(string checkedGuessResult)
   {
      return _guessCorrect;
   }
}