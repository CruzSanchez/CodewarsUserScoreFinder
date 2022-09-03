using CodewarsScoreFinderLibrary;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CodewarsUserScoreFinderConsoleUI
{
    class Program
    {        
        static async Task Main(string[] args)
        {
            Console.Clear();

            ScoreRetriever retriever = new ScoreRetriever();;

            await retriever.ExecuteOrder66(ConsoleLogging.PassMessage);

            ConsoleLogging.PrintUserData();

            Console.ReadLine();
        }
    }
}
