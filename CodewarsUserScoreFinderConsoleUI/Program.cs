using CodewarsScoreFinderLibrary;
using System;

namespace CodewarsUserScoreFinderConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoreRetriever retriever = new ScoreRetriever();

            retriever.ExecuteOrder66();

            ConsoleLogging.PrintUserData();

            Console.ReadLine();
        }
    }
}
