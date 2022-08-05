using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static CodewarsScoreFinderLibrary.Enums;

namespace CodewarsScoreFinderLibrary
{
    public class ScoreRetriever
    {
        private const string BASE_URL = @"https://www.codewars.com/api/v1/users/";
        public static List<User> Users { get; private set; } = new List<User>();

        public async Task ExecuteOrder66(Action<string, StatusCode> alertUser)
        {
            string[] userNames = FileReader.ReadFile(alertUser);

            foreach (string userName in userNames)
            {
                await GetUser(userName);                
            }
        }

        private async Task GetUser(string userName)
        {
            RestClient client = new RestClient(new Uri($"{BASE_URL}{userName}"));
            RestRequest request = new RestRequest(Method.GET);
            
            User user = await DeserializeResponse(client, request);

            AddUserToList(user);
        }

        private async static Task<User> DeserializeResponse(RestClient client, RestRequest request)
        {
            IRestResponse response = await client.ExecuteAsync(request);
            User user = JsonConvert.DeserializeObject<User>(response.Content.ToString());
            return user;
        }

        private void AddUserToList(User user)
        {
            Users.Add(user);
        }
    }
}
