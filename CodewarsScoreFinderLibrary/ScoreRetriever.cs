using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodewarsScoreFinderLibrary
{
    public class ScoreRetriever
    {
        private readonly string _baseURL = @"https://www.codewars.com/api/v1/users/";
        public static List<User> Users { get; private set; } = new List<User>();

        public void ExecuteOrder66()
        {
            string[] userNames = FileReader.ReadFile();

            foreach (string userName in userNames)
            {
                GetUser(userName);
            }
        }

        private void GetUser(string userName)
        {
            RestClient client = new RestClient(new Uri($"{_baseURL}{userName}"));
            RestRequest request = new RestRequest(Method.GET);
            
            User user = DeserializeResponse(client, request);

            AddUserToList(user);
        }

        private static User DeserializeResponse(RestClient client, RestRequest request)
        {
            IRestResponse response = client.Execute(request);
            User user = JsonConvert.DeserializeObject<User>(response.Content.ToString());
            return user;
        }

        private void AddUserToList(User user)
        {
            Users.Add(user);
        }
    }
}
