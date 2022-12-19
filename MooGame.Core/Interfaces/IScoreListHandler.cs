namespace MooGame.Core;

public interface IScoreListHandler
{
   public string GetTopList();
   public void SavePlayerScore(string playerName, int numberOfGuesses);
}