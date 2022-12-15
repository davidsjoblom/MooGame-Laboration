namespace MooGame.Core;

public interface IUserInputHandler
{
   public string GetUsername();
   public string GetUserGuess();
   public bool GetPlayAgainAnswer();
}