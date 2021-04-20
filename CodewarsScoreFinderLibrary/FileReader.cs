using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodewarsScoreFinderLibrary
{
    internal class FileReader
    {
        private static readonly string _filePath = $"{Directory.GetCurrentDirectory()}/UserNames.txt";

        public static string[] ReadFile()
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
                    ConsoleLogging.Error("The file \"UserNames.txt\" was not found in the current directory. Terminating application");
                    ConsoleLogging.Error(e.Message);
                    Environment.Exit(-1);                    
                }
            }

            return null;
        }
    }
}
