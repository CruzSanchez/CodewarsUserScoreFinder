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
            int consoleLeft = 5;
            int consoleTop = 2;
            if (ScoreRetriever.Users.Count > 0)
            {
                foreach (User user in ScoreRetriever.Users.OrderByDescending(x => x.Honor).ThenBy(x => x.Name))
                {
                    Console.SetCursorPosition(consoleLeft, consoleTop);
                    ConfigureUserDataOnConsole(user);
                    NewLine();
                    consoleTop += 2;
                }
            }
            else
            {
                Error("Your list is empty!");
            }

            Console.ResetColor();
            Console.CursorVisible = false;
        }

        internal static void Error(string errorMessage)
        {
            SetConsoleColor(ConsoleColor.Red);
            Console.WriteLine(errorMessage);
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

        public static void PrintAsciiArt()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    Console.SetCursorPosition(0,0);
                    Console.WriteLine(@"      ::::::::   ::::::::  :::::::::  ::::::::::  :::       :::     :::     :::::::::   ::::::::          ::::::::   ::::::::   ::::::::  :::::::::  ::::::::::          :::::::::: ::::::::::: ::::    ::: :::::::::  :::::::::: :::::::::", Console.ForegroundColor = ColorSwap());
                    Console.WriteLine(@"    :+:    :+: :+:    :+: :+:    :+: :+:         :+:       :+:   :+: :+:   :+:    :+: :+:    :+:        :+:    :+: :+:    :+: :+:    :+: :+:    :+: :+:                 :+:            :+:     :+:+:   :+: :+:    :+: :+:        :+:    :+:");
                    Console.WriteLine(@"   +:+        +:+    +:+ +:+    +:+ +:+         +:+       +:+  +:+   +:+  +:+    +:+ +:+               +:+        +:+        +:+    +:+ +:+    +:+ +:+                 +:+            +:+     :+:+:+  +:+ +:+    +:+ +:+        +:+    +:+ ");
                    Console.WriteLine(@"  +#+        +#+    +:+ +#+    +:+ +#++:++#    +#+  +:+  +#+ +#++:++#++: +#++:++#:  +#++:++#++        +#++:++#++ +#+        +#+    +:+ +#++:++#:  +#++:++#            :#::+::#       +#+     +#+ +:+ +#+ +#+    +:+ +#++:++#   +#++:++#:   ");
                    Console.WriteLine(@" +#+        +#+    +#+ +#+    +#+ +#+         +#+ +#+#+ +#+ +#+     +#+ +#+    +#+        +#+               +#+ +#+        +#+    +#+ +#+    +#+ +#+                 +#+            +#+     +#+  +#+#+# +#+    +#+ +#+        +#+    +#+   ");
                    Console.WriteLine(@"#+#    #+# #+#    #+# #+#    #+# #+#          #+#+# #+#+#  #+#     #+# #+#    #+# #+#    #+#        #+#    #+# #+#    #+# #+#    #+# #+#    #+# #+#                 #+#            #+#     #+#   #+#+# #+#    #+# #+#        #+#    #+#    ");
                    Console.WriteLine(@"########   ########  #########  ##########    ###   ###   ###     ### ###    ###  ########          ########   ########   ########  ###    ### ##########          ###        ########### ###    #### #########  ########## ###    ###     ");
                    await Task.Delay(250);
                }
            });
        }

        private static ConsoleColor ColorSwap()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(rng.Next(1, consoleColors.Length - 1));
        }
    }
}
