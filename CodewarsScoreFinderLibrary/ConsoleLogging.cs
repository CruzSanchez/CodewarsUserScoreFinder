using System;

namespace CodewarsScoreFinderLibrary
{
    public static class ConsoleLogging
    {
        public static void PrintUserData()
        {
            if (ScoreRetriever.Users.Count > 0)
            {
                foreach (User user in ScoreRetriever.Users)
                {
                    Console.WriteLine($"Name: {user.Name} || Honor: {user.Honor} || TotalCompleted: {user.CodeChallenges.TotalCompleted}");
                }
            }            
        }
    }
}
