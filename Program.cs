using System;
using System.Linq;
using OAuth2.Helpers;
using RestSharp;
using Newtonsoft.Json;

namespace OAuth2
{
    class Program
    {
        static readonly string authUrl = "https://id.winks.io/ids";
        static readonly string clientId = "#CLIENT_ID#";
        static readonly string clientSecret = "#SECRET_CODE#";
        static readonly string companyName = "#COMPANY_NAME#";
        static readonly string callbackUrl = "http://localhost:55555/";
        static string accessToken = "";

        static void Main(string[] args)
        {         
            GetColors();
            Console.ReadLine();
        }

        public static dynamic GetColors()
        {
            Console.WriteLine(String.Format("Loading Color API..."));

            accessToken = Connect.Token(authUrl, clientId, clientSecret, callbackUrl);
            var request = new RestRequest("/api/" + companyName + "/Color/Folders", Method.GET);
            request.AddHeader("Authorization", "Bearer " + accessToken);

            RestClient client = new RestClient("https://developers.beproduct.com/");
            var response = client.Execute<dynamic>(request);
            dynamic result = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine(result);
            Console.WriteLine(String.Format("Returning color data..."));
            return result;
        }


    }
}
