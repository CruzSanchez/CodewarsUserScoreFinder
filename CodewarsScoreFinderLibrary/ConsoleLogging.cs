using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodewarsScoreFinderLibrary
{
    public static class ConsoleLogging
    {
        private static Random rng = new Random();

        public static void PrintUserData()
        {
            int consoleLeft = 50;
            int consoleTop = 10;
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
        }

        internal static void Error(string errorMessage)
        {
            SetConsoleColor(ConsoleColor.Red);
            Console.WriteLine(errorMessage);
        }

        private static void DisplayUserInformation(User user)
        {
            Console.WriteLine($"Name: {user.Name ??= "Unknown",-20} ||\t Username: {user.UserName,-25} ||    Honor: {user.Honor,6}    ||    " +
                                    $"TotalCompleted: {user.CodeChallenges.TotalCompleted,5}");
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
