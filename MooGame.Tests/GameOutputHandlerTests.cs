using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Core;

namespace MooGame.Tests;

[TestClass]
public class GameOutputHandlerTests
{
   private readonly IGameOutputHandler _gameOutputHandler;
   public GameOutputHandlerTests()
   {
      _gameOutputHandler = new GameOutputHandler();
   }

   [TestMethod]
   [DataRow("Enter your username:\r\n")]
   public void AskForUserName_test(string target)
   {
      TextWriter output = new StringWriter();
      Console.SetOut(output);

      _gameOutputHandler.AskForUserName();

      var result = output.ToString();
      Assert.AreEqual(target, result);
   }
}