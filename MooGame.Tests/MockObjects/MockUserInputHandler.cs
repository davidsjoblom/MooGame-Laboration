using MooGame.Core;

namespace MooGame.Tests;

public class MockUserInputHandler : IUserInputHandler
{
   private readonly bool _playAgainAnswer;
   private readonly string _userGuess;
   private readonly string _username;
   public MockUserInputHandler(bool playAgainAnswer, string userGuess, string username)
   {
      _username = username;
      _userGuess = userGuess;
      _playAgainAnswer = playAgainAnswer;
   }

   public bool GetPlayAgainAnswer()
   {
      return _playAgainAnswer;
   }

   public string GetUserGuess()
   {
      return _userGuess;
   }

   public string GetUsername()
   {
      return _username;
   }
}