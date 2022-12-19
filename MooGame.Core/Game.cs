using System;

namespace MooGame.Core;

public class Game
{
   private readonly IGameOutputHandler _gameOutputHandler;
   private readonly IUserInputHandler _userInputHandler;
   private readonly IGameLogicHandler _gameLogicHandler;
   private readonly IScoreListHandler _scoreListHandler;
   public Game(IUserInputHandler userInputHandler, IGameOutputHandler gameOutputHandler, IGameLogicHandler gameLogicHandler, IScoreListHandler scoreListHandler)
   {
      _scoreListHandler = scoreListHandler;
      _gameLogicHandler = gameLogicHandler;
      _userInputHandler = userInputHandler;
      _gameOutputHandler = gameOutputHandler;
   }

   public void Run()
   {
      while (true)
      {
         _gameOutputHandler.AskForUserName();
         var playerName = _userInputHandler.GetUsername();

         _gameOutputHandler.DisplayInitialMessage();
         var goal = _gameLogicHandler.GenerateGoal();

         Console.WriteLine("Dev mode, goal generated: " + goal); //FIXME temp dev line

         var numberOfGuesses = 0;
         var guessIsCorrect = false;
         do
         {
            var guess = _userInputHandler.GetUserGuess();
            numberOfGuesses++;
            var guessCheckResult = _gameLogicHandler.CheckGuess(goal, guess);
            _gameOutputHandler.DisplayGuessEvaluationResult(guessCheckResult);
            guessIsCorrect = _gameLogicHandler.IsGuessCorrect(guessCheckResult);
         } while (!guessIsCorrect);

         _gameOutputHandler.DisplayWinMessageWithGuessCount(numberOfGuesses);

         _scoreListHandler.SavePlayerScore(playerName, numberOfGuesses);
         var topList = _scoreListHandler.GetTopList();
         _gameOutputHandler.DisplayTopList(topList);

         _gameOutputHandler.AskToPlayAgain();
         if (_userInputHandler.GetPlayAgainAnswer() is false) return;
      }
   }
}