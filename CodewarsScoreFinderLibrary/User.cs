using System;
using System.Collections.Generic;
using System.Text;

namespace CodewarsScoreFinderLibrary
{
    public class User
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public int Honor { get; set; }
        public string Clan { get; set; }
        public int LeaderBoardPosition { get; set; }
        public List<string> Skills { get; set; }
        public Ranks Ranks { get; set; }
    }
}
