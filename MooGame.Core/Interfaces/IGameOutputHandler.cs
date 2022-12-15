namespace MooGame.Core
{
    public interface IGameOutputHandler
    {
        public void AskForUserName();
        public void DisplayNewGameMessage();
        public void DisplayGuessEvaluationResult(string guessEvaluationResult);
        public void DisplayWinMessageWithGuessCount(int guesses);
        public void AskToPlayAgain();
    }
}