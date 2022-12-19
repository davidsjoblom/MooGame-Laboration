using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Core;

namespace MooGame.Tests;

[TestClass]
public class GameLogicHandlerTests
{
   private readonly IGameLogicHandler _gameLogicHandler;
   public GameLogicHandlerTests()
   {
      _gameLogicHandler = new GameLogicHandler();
   }

   [TestMethod]
   public void GenerateGoal_returnsFourDigitString()
   {
      var result = _gameLogicHandler.GenerateGoal();
      Assert.IsTrue(Regex.IsMatch(result, @"^\d{4}$"));
   }

   [TestMethod]
   public void GenerateGoal_noDuplicateDigitsInGoal()
   {
      var result = _gameLogicHandler.GenerateGoal();
      Assert.IsFalse(Regex.IsMatch(result, @"(\d).*\1"));
   }

   [TestMethod]
   [DataRow("1234", "1356", "B,C")]
   [DataRow("1234", "1344", "BB,C")]
   [DataRow("1234", "4765", ",C")]
   [DataRow("1234", "", ",")]
   [DataRow("1234", "1", "B,")]
   [DataRow("1234", "    sdf", ",")]
   [DataRow("1234", "", ",")]
   public void CheckGuess_returnsCorrectBullsAndCows(string goal, string guess, string target)
   {
      var result = _gameLogicHandler.CheckGuess(goal, guess);
      Assert.AreEqual(result, target);
   }

   [TestMethod]
   [DataRow("dBBBB,")]
   [DataRow("BBBB,asdf")]
   [DataRow("BBBB,C")]
   [DataRow("BBB,")]
   [DataRow("")]
   public void IsGuessCorrect_returnsFalse(string checkedGuessResult)
   {
      var result = _gameLogicHandler.IsGuessCorrect(checkedGuessResult);
      Assert.IsFalse(result);
   }

   [TestMethod]
   [DataRow("BBBB,")]
   public void IsGuessCorrect_returnsTrue(string checkedGuessResult)
   {
      var result = _gameLogicHandler.IsGuessCorrect(checkedGuessResult);
      Assert.IsTrue(result);
   }
}