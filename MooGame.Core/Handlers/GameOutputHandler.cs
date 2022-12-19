namespace MooGame.Core;

public class GameOutputHandler : IGameOutputHandler
{
   public void AskForUserName()
   {
      System.Console.WriteLine("Enter your username:");
   }

   public void DisplayInitialMessage()
   {
      System.Console.WriteLine("New Game: ");
   }

   public void DisplayGuessEvaluationResult(string guessEvaluationResult)
   {
      System.Console.WriteLine(guessEvaluationResult);
   }

   public void DisplayWinMessageWithGuessCount(int guesses)
   {
      System.Console.WriteLine("Correct, it took " + guesses + " guesses");
   }

   public void AskToPlayAgain()
   {
      System.Console.WriteLine("Continue?");
   }

   public void DisplayTopList(string topList)
   {
      System.Console.WriteLine(topList);
   }
}