using CodewarsScoreFinderLibrary;
using System;

namespace CodewarsUserScoreFinderConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoreRetriever retriever = new ScoreRetriever();

            retriever.GetUser("CruzSanchez");

            ConsoleLogging.PrintUserData();


            Console.ReadLine();
        }
    }
}
