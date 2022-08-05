using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CodewarsScoreFinderLibrary.Enums;

namespace CodewarsScoreFinderLibrary
{
    internal class FileReader
    {

        private static readonly string _filePath = $"{Directory.GetCurrentDirectory()}/UserNames.txt";

        public static string[] ReadFile(Action<string, StatusCode> alertUser)
        {
            bool fileNotFound = true;

            while(fileNotFound)
            {
                try
                {
                    string namesText = File.ReadAllText(_filePath);

                    string[] userNames = namesText.Split("\r\n");

                    return userNames;
                }
                catch (FileNotFoundException e)
                {
                    alertUser("The file \"UserNames.txt\" was not found in the current directory. Terminating application", StatusCode.Error);
                    alertUser(e.Message, StatusCode.Error);
                    Environment.Exit(-1);                    
                }
            }

            return null;
        }
    }
}
