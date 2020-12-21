using Newtonsoft.Json;
using RestSharp;
using System;

namespace Entidad
{
    public class APIHelper<T> : Exception
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "http://192.168.1.33:8000";

        public RestClient Client(string endpoint)
        {
            var url = baseUrl + "" + endpoint;
            var restClient = new RestClient(url);
            string token = new Session().Access_token;
            restClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", "" + token));
            return restClient;
        }

        public RestRequest Request(dynamic body = null, string method = "GET")
        {

            var restRequest = new RestRequest(setMethod(method));

            if ("" + body != "")
            {
                restRequest.AddJsonBody(body);
            }

            return restRequest;
        }


        public IRestResponse Response(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO Content<DTO>(IRestResponse response)
        {

            var content = response.Content;

            if (!response.IsSuccessful)
            {
                throw new Exception("" + content.Substring(0, 500));
            }
          
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }

        private Method setMethod(string url)
        {
            switch (url.ToUpper())
            {
                case "POST": return Method.POST;
                case "GET": return Method.GET;
                case "DELETE": return Method.DELETE;
                case "PATCH": return Method.PATCH;
                case "PUT": return Method.PUT;
                default: return Method.GET;
            }
        }
    }
}
