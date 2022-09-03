using CodewarsScoreFinderLibrary;
using static CodewarsScoreFinderLibrary.Enums;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodewarsUserScoreFinderConsoleUI
{
    public static class ConsoleLogging
    {
        private static Random rng = new Random();

        public static void PrintUserData()
        {
            if (ScoreRetriever.Users.Count > 0)
            {
                foreach (User user in ScoreRetriever.Users.OrderByDescending(x => x.Honor).ThenBy(x => x.Name))
                {
                    ConfigureUserDataOnConsole(user);
                    NewLine();
                }
            }
            else
            {
                Error("Your list is empty!");
            }
        }

        internal static void Error(string errorMessage)
        {
            Console.WriteLine($"ERROR: {errorMessage}");
        }

        internal static void NewLine()
        {
            Console.WriteLine();
        }

        public static void PassMessage(string message, StatusCode statusCode)
        {
            switch (statusCode)
            {
                case StatusCode.Error:
                    Error(message);
                    break;
                case StatusCode.Success:
                    Console.WriteLine(message);
                    break;
                case StatusCode.Information:
                    Console.WriteLine(message);
                    break;
                default:
                    break;
            }

            
        }

        private static void DisplayUserInformation(User user)
        {
            Console.WriteLine($"Name: {user.Name ??= "Unknown"} || Username: {user.UserName} || Honor: {user.Honor} || " +
                                    $"TotalCompleted: {user.CodeChallenges.TotalCompleted}");
        }

        private static void ConfigureUserDataOnConsole(User user)
        {
            switch (user.Ranks.Overall.Color)
            {
                case "white":
                    DisplayUserInformation(user);
                    break;
                case "yellow":
                    DisplayUserInformation(user);
                    break;
                case "blue":
                    DisplayUserInformation(user);
                    break;
                case "purple":
                    DisplayUserInformation(user);
                    break;
            }
        }        
    }
}
