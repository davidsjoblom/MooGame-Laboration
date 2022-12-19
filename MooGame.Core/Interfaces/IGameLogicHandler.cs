namespace MooGame.Core;

public interface IGameLogicHandler
{
   public string GenerateGoal();
   public string CheckGuess(string goal, string guess);
   public bool IsGuessCorrect(string checkedGuessResult);
}