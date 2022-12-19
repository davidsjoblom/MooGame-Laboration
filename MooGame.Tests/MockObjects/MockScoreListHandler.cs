using MooGame.Core;

namespace MooGame.Tests;

public class MockScoreListHandler : IScoreListHandler
{
   private readonly string _topList;
   public MockScoreListHandler(string topList)
   {
      _topList = topList;
   }

   public string GetTopList()
   {
      return _topList;
   }

   public void SavePlayerScore(string playerName, int numberOfGuesses)
   {
   }
}