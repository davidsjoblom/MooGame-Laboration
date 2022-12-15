namespace MooGame.Core
{
   public interface IGameOutputHandler
   {
      public void AskForUserName();
      public void DisplayInitialMessage();
      public void DisplayGuessEvaluationResult(string guessEvaluationResult);
      public void DisplayWinMessageWithGuessCount(int guesses);
      public void AskToPlayAgain();
   }
}