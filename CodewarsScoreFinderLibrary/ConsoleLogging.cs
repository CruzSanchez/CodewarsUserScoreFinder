using System;
using System.Linq;

namespace CodewarsScoreFinderLibrary
{
    public static class ConsoleLogging
    {
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

            Console.ResetColor();
        }

        internal static void Error(string errorMessage)
        {
            SetConsoleColor(ConsoleColor.Red);
            Console.WriteLine(errorMessage);
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
                    SetConsoleColor(ConsoleColor.White);
                    DisplayUserInformation(user);
                    break;
                case "yellow":
                    SetConsoleColor(ConsoleColor.DarkYellow);
                    DisplayUserInformation(user);
                    break;
                case "blue":
                    SetConsoleColor(ConsoleColor.Blue);
                    DisplayUserInformation(user);
                    break;
                case "purple":
                    SetConsoleColor(ConsoleColor.Magenta);
                    DisplayUserInformation(user);
                    break;                
            }            
        }

        private static void NewLine()
        {
            Console.WriteLine();
        }

        private static void SetConsoleColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }
    }
}
