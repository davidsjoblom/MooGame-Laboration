namespace MooGame.Core;

public class ScoreListHandler : IScoreListHandler
{
   public string GetTopList()
   {
      throw new System.NotImplementedException();
   }

   public string SavePlayerScore(PlayerData playerscore)
   {
      throw new System.NotImplementedException();
   }
}
public interface IScoreListHandler
{
   public string GetTopList();
   public string SavePlayerScore(PlayerData playerscore);
}

public class PlayerData
{

}