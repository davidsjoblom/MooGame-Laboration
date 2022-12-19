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
}