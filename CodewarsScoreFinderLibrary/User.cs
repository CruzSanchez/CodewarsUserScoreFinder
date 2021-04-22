using System;
using System.Collections.Generic;
using System.Text;

namespace CodewarsScoreFinderLibrary
{
    public class User
    {
        public string UserName { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    name = "Not Provided";
                }
            }
        }

        public int Honor { get; set; }
        public string Clan { get; set; }
        public int? LeaderBoardPosition { get; set; }
        public List<string> Skills { get; set; }
        public Ranks Ranks { get; set; }
        public CodeChallenges CodeChallenges { get; set; }
    }
}
