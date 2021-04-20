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

        public User GetUser(string userName)
        {
            RestClient client = new RestClient(new Uri($"{_baseURL}{userName}"));
            RestRequest request = new RestRequest(Method.GET);
            
            User user = DeserializeResponse(client, request);

            return user;
        }

        private static User DeserializeResponse(RestClient client, RestRequest request)
        {
            IRestResponse response = client.Execute(request);
            User user = JsonConvert.DeserializeObject<User>(response.Content.ToString());
            return user;
        }
    }
}
