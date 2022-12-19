using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Core;

namespace MooGame.Tests;

[TestClass]
public class UserInputHandlerTests
{
   private readonly IUserInputHandler _userInputHandler;

   public UserInputHandlerTests()
   {
      _userInputHandler = new UserInputHandler();
   }

   [TestMethod]
   [DataRow("Dawud", "Dawud")]
   public void GetUserName_returnSameAsInputInConsole(string userInput, string target)
   {
      TextReader input = new StringReader(userInput);
      Console.SetIn(input);


      var result = _userInputHandler.GetUsername();
      Assert.AreEqual(result, target);
   }

   [TestMethod]
   [DataRow("n")]
   public void GetPlayAgainAnswer_returnFalse(string userInput)
   {
      TextReader input = new StringReader(userInput);
      Console.SetIn(input);

      var result = _userInputHandler.GetPlayAgainAnswer();
      Assert.IsFalse(result);
   }

   [TestMethod]
   [DataRow("")]
   [DataRow("asdfasdf")]
   [DataRow("    ")]
   public void GetPlayAgainAnswer_returnTrue(string userInput)
   {
      TextReader input = new StringReader(userInput);
      Console.SetIn(input);

      var result = _userInputHandler.GetPlayAgainAnswer();
      Assert.IsTrue(result);
   }
}