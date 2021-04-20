using CodewarsScoreFinderLibrary;
using System;

namespace CodewarsUserScoreFinderConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoreRetriever retriever = new ScoreRetriever();

            User user = retriever.GetUser("CruzSanchez");

            Console.WriteLine($"Name: { user.Name } UserName: { user.UserName }");
            
        }
    }
}
