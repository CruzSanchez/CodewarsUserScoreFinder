using ConsoleTables;
using System;
using System.Linq;

namespace CodewarsScoreFinderLibrary
{
    public static class ConsoleLogging
    {
        public static void PrintUserData()
        {
            ConsoleTable table = new ConsoleTable("Name", "Username", "Honor", "Total Completed");
            table.Configure(x => x.NumberAlignment = Alignment.Right);

            if (ScoreRetriever.Users.Count > 0)
            {
                foreach (User user in ScoreRetriever.Users.OrderByDescending(x => x.Honor).ThenBy(x => x.Name))
                {
                    ConfigureUserDataOnConsole(user, table);
                }
            }
            else
            {
                Error("Your list is empty!");
            }

            table.Write(Format.MarkDown);
            Console.ResetColor();
        }

        internal static void Error(string errorMessage)
        {
            SetConsoleColor(ConsoleColor.Red);
            Console.WriteLine(errorMessage);
        }

        private static void DisplayUserInformation(User user, ConsoleTable consoleTable)
        {
            consoleTable.AddRow(user.Name, user.UserName, user.Honor, user.CodeChallenges.TotalCompleted);
            //Console.WriteLine($"Name: {user.Name ??= "Unknown"} || Username: {user.UserName} || Honor: {user.Honor} || " +
            //                        $"TotalCompleted: {user.CodeChallenges.TotalCompleted}");            
        }

        private static void ConfigureUserDataOnConsole(User user, ConsoleTable consoleTable)
        {
            switch (user.Ranks.Overall.Color)
            {
                case "white":
                    SetConsoleColor(ConsoleColor.White);
                    DisplayUserInformation(user, consoleTable);
                    break;
                case "yellow":
                    SetConsoleColor(ConsoleColor.DarkYellow);
                    DisplayUserInformation(user, consoleTable);
                    break;
                case "blue":
                    SetConsoleColor(ConsoleColor.Blue);
                    DisplayUserInformation(user, consoleTable);
                    break;
                case "purple":
                    SetConsoleColor(ConsoleColor.Magenta);
                    DisplayUserInformation(user, consoleTable);
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
