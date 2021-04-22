using CodewarsScoreFinderLibrary;
using System;
using System.Runtime.InteropServices;

namespace CodewarsUserScoreFinderConsoleUI
{
    class Program
    {
        #region Console Window Settings
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        #endregion
        static void Main(string[] args)
        {
            ShowWindow(ThisConsole, MAXIMIZE);

            Console.Clear();

            ConsoleLogging.PrintAsciiArt();

            ScoreRetriever retriever = new ScoreRetriever();

            retriever.ExecuteOrder66();

            ConsoleLogging.PrintUserData();

            Console.ReadLine();
        }
    }
}
