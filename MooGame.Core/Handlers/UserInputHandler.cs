namespace MooGame.Core
{
    public class UserInputHandler : IUserInputHandler
    {
        public string GetUsername()
        {
            return System.Console.ReadLine() ?? "null";
        }

        public string GetUserGuess()
        {
            return System.Console.ReadLine() ?? "null";
        }

        public bool GetPlayAgainAnswer()
        {
            var answer = System.Console.ReadLine();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n") return false;
            return true;
        }
    }
}