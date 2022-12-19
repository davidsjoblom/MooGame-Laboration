using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Core;

namespace MooGame.Tests;

[TestClass]
public class GameTests
{
   [TestMethod]
   [DataRow("BBBB,", "1234", true, "highscores", false, "1234", "Dawud")]
   public void Game_Run_Success(
      string checkGuessResult,
      string generatedGoal,
      bool guessCorrect,
      string topList,
      bool playAgainAnswer,
      string userGuess,
      string username
   )
   {
      var mockGameLogicHandler = new MockGameLogicHandler(checkGuessResult, generatedGoal, guessCorrect);
      var mockGameOutputHandler = new MockGameOutputHandler();
      var mockScoreListHandler = new MockScoreListHandler(topList);
      var mockUserInputHandler = new MockUserInputHandler(playAgainAnswer, userGuess, username);

      var game = new Game(mockUserInputHandler, mockGameOutputHandler, mockGameLogicHandler, mockScoreListHandler);

      game.Run();
   }

}
